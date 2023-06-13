using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Services;

public class CardService : ICardService
{
    private IApplicationDbContext _context;

    public CardService(IApplicationDbContext context)
    {
        _context = _context;
    }

    public async Task<CardDto> GetAsync(int id)
    {
        var model = await _context.Cards.FirstOrDefaultAsync(x => x.Id == id);

        var result = new CardDto() { Id = id, Name = model.Name };

        return result;
    }
    
    
}