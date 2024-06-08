using ErrorOr;
using LearningPlatform.Models;

namespace LearningPlatform.Services.Courses;

public interface ICourseService
{
    ErrorOr<Created> CreateCourse(Course course);

    ErrorOr<Course> GetCourse(Guid id);

    ErrorOr<UpsertedCourse> UpsertCourse(Course course);

    ErrorOr<Deleted> DeleteCourse(Guid id);
}