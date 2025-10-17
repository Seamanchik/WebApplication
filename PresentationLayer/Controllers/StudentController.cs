using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using DTO.DTO;
using FluentValidation;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("student")]
    public class StudentController(IStudentService studentService, IValidator<CreateStudentDTO> createValidator, IValidator<UpdateStudentDTO> updateValidator) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var result = await studentService.GetAllStudentsAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudentAsync([FromRoute]int id)
        {
            var result = await studentService.GetStudentAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudentAsync(CreateStudentDTO createStudentDto)
        {
            createValidator.ValidateAndThrow(createStudentDto);
            await studentService.AddStudentAsync(createStudentDto);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudentAsync(UpdateStudentDTO updateStudentDTO)
        {
            updateValidator.ValidateAndThrow(updateStudentDTO);
            await studentService.UpdateStudentAsync(updateStudentDTO);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudentAsync(int id)
        {
            await studentService.DeleteStudentAsync(id);
            return NoContent();
        }
    }
}
