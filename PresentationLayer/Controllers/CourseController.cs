using BusinessLayer.Interface;
using DTO.DTO;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("course")]
    public class CourseController(ICourseService courseService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCoursesAsync()
        {
            string? result = await courseService.GetAllCoursesAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCourseAsync([FromRoute]int id)
        {
            string? result = await courseService.GetCourseAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourseAsync(CreateCourseDTO createCourseDTO)
        {
            await courseService.AddCourseAsync(createCourseDTO);
            return NoContent();
        }
     
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCourseAsync(UpdateCourseDTO updateCourseDTO)
        {
            await courseService.UpdateCourseAsync(updateCourseDTO);
            return NoContent();
        }

        [HttpPut("student/{id:int}")]
        public async Task<IActionResult> AddStudentOnCourse([FromRoute]int id, int studentId)
        {
            await courseService.AddStudentOnCourse(id, studentId);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCourseAsync([FromRoute]int id)
        {
            await courseService.DeleteCourseAsync(id);
            return NoContent();
        }
    }
}
