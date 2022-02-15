using File_Managment_System;

string trackedDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), @"MyFiles");
var git = new Git(trackedDirectoryPath);

var mode = ConsoleUI.RequestStartMode();
if (mode is ModeType.Observation)
{
    git.OnAddedFile += (file) => Console.WriteLine("Added: " + file.FullName);
    git.OnDeletedFile += (file) => Console.WriteLine("Deleted: " + file.FullName);
    git.OnUpdateFile += (file) => Console.WriteLine("Updated: " + file.FullName);

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