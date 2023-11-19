using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SneakerCollection.Api.Controllers;

public class ErrorsController : ControllerBase
{
  [Route("/error")]
  public IActionResult Error() => Problem();
}