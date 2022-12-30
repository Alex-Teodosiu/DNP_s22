using Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data;

public class DataAccess : IDataAccess
{
    private readonly AlbumContext _albumContext;

    public DataAccess(AlbumContext albumContext)
    { 
        _albumContext = albumContext;
    }

    public async Task<Album> AddAlbumAsync(Album album)
    {
        await _albumContext.Albums.AddAsync(album);
        await _albumContext.SaveChangesAsync();
        return album;
    }

    public async Task<ICollection<string>> GetAlbumTitlesAsync()
    {
        return await _albumContext.Albums.Select(a => a.Title).ToListAsync();
    }

    public async Task AddImageToAlbumAsync(Image img, string albumTitle)
    {
        await _albumContext.Images.AddAsync(img);
        var album = await _albumContext.Albums
            .Include(a => a.Title)
            .FirstAsync(a => a.Title.Equals(albumTitle));
        album.Images.Add(img);
        _albumContext.Update(album);
        await _albumContext.SaveChangesAsync();

    }

    public async Task<ICollection<Image>> GetImagesAsync(string albumCreator, string topic)
    {
        return await _albumContext.Images.ToListAsync();
    }
}