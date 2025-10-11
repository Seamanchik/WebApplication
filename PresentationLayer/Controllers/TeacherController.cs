using BusinessLayer.Interface;
using DTO.DTO;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("teacher")]
    public class TeacherController(ITeacherService teacherService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllTeachersAsync()
        {
            string? result = await teacherService.GetAllTeachersAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTeacherAsync([FromRoute]int id)
        {
            string result = await teacherService.GetTeacherAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacherAsync(CreateTeacherDTO createTeacherDTO)
        {
            await teacherService.AddTeacherAsync(createTeacherDTO);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTeacherAsync([FromRoute]int id)
        {
            await teacherService.DeleteTeacherAsync(id);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTeacherAsync(UpdateTeacherDTO updateTeacherDTO)
        {
            await teacherService.UpdateTeacherAsync(updateTeacherDTO);
            return NoContent();
        }
    }
}
