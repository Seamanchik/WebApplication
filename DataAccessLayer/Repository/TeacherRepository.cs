using DataAccessLayer.Context;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    internal class TeacherRepository(WebAppDbContext webAppDbContext) : ITeacherRepository
    {
        public async Task AddTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default)
        {
            await webAppDbContext.Teachers.AddAsync(teacher, cancellationToken);
            await webAppDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Teacher?> GetTeacherAsync(int id, CancellationToken cancellationToken = default) =>
            await webAppDbContext.Teachers.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);

        public async Task<ICollection<Teacher>?> GetAllTeachersAsync(CancellationToken cancellationToken = default) =>
            await webAppDbContext.Teachers.ToListAsync(cancellationToken);

        public async Task UpdateTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default)
        {
            webAppDbContext.Teachers.Update(teacher);
            await webAppDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteTeacherAsync(Teacher teacher, CancellationToken cancellationToken = default)
        {
            webAppDbContext.Teachers.Remove(teacher!);
            await webAppDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
