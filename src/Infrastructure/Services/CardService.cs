using System.Net.Http.Headers;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;


namespace CleanArchitecture.Infrastructure.Services;

public class CardService : ICardService
{
    private IApplicationDbContext _context;

    public CardService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CardDto> GetAsync(int id)
    {
        var model = await _context.Cards.FirstOrDefaultAsync(x => x.Id == id);

       
        var result = new CardDto() { Id = id, Name = model.Name, Test = model.Test};

        return result;
    }

    public async Task<CardDto> CreateAsync(CardDto dto)
    {
        const int defaultId = 1;
        var previousModelId = _context.Cards.Any() ? _context.Cards.Max(x => x.Id) : defaultId;

        var entity = new Card() { Id = previousModelId, Name = dto.Name, Test = dto.Test };

        await _context.Cards.AddAsync(entity);
        await _context.SaveChangesAsync(CancellationToken.None);
        return dto;
    }

    public async Task SendJsonAsync(string file)
    {
        using var form = new MultipartFormDataContent();
        using var fileContent = new ByteArrayContent(await File.ReadAllBytesAsync(file));
        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
        
        form.Add(fileContent, "formfile", "filename");

        HttpClient httpClient = new () { BaseAddress = new Uri("https://localhost:44447") };

        var response = await httpClient.PostAsync("/File/Upload", form);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();

    }
    
    
}