using CleanArchitecture.Application.Common.Models;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface ICardService
{
    Task<CardDto> GetAsync(int id);
    Task<CardDto> CreateAsync(CardDto dto);
    Task UploadFileAsync(IFormFile file);
}