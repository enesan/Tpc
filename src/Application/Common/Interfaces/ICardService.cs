using CleanArchitecture.Application.Common.Models;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface ICardService
{
    Task<CardDto> GetAsync(int id);
}