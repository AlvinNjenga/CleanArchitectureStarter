using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces.Repositories
{
    public interface IAlbumRepository
    {
        Task<Albums> InsertAlbumAsync(Albums album);
        Task<IEnumerable<Albums>> RetrieveTopTenAlbumsAsync();
        Task<Albums> UpdateAlbumAsync(Albums album);
    }
}