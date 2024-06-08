/// <summary>
/// The main entry point for the LearningPlatform web application.
/// This code sets up the web application, configures the services, and runs the application.
/// </summary>
using LearningPlatform.Services.Courses;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<ICourseService, CourseService>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();

    app.MapControllers();
    app.Run();
}

