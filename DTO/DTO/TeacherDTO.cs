namespace DTO.DTO;

public record TeacherDTO(int Id, string Name, string SurName);

public record CreateTeacherDTO(string Name, string SurName);

public record UpdateTeacherDTO(int Id,string Name, string SurName);