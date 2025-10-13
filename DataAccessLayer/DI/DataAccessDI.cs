using DataAccessLayer.Context;
using DataAccessLayer.Interface;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer.DI
{
    public static class DataAccessDI
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddDbContext<WebAppDbContext>(x => {
                x.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}
