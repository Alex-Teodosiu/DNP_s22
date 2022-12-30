using System.Net.Mime;
using Entities;

namespace WebApi.Data;

public interface IDataAccess
{
    Task<Album> AddAlbumAsync(Album album);
    Task<ICollection<string>> GetAlbumTitlesAsync();
    Task AddImageToAlbumAsync(Image img, string albumTitle);
    Task<ICollection<Image>> GetImagesAsync(string albumCreator, string topic);
}