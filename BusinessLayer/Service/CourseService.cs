using BusinessLayer.Interface;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using DTO.DTO;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace BusinessLayer.Service
{
    internal class CourseService(ICourseRepository courseRepository, IStudentRepository studentRepository) : ICourseService
{

        readonly JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public async Task<string?> GetAllCoursesAsync(CancellationToken cancellationToken = default)
        {
            var courses = await courseRepository.GetAllCoursesAsync(cancellationToken);

            return JsonSerializer.Serialize(courses!.Select(MapToDto), options);
        }

        public async Task<string?> GetCourseAsync(int id, CancellationToken cancellationToken = default)
        {
            var course = await courseRepository.GetCourseAsync(id, cancellationToken);

            return course is null ? throw new Exception("Курс не найден.") : JsonSerializer.Serialize(MapToDto(course), options);
        }

        public async Task AddCourseAsync(CreateCourseDTO createCourseDTO, CancellationToken cancellationToken = default)
        {
            if (await courseRepository.CourseExistsAsync(createCourseDTO.Name, cancellationToken))
                throw new Exception("Такой курс уже существует.");

            Course course = new()
            {
                Name = createCourseDTO.Name,
                Description = createCourseDTO.Description,
                TeacherId = createCourseDTO.TeacherId
            };

            await courseRepository.AddCourseAsync(course, cancellationToken);
        }

        public async Task UpdateCourseAsync(UpdateCourseDTO updateCourseDTO, CancellationToken cancellationToken = default)
        {
            var course = await courseRepository.GetCourseAsync(updateCourseDTO.Id, cancellationToken) ?? throw new Exception("Курс не найден.");
            course.Name = updateCourseDTO.Name;
            course.Description = updateCourseDTO.Description;
            course.TeacherId = updateCourseDTO.TeacherId;

            await courseRepository.UpdateCourseAsync(course, cancellationToken);
        }

        public async Task AddStudentOnCourse(CourseStudentDTO courseStudentDTO, CancellationToken cancellationToken = default)
        {
            var student = await studentRepository.GetStudentAsync(courseStudentDTO.StudentId, cancellationToken) ?? throw new Exception("Студент не найден.");
            var course = await courseRepository.GetCourseAsync(courseStudentDTO.CourseId, cancellationToken) ?? throw new Exception("Курс не найден.");
            
            if (course.Students.Contains(student))
                throw new Exception("Студент уже зачислен на курс.");

            course.Students.Add(student);
            await courseRepository.UpdateCourseAsync(course, cancellationToken);
        }

        public async Task DeleteCourseAsync(int id, CancellationToken cancellationToken = default)
        {
            var course = await courseRepository.GetCourseAsync(id, cancellationToken) ?? throw new Exception("Курс не найден.");
            
            await courseRepository.DeleteCourseAsync(course, cancellationToken);
        }

        private static CourseDTO MapToDto(Course c) => new(
        c.Id,
        c.Name,
        c.Description,
        c.Teacher == null ? null : new TeacherDTO(c.Teacher.Id, c.Teacher.Name, c.Teacher.SurName),
        c.Students.Select(s => new StudentDTO(s.Id, s.Name, s.Surname)).ToList()
    );
    }
}
