using ImageServiceApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImageServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IPhotoService _photoService;
        private readonly ILogService _logService;
        public ImageController(IPhotoService photoService, ILogService logService)
        {
            _photoService = photoService;
            _logService = logService;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var file = Request.Form.Files.GetFile("file");
            if(file!=null && file.Length > 0)
            {
                string result = await _photoService.UploadImageAsync(new Dtos.PhotoCreationDto { File = file });
                await _logService.AddLogMessage(result,DateTime.Now);
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
