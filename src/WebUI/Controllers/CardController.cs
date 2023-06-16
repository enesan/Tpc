using System.Diagnostics;
using System.Numerics;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.WebUI.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace CleanArchitecture.WebUI.Controllers;

public class CardController : ApiControllerBase
{
    private ICardService _service;
    private const string contentType = "application/json";

    public CardController(ICardService service)
    {
        _service = service;
    }

    // исправить, чтобы добавлял расширение файла при скачивании
    [HttpGet("{id}")]
    public async Task<FileContentResult> Get(int id)
    {
        var model = await _service.GetAsync(id);
        byte[] data = Encoding.UTF8.GetBytes(model.Test);
        string fileName = "data_" + model.Id + ".jsonb";

        return File(data, contentType, fileName);
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
        await _service.UploadFileAsync(file);
        return Ok();
    }
}