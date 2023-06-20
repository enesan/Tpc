using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Tpc;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.Tpc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;


namespace CleanArchitecture.Infrastructure.Services;

public class CardService : ICardService
{
    private ITpcDbContext _context;

    public CardService(ITpcDbContext context)
    {
        _context = context;
    }

    public async Task<CardDto> GetAsync(int id)
    {
        var model = await _context.Cards.FirstOrDefaultAsync(x => x.Id == id);

        var result = new CardDto() { Id = id, File = model.File };

        return result;
    }

    public async Task<CardDto> CreateAsync(CardDto dto)
    {
        const int defaultId = 1;
        var previousModelId = _context.Cards.Any() ? _context.Cards.Max(x => x.Id) : defaultId;

        var entity = new Card() { Id = previousModelId, File = dto.File };

        await _context.Cards.AddAsync(entity);
        await _context.SaveChangesAsync(CancellationToken.None);
        return dto;
    }

    public async Task UploadFileAsync(IFormFile file)
    {
        string result = await GetJsonFromFile(file);

        const int defaultId = 0;
        const int idOffset = 1;
        var newId = (_context.Cards.Any() ? _context.Cards.Max(x => x.Id) : defaultId) + idOffset;

        //   var entity = new Card() { Id = newId, File = result) };

        // await _context.Cards.AddAsync(entity);
        await _context.SaveChangesAsync(CancellationToken.None);
    }

    public async Task CreateFromEntities(IFormFile file)
    {
        string result = await GetJsonFromFile(file);
        
        var newCard = result.
    }

    private async Task<string> GetJsonFromFile(IFormFile file)
    {
        byte[] buffer = new byte[file.Length];
        await using var sr = file.OpenReadStream();
        await sr.ReadAsync(buffer);
        string result = Encoding.UTF8.GetString(buffer);
        StringBuilder sb = new (result);
        sb = sb.Replace(" ", "");
        sb = sb.Replace("\r\n", "");
        return sb.ToString();
    }
    
    
}