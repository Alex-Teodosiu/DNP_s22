using Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;

namespace WebApi.Controllers;


public class ImagesController: ControllerBase
{
    private readonly IDataAccess _dataAccess;

    
    public ImagesController(IDataAccess dataAccess)
    {
        this._dataAccess = dataAccess;
    }
    
    
    [HttpGet]
    [Route("getimages")]
    public async Task<ICollection<Image>> GetImages(string albumCreator, string topic)
    {
        var imgs = await _dataAccess.GetImagesAsync(albumCreator, topic);

        return imgs;
    }
}