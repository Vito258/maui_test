using SQLite;

namespace Project_V.Models
{
    public class Student
    {

        [PrimaryKey, AutoIncrement]  //设置主键自增
        public int Id { get; set; }
        public string Name { get; set; }

        public double Score { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsNewStudent { get; set; }

    }
}
