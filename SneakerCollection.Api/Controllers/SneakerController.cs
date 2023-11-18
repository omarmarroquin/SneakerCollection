using Microsoft.AspNetCore.Mvc;
using SneakerCollection.Api.Controllers;

[Route("sneaker")]
public class SneakerController : ApiController
{
    [HttpGet("collection")]
    public IActionResult GetList()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetById()
    {
        return Ok();
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
