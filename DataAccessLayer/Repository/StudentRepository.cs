using DataAccessLayer.Context;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    internal class StudentRepository(WebAppDbContext webAppDbContext) : IStudentRepository
    {
        public async Task<ICollection<Student>?> GetAllStudentsAsync(CancellationToken cancellationToken = default) =>
            await webAppDbContext.Students.Include(s => s.Courses).ToListAsync(cancellationToken);

        public async Task<Student?> GetStudentAsync(int id, CancellationToken cancellationToken = default) =>
            await webAppDbContext.Students.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);

        public async Task AddStudentAsync(Student student, CancellationToken cancellationToken = default)
        {
            await webAppDbContext.Students.AddAsync(student, cancellationToken);
            await webAppDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateStudentAsync(Student student, CancellationToken cancellationToken = default)
        {
            webAppDbContext.Students.Update(student);
            await webAppDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteStudentAsync(Student student, CancellationToken cancellationToken = default)
        {
            webAppDbContext.Students.Remove(student!);
            await webAppDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> StudentExistsByNameAsync(string name, string surname, CancellationToken cancellationToken = default) =>
            await webAppDbContext.Students.AnyAsync(s => s.Name == name && s.Surname == surname, cancellationToken);
    }
}
