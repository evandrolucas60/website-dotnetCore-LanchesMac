using LanchesMac.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LanchesMac.Areas.Admin.Controllers
{
    [Area ("Admin")]
    [Authorize(Roles ="Admin")]
    public class AdminImagesController : Controller
    {
        private readonly ConfigurationImages _myconfig;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminImagesController(IOptions<ConfigurationImages> myconfig, IWebHostEnvironment webHostEnvironment)
        {
            _myconfig = myconfig.Value;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
