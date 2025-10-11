using BusinessLayer.Interface;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using DTO.DTO;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace BusinessLayer.Service
{
    internal class TeacherService(ITeacherRepository teacherRepository) : ITeacherService
    {
        readonly JsonSerializerOptions options = new() {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public async Task<string?> GetAllTeachersAsync(CancellationToken cancellationToken = default)
        {
            ICollection<Teacher>? teachers = await teacherRepository.GetAllTeachersAsync(cancellationToken);

            return JsonSerializer.Serialize(teachers!.Select(MapToDto), options);
        }

        public async Task<string> GetTeacherAsync(int id, CancellationToken cancellationToken = default)
        {
            Teacher? teacher = await teacherRepository.GetTeacherAsync(id, cancellationToken);

            return teacher is null ? throw new Exception("Teacher not found.") : JsonSerializer.Serialize(MapToDto(teacher), options);
        }

        public async Task AddTeacherAsync(CreateTeacherDTO createTeacherDTO, CancellationToken cancellationToken = default)
        {
            Teacher teacher = new()
            {
                Name = createTeacherDTO.Name,
                SurName = createTeacherDTO.SurName,
            };

            await teacherRepository.AddTeacherAsync(teacher, cancellationToken);
        }

        public async Task DeleteTeacherAsync(int id, CancellationToken cancellationToken = default)
        {
            Teacher? teacher = await teacherRepository.GetTeacherAsync(id, cancellationToken) ?? throw new Exception("Teacher not found.");
            await teacherRepository.DeleteTeacherAsync(teacher, cancellationToken);
        }

        public async Task UpdateTeacherAsync(UpdateTeacherDTO updateTeacherDTO, CancellationToken cancellationToken = default)
        {
            Teacher? teacher = await teacherRepository.GetTeacherAsync(updateTeacherDTO.Id, cancellationToken) ?? throw new Exception("Teacher not found.");
            teacher.Name = updateTeacherDTO.Name;
            teacher.SurName = updateTeacherDTO.SurName;

            await teacherRepository.UpdateTeacherAsync(teacher, cancellationToken);
        }

        private static TeacherDTO MapToDto(Teacher t) => new TeacherDTO(t.Id, t.Name, t.SurName);
    }
}
