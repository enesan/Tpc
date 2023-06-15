using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.WebUI.Pages.Shared;
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

    [HttpPost]
    [Consumes("application/json")]
    public async Task<ActionResult<CardDto>> Create([FromBody]CardDto dto)
    {
        await _service.CreateAsync(dto);

        return Ok();
    }
}