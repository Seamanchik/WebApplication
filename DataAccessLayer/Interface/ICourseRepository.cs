using DataAccessLayer.Models;

namespace DataAccessLayer.Interface
{
    public interface ICourseRepository
    {
        Task<ICollection<Course>?> GetAllCoursesAsync(CancellationToken cancellationToken = default);
        Task<Course?> GetCourseAsync(int id, CancellationToken cancellationToken = default);
        Task<Course?> GetCourseWithIncludeAsync(int id, CancellationToken cancellationToken = default);
        Task AddCourseAsync(Course course, CancellationToken cancellationToken = default);
        Task UpdateCourseAsync(Course course, CancellationToken cancellationToken = default);
        Task DeleteCourseAsync(Course course, CancellationToken cancellationToken = default);
        Task<bool> CourseExistsAsync(string name, CancellationToken cancellationToken = default);
    }
}
