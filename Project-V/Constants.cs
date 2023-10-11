namespace Project_V
{
    //用于连接sqlLite数据库，配置应用常量
    public static class Constants
    {
        public const string DatabaseFilename = "Kang_0";

        //public static string BaseAddress =
        //    DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:5001" : "https://localhost:5001";
        //public static string RestUrl = $"{BaseAddress}/api/students/";
        //public static string TodoItemsUrl = $"{BaseAddress}/api/students/";


        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(Environment.GetFolderPath(DeviceInfo.Platform == DevicePlatform.Android ? Environment.SpecialFolder.Personal : Environment.SpecialFolder.LocalApplicationData), Constants.DatabaseFilename);
    }
}
