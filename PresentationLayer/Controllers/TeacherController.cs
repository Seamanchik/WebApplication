using BusinessLayer.Interface;
using DTO.DTO;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("teacher")]
    public class TeacherController(ITeacherService teacherService, IValidator<CreateTeacherDTO> createValidator, IValidator<UpdateTeacherDTO> updateValidator) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllTeachersAsync()
        {
            var result = await teacherService.GetAllTeachersAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTeacherAsync([FromRoute]int id)
        {
            var result = await teacherService.GetTeacherAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacherAsync(CreateTeacherDTO createTeacherDTO)
        {
            createValidator.ValidateAndThrow(createTeacherDTO);
            await teacherService.AddTeacherAsync(createTeacherDTO);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTeacherAsync([FromRoute]int id)
        {
            await teacherService.DeleteTeacherAsync(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeacherAsync(UpdateTeacherDTO updateTeacherDTO)
        {
            updateValidator.ValidateAndThrow(updateTeacherDTO);
            await teacherService.UpdateTeacherAsync(updateTeacherDTO);
            return NoContent();
        }
    }
}
