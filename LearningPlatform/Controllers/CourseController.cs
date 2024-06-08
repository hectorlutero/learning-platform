using LearningPlatform.Contracts.LearningPlatform;
using LearningPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using LearningPlatform.Services.Courses;
using ErrorOr;
using LearningPlatform.ServicesErrors;

namespace LearningPlatform.Controllers;

[Route("api/course")]

public class CourseController : ApiController
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpPost]
    public IActionResult CreateCourse(CreateCourseRequest request)
    {
        ErrorOr<Course> requestToCourseResult = Course.Create(
            request.Name,
            request.Description,
            request.Duration,
            request.Disciplines
            );

        if (requestToCourseResult.IsError)
            return Problem(requestToCourseResult.Errors);

        var course = requestToCourseResult.Value;
        ErrorOr<Created> createCourseResult = _courseService.CreateCourse(course);

        return createCourseResult.Match(
            created => CreatedAtGetCourse(course),
            errors => Problem(errors));
    }


    [HttpGet("{id:guid}")]
    public IActionResult GetCourse(Guid id)
    {
        ErrorOr<Course> getCourseResult = _courseService.GetCourse(id);

        return getCourseResult.Match(
            course => Ok(MapCourseResponse(course)),
            errors => Problem(errors));

    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertCourse(Guid id, UpsertCourseRequest request)
    {
        var requestToCourseResult = Course.Create(
            request.Name,
            request.Description,
            request.Duration,
            request.Disciplines,
            id
            );

        if (requestToCourseResult.IsError)
            return Problem(requestToCourseResult.Errors);

        var course = requestToCourseResult.Value;
        ErrorOr<UpsertedCourse> upsertedCourseResult = _courseService.UpsertCourse(course);

        return upsertedCourseResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAtGetCourse(course) : NoContent(),
            errors => Problem(errors));
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteCourse(Guid id)
    {
        ErrorOr<Deleted> deleteCourseResult = _courseService.DeleteCourse(id);
        return deleteCourseResult.Match(
            deleted => NoContent(),
            errors => Problem(errors));

    }

    private static CourseResponse MapCourseResponse(Course course)
    {
        return new CourseResponse(
                    course.Id,
                    course.Name,
                    course.Description,
                    course.Duration,
                    course.Disciplines
                    );
    }

    private IActionResult CreatedAtGetCourse(Course course)
    {
        return CreatedAtAction(
            actionName: nameof(GetCourse),
            routeValues: new { id = course.Id },
            value: MapCourseResponse(course));
    }

}