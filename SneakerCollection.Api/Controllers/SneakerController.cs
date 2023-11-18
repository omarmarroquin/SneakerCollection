using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("senaker")]
public class SneakerController : ControllerBase
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
