using AppMvc.Net.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMvc.Net.Controllers
{
    [Route("he-mat-troi/[action]")]
    public class PlanetController : Controller
    {
        private readonly PlanetService planetService;
        private readonly ILogger<PlanetController> logger;

        public PlanetController(PlanetService planetService, ILogger<PlanetController> logger)
        {
            this.planetService = planetService;
            this.logger = logger;
        }

        [Route("danh-sach-cac-hanh-tinh.html")]
        public IActionResult Index()
        {
            return View();
        }

        [BindProperty(SupportsGet = true, Name = "action")]
        public string Name { get; set; }

        public IActionResult Mercury()
        {
            var planet = planetService.Where(p => p.Name == Name).FirstOrDefault();

            return View("Detail", planet);
        }
        public IActionResult Venus()
        {
            var planet = planetService.Where(p => p.Name == Name).FirstOrDefault();

            return View("Detail", planet);
        }
        public IActionResult Earth()
        {
            var planet = planetService.Where(p => p.Name == Name).FirstOrDefault();

            return View("Detail", planet);
        }
        public IActionResult Mars()
        {
            var planet = planetService.Where(p => p.Name == Name).FirstOrDefault();

            return View("Detail", planet);
        }
        public IActionResult Jupiter()
        {
            var planet = planetService.Where(p => p.Name == Name).FirstOrDefault();

            return View("Detail", planet);
        }
        public IActionResult Saturn()
        {
            var planet = planetService.Where(p => p.Name == Name).FirstOrDefault();

            return View("Detail", planet);
        }
        public IActionResult Uranus()
        {
            var planet = planetService.Where(p => p.Name == Name).FirstOrDefault();

            return View("Detail", planet);
        }

        [Route("[controller]-[action].html")]
        public IActionResult Neptune()
        {
            var planet = planetService.Where(p => p.Name == Name).FirstOrDefault();

            return View("Detail", planet);
        }

        [Route("hanhtinh/{id:int}")]
        public IActionResult PlanetInfo(int id)
        {
            var planet = planetService.Where(p => p.Id == id).FirstOrDefault();

            return View("Detail", planet);
        }
    }
}
