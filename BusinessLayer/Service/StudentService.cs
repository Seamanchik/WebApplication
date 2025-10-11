using BusinessLayer.Interface;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using DTO.DTO;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace BusinessLayer.Service
{
    internal class StudentService(IStudentRepository studentRepository, ICourseRepository courseRepository) : IStudentService
    {
        readonly JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public async Task<string?> GetAllStudentsAsync(CancellationToken cancellationToken = default)
        {
            ICollection<Student>? students = await studentRepository.GetAllStudentsAsync(cancellationToken);

            return JsonSerializer.Serialize(students!.Select(MapToDto), options);
        }

        public async Task<string?> GetStudentAsync(int id, CancellationToken cancellationToken = default)
        {
            Student? student = await studentRepository.GetStudentAsync(id, cancellationToken);

            return student is null ? throw new Exception("Student not found.") : JsonSerializer.Serialize(MapToDto(student), options);
        }

        public async Task AddStudentAsync(CreateStudentDTO createStudentDTO, CancellationToken cancellationToken = default)
        {
            Student student = new Student
            {
                Name = createStudentDTO.Name,
                Surname = createStudentDTO.Surname
            };

            await studentRepository.AddStudentAsync(student, cancellationToken);
        }

        public async Task UpdateStudentAsync(UpdateStudentDTO updateStudentDTO, CancellationToken cancellationToken = default)
        {
            Student? student = await studentRepository.GetStudentAsync(updateStudentDTO.Id, cancellationToken) ?? throw new Exception("Student not found.");
            
            student.Name = updateStudentDTO.Name;
            student.Surname = updateStudentDTO.Surname;

            await studentRepository.UpdateStudentAsync(student, cancellationToken);
        }

        public async Task DeleteStudentAsync(int id, CancellationToken cancellationToken = default)
        {
            Student? student = await studentRepository.GetStudentAsync(id, cancellationToken) ?? throw new Exception("Student not found.");
            
            await studentRepository.DeleteStudentAsync(student, cancellationToken);
        }

        private static StudentDTO MapToDto(Student s) => new StudentDTO(s.Id, s.Name, s.Surname);
    }
}
