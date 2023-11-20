using Microsoft.AspNetCore.Mvc;
using SneakerCollection.Api.Controllers;
using SneakerCollection.Application.Authentication.Commands.Register;
using SneakerCollection.Contracts.Sneaker;
using ErrorOr;
using SneakerCollection.Application.Services;
using MediatR;

[Route("sneakers")]
public class SneakersController : ApiController
{
  private readonly ISender _mediator;

  public SneakersController(ISender mediator)
  {
    _mediator = mediator;
  }

  private static ListSneakersResponse MapListSneakersResult(ListSneakersResult listSneakersResult)
  {
    return new ListSneakersResponse(
      listSneakersResult.Sneakers.ConvertAll(sneaker => new SneakerResponse(
        sneaker.Id.Value,
        sneaker.UserId.Value,
        sneaker.Name,
        sneaker.Brand,
        sneaker.Price,
        sneaker.Size,
        sneaker.Year,
        sneaker.Rate,
        sneaker.CreatedAt,
        sneaker.UpdatedAt
      ))
    );
  }

  [HttpGet]
  public async Task<IActionResult> ListSneakers(
    [FromQuery] ListSneakersRequest request)
  {
    if (GetUserId() is not Guid userId)
      return Problem();

    var query = new ListSneakersQuery(userId, request.FilterValue, request.SortBy);
    ErrorOr<ListSneakersResult> listSneakersResult = await _mediator.Send(query);

    return listSneakersResult.Match(
      listSneakersResult => Ok(MapListSneakersResult(listSneakersResult)),
      errors => Problem(errors)
    );
  }

  [HttpPut("{id}")]
  public IActionResult Update()
  {
    return Ok();
  }

  [HttpDelete("{id}")]
  public IActionResult Delete()
  {
    return Ok();
  }

  [HttpPost]
  public IActionResult Create()
  {
    return Ok();
  }
}
