namespace File_Managment_System
{
    public enum ModeType
    {
        None,
        Observation,
        RollingBackChanges,
    }

    public static class ConsoleUI
    {
        public static ModeType RequestStartMode()
        {
            int mode = 0;
            do
            {
                Console.WriteLine("Выберите режим:");
                Console.WriteLine("1. Наблюдение");
                Console.WriteLine("2. Откат изменений");
            } while (int.TryParse(Console.ReadLine(), out mode) && mode is not (1 or 2));

            return (ModeType)mode;
        }
    }
}
