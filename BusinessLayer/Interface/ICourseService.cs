using DTO.DTO;

namespace BusinessLayer.Interface
{
    public interface ICourseService
    {
        Task<string?> GetAllCoursesAsync(CancellationToken cancellationToken = default);
        Task<string?> GetCourseAsync(int id, CancellationToken cancellationToken = default);
        Task AddCourseAsync(CreateCourseDTO createCourseDTO, CancellationToken cancellationToken = default);
        Task UpdateCourseAsync(UpdateCourseDTO updateCourseDTO, CancellationToken cancellationToken = default);
        Task AddStudentOnCourse(int courseId, int studentId,  CancellationToken cancellationToken = default);
        Task DeleteCourseAsync(int id, CancellationToken cancellationToken = default);
    }
}
