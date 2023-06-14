using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

public class CardController : ApiControllerBase
{
    private ICardService _service;

    public CardController(ICardService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CardDto>> Get(int id)
    {
        return new JsonResult(await _service.GetAsync(id));
    }
}