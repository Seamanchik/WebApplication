namespace DTO.DTO;

public record TeacherDTO(int Id, string Name, string Surname);

public record CreateTeacherDTO(string Name, string Surname);

public record UpdateTeacherDTO(int Id,string Name, string Surname);