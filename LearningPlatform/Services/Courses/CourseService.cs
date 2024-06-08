using ErrorOr;
using LearningPlatform.Models;
using LearningPlatform.ServicesErrors;

namespace LearningPlatform.Services.Courses;

public class CourseService : ICourseService
{
    private static readonly Dictionary<Guid, Course> _courses = new();
    public ErrorOr<Created> CreateCourse(Course course)
    {
        _courses.Add(course.Id, course);

        return Result.Created;
    }

    public ErrorOr<Course> GetCourse(Guid id)
    {
        if (!_courses.TryGetValue(id, out var course))
            return Errors.Course.NotFound;

        return course;
    }

    public ErrorOr<UpsertedCourse> UpsertCourse(Course course)
    {
        var IsNewlyCreated = !_courses.ContainsKey(course.Id);
        _courses[course.Id] = course;

        return new UpsertedCourse(IsNewlyCreated);
    }

    public ErrorOr<Deleted> DeleteCourse(Guid id)
    {
        _courses.Remove(id);

        return Result.Deleted;

    }

}