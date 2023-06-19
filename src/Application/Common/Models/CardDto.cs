using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Models;

public class CardDto
{
    public int Id { get; set; }
    public CardFile File { get; set; }
    
}