using DataAccessLayer.Context;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    internal class CourseRepository(WebAppDbContext webAppDbContext) : ICourseRepository
    {
        public async Task<ICollection<Course>?> GetAllCoursesAsync(CancellationToken cancellationToken = default) =>
            await webAppDbContext.Courses.Include(c => c.Teacher).Include(c => c.Students).ToListAsync(cancellationToken);

        public async Task<Course?> GetCourseAsync(int id, CancellationToken cancellationToken = default) =>
            await webAppDbContext.Courses.Include(c => c.Teacher)
            .Include(c => c.Students)
            .FirstOrDefaultAsync(i => i.Id == id, cancellationToken);

        public async Task AddCourseAsync(Course course, CancellationToken cancellationToken = default)
        {
            await webAppDbContext.Courses.AddAsync(course, cancellationToken);
            await webAppDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateCourseAsync(Course course, CancellationToken cancellationToken = default)
        {
            webAppDbContext.Courses.Update(course);
            await webAppDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteCourseAsync(Course course, CancellationToken cancellationToken = default)
        {
            webAppDbContext.Courses.Remove(course);
            await webAppDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> CourseExistsAsync(string name, CancellationToken cancellationToken = default) =>
            await webAppDbContext.Courses.AnyAsync(n => n.Name == name, cancellationToken);
    }
}
