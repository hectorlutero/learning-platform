using ErrorOr;
using LearningPlatform.ServicesErrors;

namespace LearningPlatform.Models;

public class Course
{
    public const int MinNameLength = 3;
    public const int MaxNameLength = 50;

    public const int MaxDisciplinesLength = 10;

    public const int MinDuration = 1;
    public const int MaxDuration = 320;

    public const int MinDescriptionLength = 10;
    public const int MaxDescriptionLength = 500;

    public const int MinDisciplines = 1;



    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public int Duration { get; }
    public List<string> Disciplines { get; }

    private Course(
        Guid id,
        string name,
        string description,
        int duration,
        List<string> disciplines
    )
    {
        Id = id;
        Name = name;
        Description = description;
        Duration = duration;
        Disciplines = disciplines;
    }

    public static ErrorOr<Course> Create(
        string name,
        string description,
        int duration,
        List<string> disciplines,
        Guid? id = null
    )
    {
        List<Error> errors = new();


        if (name.Length is < MinNameLength or > MaxNameLength)
            errors.Add(Errors.Course.InvalidName);

        if (description.Length is < MinDescriptionLength or > MaxDescriptionLength)
            errors.Add(Errors.Course.InvalidDescription);

        if (duration is < MinDuration or > MaxDuration)
            errors.Add(Errors.Course.InvalidDuration);

        if (disciplines.Count > MaxDisciplinesLength)
            errors.Add(Errors.Course.InvalidDisciplines);

        if (disciplines.Count < MinDisciplines)
            errors.Add(Errors.Course.InvalidDisciplines);

        if (errors.Count > 0)
            return errors;


        var course = new Course(
            id ?? Guid.NewGuid(),
            name,
            description,
            duration,
            disciplines
        );
        return course;
    }

}