using DTO.DTO;

namespace BusinessLayer.Interface
{
    public interface IStudentService
    {
        Task<string?> GetAllStudentsAsync(CancellationToken cancellationToken = default);
        Task<string?> GetStudentAsync(int id, CancellationToken cancellationToken = default);
        Task AddStudentAsync(CreateStudentDTO createStudentDto, CancellationToken cancellationToken = default);
        Task DeleteStudentAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateStudentAsync(UpdateStudentDTO updateStudentDto, CancellationToken cancellationToken = default);
    }
}
