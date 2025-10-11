using BusinessLayer.Interface;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using DTO.DTO;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace BusinessLayer.Service
{
    internal class CourseService(ICourseRepository courseRepository, ITeacherRepository teacherRepository,
                                 IStudentRepository studentRepository) : ICourseService
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

            return course is null ? throw new Exception("Course not found.") : JsonSerializer.Serialize(MapToDto(course), options);
        }

        public async Task AddCourseAsync(CreateCourseDTO createCourseDTO, CancellationToken cancellationToken = default)
        {
            if (await courseRepository.CourseExistsAsync(createCourseDTO.Name, cancellationToken))
                throw new Exception("Course already exists.");

            Course course = new Course
            {
                Name = createCourseDTO.Name,
                Description = createCourseDTO.Description,
                TeacherId = createCourseDTO.TeacherId
            };

            await courseRepository.AddCourseAsync(course, cancellationToken);
        }

        public async Task UpdateCourseAsync(UpdateCourseDTO updateCourseDTO, CancellationToken cancellationToken = default)
        {
            Course? course = await courseRepository.GetCourseAsync(updateCourseDTO.Id, cancellationToken) ?? throw new Exception("Course not found.");
            course.Name = updateCourseDTO.Name;
            course.Description = updateCourseDTO.Description;
            course.TeacherId = updateCourseDTO.TeacherId;

            await courseRepository.UpdateCourseAsync(course, cancellationToken);
        }

        public async Task UpdateTeacherOnCourseAsync(int courseId, int teacherId, CancellationToken cancellationToken = default)
        {
            Teacher? teacher = await teacherRepository.GetTeacherAsync(teacherId, cancellationToken) ?? throw new Exception("Teacher not found.");
            Course? course = await courseRepository.GetCourseAsync(courseId, cancellationToken) ?? throw new Exception("Course not found.");
            
            course.Teacher = teacher;
            course.TeacherId = teacher.Id;
            await courseRepository.UpdateCourseAsync(course, cancellationToken);
        }

        public async Task AddStudentOnCourse(int courseId, int studentId, CancellationToken cancellationToken = default)
        {
            Student? student = await studentRepository.GetStudentAsync(studentId, cancellationToken) ?? throw new Exception("Student not found.");
            Course? course = await courseRepository.GetCourseWithIncludeAsync(courseId, cancellationToken) ?? throw new Exception("Course not found.");
            
            if (!course.Students.Contains(student))
            {
                course.Students.Add(student);
                await courseRepository.UpdateCourseAsync(course, cancellationToken);
            }
        }

        public async Task DeleteCourseAsync(int id, CancellationToken cancellationToken = default)
        {
            Course? course = await courseRepository.GetCourseAsync(id, cancellationToken) ?? throw new Exception("Course not found.");
            
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
