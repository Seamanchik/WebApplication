using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using DTO.DTO;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("student")]
    public class StudentController(IStudentService studentService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            string? result = await studentService.GetAllStudentsAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudentAsync([FromRoute]int id)
        {
            string? result = await studentService.GetStudentAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudentAsync(CreateStudentDTO createStudentDto)
        {
            await studentService.AddStudentAsync(createStudentDto);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateStudentAsync(UpdateStudentDTO updateStudentDTO)
        {
            await studentService.UpdateStudentAsync(updateStudentDTO);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute]int id)
        {
            await studentService.DeleteStudentAsync(id);
            return NoContent();
        }
    }
}
