using BusinessLayer.Interface;
using DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("course")]
    public class CourseController(ICourseService courseService, IValidator<CreateCourseDTO> createValidator, IValidator<UpdateCourseDTO> updateValidator, IValidator<CourseStudentDTO> courseStudentValidator) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCoursesAsync()
        {
            var result = await courseService.GetAllCoursesAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCourseAsync([FromRoute]int id)
        {
            var result = await courseService.GetCourseAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourseAsync(CreateCourseDTO createCourseDTO)
        {
            createValidator.ValidateAndThrow(createCourseDTO);
            await courseService.AddCourseAsync(createCourseDTO);
            return NoContent();
        }
     
        [HttpPut]
        public async Task<IActionResult> UpdateCourseAsync(UpdateCourseDTO updateCourseDTO)
        {
            updateValidator.ValidateAndThrow(updateCourseDTO);
            await courseService.UpdateCourseAsync(updateCourseDTO);
            return NoContent();
        }

        [HttpPut("student")]
        public async Task<IActionResult> AddStudentOnCourse(CourseStudentDTO courseStudentDTO)
        {
            courseStudentValidator.ValidateAndThrow(courseStudentDTO);
            await courseService.AddStudentOnCourse(courseStudentDTO);
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
