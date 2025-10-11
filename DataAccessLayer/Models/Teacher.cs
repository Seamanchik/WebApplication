namespace DataAccessLayer.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public ICollection<Course> Courses { get; set; } = [];
    }
}
