# Learning Platform WebAPI

The Learning Platform WebAPI is an ASP.NET Core Web API application that provides functionality for managing courses in a learning platform. It follows a RESTful architecture and uses the MVC (Model-View-Controller) pattern.

## Models

### Course (LearningPlatform/Models/Course.cs)

This class represents a course in the learning platform. It has properties such as Id, Name, Description, Duration, and Disciplines. It also defines various constants for validating the course data, such as minimum and maximum lengths for the name, description, and disciplines.

## Contracts

### CourseResponse (LearningPlatform.Contracts/LearningPlatform/CourseResponse.cs)

A record type representing the response for a course.

### CreateCourseRequest (LearningPlatform.Contracts/LearningPlatform/CreateCourseRequest.cs)

A record type representing the request for creating a new course.

### UpsertCourseRequest (LearningPlatform.Contracts/LearningPlatform/UpsertCourseRequest.cs)

A record type representing the request for updating an existing course or creating a new one.

## Controllers

### CourseController (LearningPlatform/Controllers/CourseController.cs)

This controller handles the HTTP requests related to courses. It has the following actions:

- **CreateCourse**: Creates a new course.
- **GetCourse**: Retrieves a course by its ID.
- **UpsertCourse**: Updates an existing course or creates a new one.
- **DeleteCourse**: Deletes a course by its ID.

## Services

### ICourseService (LearningPlatform/Services/Courses/ICourseService.cs)

This interface defines the contract for the course service, which includes methods for creating, retrieving, updating, and deleting courses.

The project also uses the ErrorOr library for handling errors and the Microsoft.AspNetCore.Mvc namespace for working with ASP.NET Core MVC.

Note: The provided code is incomplete, and there are missing parts, such as the implementation of the CourseService class and the data storage mechanism (e.g., a database or in-memory storage). Additionally, there are no tests or configuration files included in the provided context.

# Get Started

To get started with the Learning Platform WebAPI, follow these steps:

## Prerequisites

- .NET 6.0 SDK installed on your machine.

## Setup

1. Clone the repository:

```bash
git clone https://github.com/hectorlutero/learning-platform.git
```

2. Navigate to the project directory:

```bash
cd learning-platform/LearningPlatform
```

3. Restore the NuGet packages:

```bash
dotnet restore
```

4. Configure the application settings (e.g., database connection string) in the `appsettings.json` file.

5. Apply any pending database migrations:

```bash
dotnet ef database update
```

## Running the Application

To run the application, use the following command:

```bash
dotnet run --project ./LearningPlatform.csproj
```

This will start the web server, and the API will be accessible at http://localhost:5223/api.

## API Routes

### CourseController

- `POST /api/course`: Creates a new course.
- `GET /api/course/{id:guid}`: Retrieves a course by its ID.
- `PUT /api/course/{id:guid}`: Updates an existing course or creates a new one.
- `DELETE /api/course/{id:guid}`: Deletes a course by its ID.

### ApiController

- `IActionResult Problem(List<Error> errors)`: Handles error responses.

## Contributing

If you'd like to contribute to the Learning Platform WebAPI, please follow the guidelines in the CONTRIBUTING.md file.

## License

This project is licensed under the MIT License.
