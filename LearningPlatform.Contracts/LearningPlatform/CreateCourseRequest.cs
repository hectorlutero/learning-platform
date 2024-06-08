namespace LearningPlatform.Contracts.LearningPlatform;

public record CreateCourseRequest(
    string Name,
    string Description,
    int Duration,
    List<string> Disciplines
);