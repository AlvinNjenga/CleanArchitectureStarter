using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<Artists>> RetrieveMostActiveArtistAsync();
        Task<Artists> InsertArtistAsync(Artists artist);
    }
}