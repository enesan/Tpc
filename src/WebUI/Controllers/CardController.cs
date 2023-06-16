using System.Diagnostics;
using System.Numerics;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.WebUI.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

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

    [HttpPost("upload")]
    public async Task<ActionResult> Upload(IFormFile file)
    {
        await _service.SendJsonAsync(file);
        
        // byte[] buffer = new byte[file.Length];
        // await using var sr = file.OpenReadStream();
        // await sr.ReadAsync(buffer);
        // string result = Encoding.ASCII.GetString(buffer);
        // StringBuilder sb = new (result);
        // sb = sb.Replace(" ", "");
        // sb = sb.Replace("\r\n", "");
        // result = sb.ToString();
        

        return Ok();
    }
    
    
}