using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SneakerCollection.Api.Controllers;

public class ErrorsController : ControllerBase
{
  [ApiExplorerSettings(IgnoreApi = true)]
  [Route("/error")]
  public IActionResult Error() => Problem();
}