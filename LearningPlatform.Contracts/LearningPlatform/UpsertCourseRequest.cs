namespace LearningPlatform.Contracts.LearningPlatform;

public record UpsertCourseRequest(
    Guid Id,
    string Name,
    string Description,
    int Duration,
    List<string> Disciplines
);