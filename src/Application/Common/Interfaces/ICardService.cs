

using Microsoft.AspNetCore.Http;
using CleanArchitecture.Application.Common.Models.Tpc;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface ICardService
{
    Task<CardDto> GetAsync(int id);
    Task<CardDto> CreateAsync(CardDto dto);
    Task UploadFileAsync(IFormFile file);
}