using System.Text.Json;
using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;

namespace WebApi.Controllers;

public class AlbumsController: ControllerBase   
{
    private readonly IDataAccess _dataAccess;

    
    public AlbumsController(IDataAccess dataAccess)
   {
       this._dataAccess = dataAccess;
   }
   
    [HttpPost]
    [Route("addalbum")]
   public async Task<ActionResult<Album>> CreateAlbum([FromBody] Album album)
   {
       var result = await _dataAccess.AddAlbumAsync(album);

       return result;
   }

   [HttpGet]
   [Route("gettitles")]
   public async Task<ActionResult<ICollection<string>>> GetTitles()
   {
       var titles = await _dataAccess.GetAlbumTitlesAsync();

       return Ok(titles);
   }
   
   [HttpPost]
   [Route("addimagetoalbum")]
   public async Task<ActionResult> AddImageToAlbumAsync(Image img, string albumTitle)
   {
       await _dataAccess.AddImageToAlbumAsync(img, albumTitle);
       return Ok(img);
   }
   


}