using ErrorOr;

namespace LearningPlatform.ServicesErrors;

public static class Errors
{
    public static class Course
    {
        public static Error InvalidName => Error.Validation(
            code: "Course.InvalidName",
            description: $"Course name must be at least {Models.Course.MinNameLength} characters long and at most {Models.Course.MaxNameLength} characters."
        );

        public static Error InvalidDescription => Error.Validation(
            code: "Course.InvalidDescription",
            description: $"Course description must be at least {Models.Course.MinDescriptionLength} characters long and at most {Models.Course.MaxDescriptionLength} characters."
        );

        public static Error InvalidDuration => Error.Validation(
            code: "Course.InvalidDuration",
            description: $"Course duration must be at least {Models.Course.MinDuration} and at most {Models.Course.MaxDuration}."
        );

        public static Error InvalidDisciplines => Error.Validation(
            code: "Course.InvalidDisciplines",
            description: $"Course must have at least {Models.Course.MinDisciplines} disciplines."
        );

        public static Error DuplicateCourse => Error.Conflict(
            code: "Course.DuplicateCourse",
            description: "Course already exists."
        );

        public static Error NotFound => Error.NotFound(
            code: "Course.NotFound",
            description: "Course not found."
        );
    }
}