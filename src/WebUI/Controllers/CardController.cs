using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

public class CardController
{
    private ICardService _service;

    public CardController(ICardService service)
    {
        _service = service;
    }

    // [HttpGet("card/{id:int}")]
    // public async Task<ActionResult<int>> Get(int id)
    // {
    //     var result = (await _service.GetAsync(id)).Id;
    //     return new JsonResult(result);
    // }
}