using DataAccessLayer.Models;

namespace DataAccessLayer.Interface
{
    public interface ITeacherRepository
    {
        Task AddTeacherAsync(Teacher teacher, CancellationToken cancellationToken);
        Task<Teacher?> GetTeacherAsync(int id , CancellationToken cancellationToken);
        Task<ICollection<Teacher>?> GetAllTeachersAsync(CancellationToken cancellationToken);
        Task DeleteTeacherAsync(Teacher teacher, CancellationToken cancellationToken);
        Task UpdateTeacherAsync(Teacher teacher, CancellationToken cancellationToken);
        Task<bool> TeacherExistsByNameAsync(string name, string surname, CancellationToken cancellationToken = default);
    }
}
