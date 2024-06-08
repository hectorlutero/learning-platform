namespace LearningPlatform.Contracts.LearningPlatform;

public record CourseResponse(
    Guid Id,
    string Name,
    string Description,
    int Duration,
    List<string> Disciplines
);