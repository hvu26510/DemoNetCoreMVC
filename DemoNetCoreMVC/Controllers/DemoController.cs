using Microsoft.AspNetCore.Mvc;

namespace DemoNetCoreMVC.Controllers
{
    public class DemoController : Controller
    {
        private IConfiguration _configuration;

        public DemoController (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            string valueCustom = _configuration["CustomKey"];
            return View();
        }
    }
}
