using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.Controllers;


public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem(
            title: "An error occurred while processing your request.",
            statusCode: 500,
            detail: "Please try again later."
        );
    }
}