using System.Linq;
using System.Collections.Generic;

namespace File_Managment_System
{
    public class Git
    {
        private const string NameGitDirectory = ".cgit";

        private const string NameGitDirectoryFiles = "Files";

        private readonly Dictionary<FileInfo, FileInfo> _originalCopyFilesPairs = new();

        private DirectoryInfo _trackedDirectory;

        private string _gitDirectoryFilesPath;

        private IEnumerable<FileInfo> _allTxtFilesInfo;

        public Git(string TrackedDirectoryPath)
        {
            TrackedDirectory = new DirectoryInfo(TrackedDirectoryPath);

            if (!TrackedDirectory.Exists)
                throw new DirectoryNotFoundException(TrackedDirectoryPath);

            _allTxtFilesInfo = GetAllFiles()
            .Where(file => file.EndsWith(".txt"))
            .Select(filePath => new FileInfo(filePath));
        }

        public string GitDirectoryPath { get; private set; }

        private DirectoryInfo TrackedDirectory
        {
            get => _trackedDirectory;
            set
            {
                _trackedDirectory = value;
                GitDirectoryPath = Path.Combine(_trackedDirectory.FullName, NameGitDirectory);
                _gitDirectoryFilesPath = Path.Combine(GitDirectoryPath, NameGitDirectoryFiles);
            }
        }

        public Action<FileInfo> OnAddedFile = delegate { };

        public Action<FileInfo> OnDeletedFile = delegate { };

        public Action<FileInfo> OnUpdateFile = delegate { };

        public async Task StartTrackDirectoryAsync()
        {
            if (!Init())
                LoadOriginalCopyFilesPairs();

            await TrackFilesAsync();

            void LoadOriginalCopyFilesPairs()
            {
                var directories = new DirectoryInfo(_gitDirectoryFilesPath).GetDirectories();

                foreach (var fileInfo in _allTxtFilesInfo)
                {
                    var directory = directories
                        .FirstOrDefault(directory => directory.Name == fileInfo.Name);

                    if (directory != null)
                    {
                        var actualFile = directory.GetFiles()
                            .MaxBy(file => file.CreationTime);

                        _originalCopyFilesPairs.Add(fileInfo, actualFile);
                    }
                }
            }
        }

        public void RollingBackChanges(DateTime destinationTime)
        {
            if (!Directory.Exists(_gitDirectoryFilesPath))
                throw new DirectoryNotFoundException(_gitDirectoryFilesPath);

            foreach (var file in _trackedDirectory.GetFiles())
                File.Delete(file.FullName);

            var filesDirectoryInfo = new DirectoryInfo(_gitDirectoryFilesPath);

            foreach (var directory in filesDirectoryInfo.GetDirectories()
                .Where(directory => directory.CreationTime <= destinationTime))
            {
                var displayFile = directory.GetFiles()
                    .Where(file => file.CreationTime <= destinationTime)
                    .MaxBy(file => file.CreationTime);

                displayFile.CopyTo(Path.Combine(TrackedDirectory.FullName, directory.Name));
            }
        }

        private bool Init()
        {
            bool isExist = Directory.Exists(GitDirectoryPath);

            if (!isExist)
            {
                Directory.CreateDirectory(GitDirectoryPath);
                TrackedDirectory = new DirectoryInfo(TrackedDirectory.FullName);
                Directory.CreateDirectory(_gitDirectoryFilesPath);
            }

            return !isExist;
        }

        private async Task TrackFilesAsync()
        {
            while (true)
            {
                UntrackedDeletedFiles(_allTxtFilesInfo);
                TrackUntrackedFiles(_allTxtFilesInfo);

                CheckFilesContent();

                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            void TrackUntrackedFiles(IEnumerable<FileInfo> filesInfo)
            {
                foreach (var fileInfo in filesInfo)
                {
                    if (!_originalCopyFilesPairs.Any(pair => pair.Key.FullName == fileInfo.FullName))
                    {
                        AddUntrackedFile(fileInfo);
                    }
                }
            }

            void UntrackedDeletedFiles(IEnumerable<FileInfo> filesInfo)
            {
                foreach (var originalCopyPair in _originalCopyFilesPairs)
                {
                    if (!filesInfo.Any(fileInfo 
                        => originalCopyPair.Key.FullName == fileInfo.FullName))
                    {
                        DeleteTrackedFile(originalCopyPair.Key);
                    }
                }
            }

            void CheckFilesContent()
            {
                foreach (var pair in _originalCopyFilesPairs
                    .Where(pair => !IsSame(pair.Key, pair.Value, out int indexLine)))
                {
                    UpdateTrackedFile(pair.Key);
                }
            }
        }

        private void AddUntrackedFile(FileInfo fileInfo)
        {
            var copyFileInfo = CopyFile(fileInfo);

            _originalCopyFilesPairs.Add(fileInfo, copyFileInfo);
            OnAddedFile(fileInfo);
        }

        private void DeleteTrackedFile(FileInfo fileInfo)
        {
            if (!_originalCopyFilesPairs.ContainsKey(fileInfo))
                throw new ArgumentException(fileInfo.FullName);

            _originalCopyFilesPairs.Remove(fileInfo);
            OnDeletedFile(fileInfo);
        }

        private void UpdateTrackedFile(FileInfo fileInfo)
        {
            if (!_originalCopyFilesPairs.ContainsKey(fileInfo))
                throw new ArgumentException(fileInfo.FullName + " is not tracked file");

            var copyFileInfo = CopyFile(fileInfo);

            _originalCopyFilesPairs[fileInfo] = copyFileInfo;

            OnUpdateFile(fileInfo);
        }

        private FileInfo CopyFile(FileInfo file)
        {
            string fileDirectory = Path.Combine(_gitDirectoryFilesPath, file.Name);
            if (!Directory.Exists(fileDirectory))
                Directory.CreateDirectory(fileDirectory);

            string copyName = DateTime.Now.ToString("dd_MM_yyyy HH_mm_ss") + file.Extension;

            return file.CopyTo(Path.Combine(fileDirectory, copyName));
        }

        private string[] GetAllFiles()
        {
            List<string> files = new(Directory.GetFiles(TrackedDirectory.FullName));

            var directories = Directory.GetDirectories(TrackedDirectory.FullName)
                .Where(directory => directory != GitDirectoryPath);
            if (directories.Any())
            {
                foreach (var directory in directories)
                {
                    files.AddRange(GetAllFiles(directory));
                }
            }

            return files.ToArray();
        }

        private static string[] GetAllFiles(string path)
        {
            List<string> files = new(Directory.GetFiles(path));

            var directories = Directory.GetDirectories(path);
            if (directories.Any())
            {
                foreach (var directory in directories)
                {
                    files.AddRange(GetAllFiles(directory));
                }
            }

            return files.ToArray();
        }

        private static bool IsSame(FileInfo original, FileInfo copy, out int indexLine)
        {
            using (var readerOriginal = new StreamReader(original.FullName))
            {
                using (var readerCopy = new StreamReader(copy.FullName))
                {
                    indexLine = 0;
                    while (!readerOriginal.EndOfStream)
                    {
                        var copyLine = readerCopy.ReadLine();
                        var originalLine = readerOriginal.ReadLine();

                        if (copyLine == originalLine)
                        {
                            indexLine++;
                            continue;
                        }

                        return false;
                    }

                    return readerCopy.EndOfStream;
                }
            }
        }
    }
}
