namespace DataAccessLayer.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? TeacherId { get; set; } 
        public Teacher? Teacher { get; set; }
        public ICollection<Student> Students { get; set; } = [];
    }
}
