using DTO.DTO;

namespace BusinessLayer.Interface
{
    public interface ITeacherService
    {
        Task<string?> GetAllTeachersAsync(CancellationToken cancellationToken = default);
        Task<string> GetTeacherAsync(int id, CancellationToken cancellationToken = default);
        Task AddTeacherAsync(CreateTeacherDTO createTeacherDTO, CancellationToken cancellationToken = default);
        Task DeleteTeacherAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateTeacherAsync(UpdateTeacherDTO updateTeacherDTO, CancellationToken cancellationToken = default);
    }
}
