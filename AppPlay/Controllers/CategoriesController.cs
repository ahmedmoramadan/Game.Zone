using APPPlay.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APPPlay.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryServices;
        private readonly IDevicesService devicesServices;
        private readonly IGamesService _gamesService;
        public CategoriesController(ICategoryService categoryServices, IDevicesService devicesServices, IGamesService gamesService)
        {
            this.categoryServices = categoryServices;
            this.devicesServices = devicesServices;
            _gamesService = gamesService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowCategory()
        {

            return View(categoryServices.getAll());
        }
        [HttpGet]
        public IActionResult updataCategorie(int id)
        {
            var c = categoryServices.get(id);
            return View(c);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult updataCategorie(int id, Categorie categorie)
        {
            if (!ModelState.IsValid)
            {
                return View(categorie);
            }
            categoryServices.Updata(id, categorie);
            return RedirectToAction(nameof(ShowCategory));
        }
        public IActionResult AddCat()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCat(Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                categoryServices.Add(categorie);
                return RedirectToAction(nameof(ShowCategory));
            }
            return View(categorie);
        }
        public IActionResult DeleteCat(int id)
        {
            categoryServices.Delete(id);
            return RedirectToAction(nameof(ShowCategory));
        }
    }
}
