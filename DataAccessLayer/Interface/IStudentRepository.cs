using DataAccessLayer.Models;

namespace DataAccessLayer.Interface
{
    public interface IStudentRepository
    {
        Task AddStudentAsync(Student student, CancellationToken cancellationToken = default);
        Task<Student?> GetStudentAsync(int id, CancellationToken cancellationToken = default);
        Task<ICollection<Student>?> GetAllStudentsAsync(CancellationToken cancellationToken = default);
        Task UpdateStudentAsync(Student student, CancellationToken cancellationToken = default);
        Task DeleteStudentAsync(Student student, CancellationToken cancellationToken = default);
    }
}
