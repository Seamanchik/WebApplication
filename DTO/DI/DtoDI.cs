using DTO.DTO;
using DTO.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DTO.DI
{
    public static class DtoDI
    {
        public static IServiceCollection AddDto(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateCourseDTO>, CreateCourseDTOValidator>();
            services.AddScoped<IValidator<UpdateCourseDTO>, UpdateCourseDTOValidator>();
            services.AddScoped<IValidator<CreateStudentDTO>, CreateStudentDTOValidator>();
            services.AddScoped<IValidator<UpdateStudentDTO>, UpdateStudentDTOValidator>();
            services.AddScoped<IValidator<CreateTeacherDTO>, CreateTeacherDTOValidator>();
            services.AddScoped<IValidator<UpdateTeacherDTO>, UpdateTeacherDTOValidator>();
            services.AddScoped<IValidator<CourseStudentDTO>, CourseStudentDTOValidator>();
            return services;
        }
    }
}
