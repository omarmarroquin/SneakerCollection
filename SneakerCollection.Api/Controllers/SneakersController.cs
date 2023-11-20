using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SneakerCollection.Application.Sneakers.Commands.AddSneaker;
using SneakerCollection.Application.Sneakers.Common;
using SneakerCollection.Application.Sneakers.Queries.ListSneakers;
using SneakerCollection.Contracts.Sneaker.AddSneaker;
using SneakerCollection.Contracts.Sneaker.ListSneakers;

namespace SneakerCollection.Api.Controllers;

[Route("sneakers")]
public class SneakersController : ApiController
{
  private readonly ISender _mediator;

  public SneakersController(ISender mediator)
  {
    _mediator = mediator;
  }
  private static AddSneakerResponse MapAddSneakerResult(AddSneakerResult addSneakerResult)
  {
    return new AddSneakerResponse(
      addSneakerResult.Sneaker.Id.Value,
      addSneakerResult.Sneaker.UserId,
      addSneakerResult.Sneaker.Name,
      addSneakerResult.Sneaker.Brand,
      addSneakerResult.Sneaker.Price,
      addSneakerResult.Sneaker.Size,
      addSneakerResult.Sneaker.Year,
      addSneakerResult.Sneaker.Rate,
      addSneakerResult.Sneaker.CreatedAt,
      addSneakerResult.Sneaker.UpdatedAt);
  }

  private static ListSneakersResponse MapListSneakersResult(ListSneakersResult listSneakersResult)
  {
    return new ListSneakersResponse(
      listSneakersResult.Sneakers.ConvertAll(sneaker => new SneakerResponse(
        sneaker.Id.Value,
        sneaker.UserId,
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

    var listSneakersQuery = new ListSneakersQuery(userId, request.FilterValue, request.SortBy);
    ErrorOr<ListSneakersResult> listSneakersResult = await _mediator.Send(listSneakersQuery);

    return listSneakersResult.Match(
      listSneakersResult => Ok(MapListSneakersResult(listSneakersResult)),
      errors => Problem(errors)
    );
  }

  [HttpPost]
  public async Task<IActionResult> Add(AddSneakerRequest request)
  {
    if (GetUserId() is not Guid userId)
      return Problem();

    var addSneakerQuery = new AddSneakerCommand(
      userId,
      request.Name,
      request.Brand,
      request.Price,
      request.Size,
      request.Year,
      request.Rate);
    ErrorOr<AddSneakerResult> addSneakersResult = await _mediator.Send(addSneakerQuery);

    return addSneakersResult.Match(
      addSneakersResult => Ok(MapAddSneakerResult(addSneakersResult)),
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
}
