using Microsoft.AspNetCore.Authorization;

namespace APPPlay.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoryService _categoryServices;
        private readonly IDevicesService _devicesServices;
        private readonly IGamesService _gamesService;
        public GamesController(IDevicesService devicesServices, ICategoryService categoryServices, IGamesService gamesService)
        {
            _categoryServices = categoryServices;
            _devicesServices = devicesServices;
            _gamesService = gamesService;
        }
        [Authorize(Roles ="Admin,user")]
        public IActionResult Index()
        {
            var games = _gamesService.GetAll();
            return View(games);
        }
        [Authorize(Roles ="user,Admin")]
        public IActionResult Details(int id)
        {
            var game = _gamesService.GetById(id);
            if (game == null)
                return NotFound();
            return View(game);
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult CreateGame()
        {
            CreateGameViewModel gameViewModel = new CreateGameViewModel();
            gameViewModel.Devices = _devicesServices.GetDevices();
            gameViewModel.Categories = _categoryServices.GetCategories();
            return View(gameViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGame(CreateGameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                CreateGameViewModel gameViewModel = new CreateGameViewModel();
                gameViewModel.Devices = _devicesServices.GetDevices();
                gameViewModel.Categories = _categoryServices.GetCategories();
                return View(gameViewModel);
            }
            await _gamesService.Create(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult Edit(int id)
        {
            var game = _gamesService.GetById(id);
            if (game is null)
                return NotFound();
            EditGameViewModel gameViewModel = new EditGameViewModel();
            gameViewModel.Id = id;
            gameViewModel.Name = game.Name;
            gameViewModel.Description = game.Description;
            gameViewModel.SelectDevices = game.Devices.Select(x => x.DeviceId).ToList();
            gameViewModel.CategoryId = game.CategoryId;
            gameViewModel.Devices = _devicesServices.GetDevices().ToList();
            gameViewModel.Categories = _categoryServices.GetCategories().ToList();
            gameViewModel.Curuntcover = game.Cover;
            return View(gameViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                EditGameViewModel gameViewModel = new EditGameViewModel();
                gameViewModel.Devices = _devicesServices.GetDevices();
                gameViewModel.Categories = _categoryServices.GetCategories();
                return View(gameViewModel);
            }
            var game = await _gamesService.Edit(model);
            if (game is null)
                return BadRequest();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Delete(int id)
        {
           var  isdl = _gamesService.Delete(id);
            return isdl ? RedirectToAction(nameof(Index)):BadRequest();
        }
    }
}

