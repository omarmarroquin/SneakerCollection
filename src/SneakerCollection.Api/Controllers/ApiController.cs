using System.Security.Claims;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SneakerCollection.Api.Controllers;

[ApiController]
[Authorize]
public class ApiController : ControllerBase
{
  protected Guid? GetUserId()
  {
    var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
    return !string.IsNullOrEmpty(userId) ? Guid.Parse(userId) : null;
  }

  protected IActionResult Problem(List<Error> errors)
  {
    if (errors.Count is 0)
    {
      return Problem();
    }

    if (errors.All(error => error.Type == ErrorType.Validation))
    {
      return ValidationProblem(errors);
    }

    return Problem(errors[0]);
  }

  private IActionResult Problem(Error error)
  {
    var statusCode = error.Type switch
    {
      ErrorType.Conflict => StatusCodes.Status409Conflict,
      ErrorType.Validation => StatusCodes.Status400BadRequest,
      ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
      ErrorType.NotFound => StatusCodes.Status404NotFound,
      _ => StatusCodes.Status500InternalServerError
    };
    return Problem(statusCode: statusCode, title: error.Description);
  }

  private IActionResult ValidationProblem(List<Error> errors)
  {
    var modelStateDictionary = new ModelStateDictionary();

    foreach (var error in errors)
    {
      modelStateDictionary.AddModelError(
        error.Code,
        error.Description);
    }

    return ValidationProblem(modelStateDictionary);
  }
}