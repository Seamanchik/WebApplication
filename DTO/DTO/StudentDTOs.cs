namespace DTO.DTO;

public record CreateStudentDTO(string Name, string Surname);

public record UpdateStudentDTO(int Id, string Name, string Surname);

public record StudentDTO(int Id, string Name, string Surname);