using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.DI
{
    public static class BusinessDI
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
            return services;
        }
    }
}
