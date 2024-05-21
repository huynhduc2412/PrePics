using Microsoft.AspNetCore.Mvc;
using PrePics.Repositories;

namespace PrePics.Controllers
{
    public class DriveController : Controller
    {
        public async Task<IActionResult> Index()
        {

            // DriverHelper d = new DriverHelper("Credentials.json");
            //var res = await d.GetFilesAsync();
            // return View(res);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            DriverHelper d = new DriverHelper("Credentials.json");
            d.UploadFilesToDrive(file);
            //await d.GetFilesAsync();
            return View();
        }
    }
}
