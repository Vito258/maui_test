using Project_V.Models;
using SQLite;

namespace Project_V
{
    //数据库包装类,使用sqlite数据库的类
    public class TodoItemDatabase
    {
        //创建数据库访问类

        readonly SQLiteAsyncConnection database;
        //用于使用AddSingleton 方法注册到容器中
        public TodoItemDatabase()
        {

        }
        public TodoItemDatabase(string dbPath)
        {

            var fileInfo = new FileInfo(dbPath);
            var dir = fileInfo.Directory;
            if (!dir.Exists)
            {
                dir.Create();
            }
            try
            {
                database = new SQLiteAsyncConnection(dbPath);
                database.CreateTableAsync<Student>().Wait();
            }
            catch (Exception ex)
            {
                //AppLog.Log.Error(message: $"{ex.ToString()}", ex: ex);
                Application.Current.MainPage.DisplayAlert("Error", "与数据库连接发生错误", "确定");
            }

        }
        //async Task Init()
        //{
        //    //除非首次访问数据库，否则使用异步延迟初始化来延迟数据库的初始化
        //    if (database is not null)
        //        return;

        //    database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        //    var result = await database.CreateTableAsync<Student>();
        //}
        public async Task<Student> GetItemAsync(int id)
        {
            ////await Init();
            return await database.Table<Student>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        //得到全部成员的表单
        public async Task<List<Student>> GetItemsAsync()
        {
            //await Init();
            return await database.Table<Student>().ToListAsync();
        }
        //得到符合条件的成员表单
        public async Task<List<Student>> GetItemsNotDelAsync()
        {
            //await Init();
            return await database.Table<Student>().Where(t => t.IsDeleted).ToListAsync();

            //SQL queries are also possible
            //return await database.QueryAsync<Student>("SELECT * FROM [Student] WHERE [Done] = 0");
        }


        public async Task<int> SaveItemAsync(Student item)
        {
            //await Init();
            if (item.Id != 0)

                return await database.UpdateAsync(item);
            else
                return await database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(Student item)
        {
            //await Init();
            return await database.DeleteAsync(item);
        }
    }
}
