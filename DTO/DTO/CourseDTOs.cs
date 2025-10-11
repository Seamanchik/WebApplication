namespace DTO.DTO;

public record CreateCourseDTO(string Name, string Description, int? TeacherId);

public record UpdateCourseDTO(int Id, string Name, string Description, int? TeacherId);

public record CourseDTO(int Id, string Name, string Description, TeacherDTO? Teacher, List<StudentDTO> Students);