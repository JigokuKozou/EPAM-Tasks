using File_Managment_System;

string trackedDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), @"MyFiles");
var git = new Git(trackedDirectoryPath);

var mode = ConsoleUI.RequestStartMode();
if (mode is ModeType.Observation)
{
    git.OnAddedFile += (file) => Console.WriteLine($"{ DateTime.Now } Added: { file.Name }");
    git.OnDeletedFile += (file) => Console.WriteLine($"{ DateTime.Now } Deleted: { file.Name}");
    git.OnUpdateFile += (file) => Console.WriteLine($"{ DateTime.Now } Updated: { file.Name}");

    git.StartTrackDirectoryAsync();
}
else if (mode is ModeType.RollingBackChanges)
{
    DateTime date;
    do
    {
        Console.Write("Введите дату (дд.мм.гггг чч.мм.сс): ");
    } while (!DateTime.TryParse(Console.ReadLine(), out date));

    git.RollingBackChanges(date);
}


Console.WriteLine("Нажмите любую клавишу, чтобы закрыть программу...");
Console.ReadKey();