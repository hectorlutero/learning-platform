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

