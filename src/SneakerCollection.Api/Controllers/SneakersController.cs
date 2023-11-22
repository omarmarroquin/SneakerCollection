using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SneakerCollection.Application.Sneakers.Commands.AddSneaker;
using SneakerCollection.Application.Sneakers.Commands.DeleteSneaker;
using SneakerCollection.Application.Sneakers.Commands.UpdateSneaker;
using SneakerCollection.Application.Sneakers.Common;
using SneakerCollection.Application.Sneakers.Queries.ListSneakers;
using SneakerCollection.Contracts.Sneaker.AddSneaker;
using SneakerCollection.Contracts.Sneaker.ListSneakers;
using SneakerCollection.Contracts.Sneaker.UpdateSneaker;

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

  private static UpdateSneakerResponse MapUpdateSneakerResult(UpdateSneakerResult updateSneakerResult)
  {
    return new UpdateSneakerResponse(
      updateSneakerResult.Sneaker.Id.Value,
      updateSneakerResult.Sneaker.UserId,
      updateSneakerResult.Sneaker.Name,
      updateSneakerResult.Sneaker.Brand,
      updateSneakerResult.Sneaker.Price,
      updateSneakerResult.Sneaker.Size,
      updateSneakerResult.Sneaker.Year,
      updateSneakerResult.Sneaker.Rate,
      updateSneakerResult.Sneaker.CreatedAt,
      updateSneakerResult.Sneaker.UpdatedAt
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

    var addSneakerCommand = new AddSneakerCommand(
      userId,
      request.Name,
      request.Brand,
      request.Price,
      request.Size,
      request.Year,
      request.Rate);
    ErrorOr<AddSneakerResult> addSneakerResult = await _mediator.Send(addSneakerCommand);

    return addSneakerResult.Match(
      addSneakerResult => Ok(MapAddSneakerResult(addSneakerResult)),
      errors => Problem(errors)
    );
  }

  [HttpPut("{sneakerId}")]
  public async Task<IActionResult> Update(UpdateSneakerRequest body, [FromRoute] UpdateSneakerRouteParamsRequest routeParams)
  {
    if (GetUserId() is not Guid userId)
      return Problem();

    var updateSneakerCommand = new UpdateSneakerCommand(
      userId,
      routeParams.SneakerId,
      body.Name,
      body.Brand,
      body.Price,
      body.Size,
      body.Year,
      body.Rate
    );
    ErrorOr<UpdateSneakerResult> updateSneakerResult = await _mediator.Send(updateSneakerCommand);

    return updateSneakerResult.Match(
      updateSneakerResult => Ok(MapUpdateSneakerResult(updateSneakerResult)),
      errors => Problem(errors));
  }

  [HttpDelete("{sneakerId}")]
  public async Task<IActionResult> Delete([FromRoute] DeleteSneakerRequest request)
  {
    if (GetUserId() is not Guid userId)
      return Problem();

    var deleteSneakerCommand = new DeleteSneakerCommand(userId, request.SneakerId);
    ErrorOr<DeleteSneakerResult> deleteSneakerResult = await _mediator.Send(deleteSneakerCommand);

    return deleteSneakerResult.Match(
      deleteSneakerResult => Ok(new DeleteSneakerResponse(
        deleteSneakerResult.SneakerId.Value)),
      errors => Problem(errors)
    );
  }
}
