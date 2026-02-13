
namespace StudentsAPI.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Marks { get; set; }

        internal int Max(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}
