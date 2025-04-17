using APPPlay.settings;

namespace APPPlay.Services
{
    public class GamesService : IGamesService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _ImagePath;
        public GamesService(AppDbContext context,IWebHostEnvironment webHostEnvironment )
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _ImagePath = $"{_webHostEnvironment.WebRootPath}{filesettings.ImagePath}";   
        }
        public async Task Create(CreateGameViewModel model)
        {
            var CoverName = await SaveCover(model.Cover);

            Game game = new Game()
            {
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Cover = CoverName,
                Devices = model.SelectDevices.Select(DE => new GameDevice { DeviceId = DE }).ToList(),
            };
            _context.Add(game) ;
            _context.SaveChanges();
            #region
            //GameDevice gameDevice = new GameDevice();
            //var d = model.SelectDevices.Select(DE => new GameDevice { DeviceId = DE }).ToList();
            //foreach (var device in d)
            //{
            //    gameDevice.DeviceId = device.DeviceId;
            //    gameDevice.GameId = game.Id;
            //    _context.GameDevices.Add(gameDevice);
            //    await _context.SaveChangesAsync();
            //}
            #endregion

        }
        private async Task<string> SaveCover(IFormFile photo)
        {
            var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(photo.FileName)}";
            var path = Path.Combine(_ImagePath, CoverName);

            using var stream = File.Create(path);
            await photo.CopyToAsync(stream);
            return CoverName ;
        }

        public IEnumerable<Game> GetAll()
        {
            return _context.Games.AsNoTracking()
                .Include(x=>x.Categories)
                .Include(x=>x.Devices)
                .ThenInclude(x=>x.Devices).ToList();
        }

        public Game? GetById(int id)
        {
            return _context.Games.Include(x => x.Categories)
                .Include(x=>x.Devices)
                .ThenInclude(x => x.Devices)
                .AsNoTracking().FirstOrDefault(x=>x.Id == id);
        }

        public async Task<Game?> Edit(EditGameViewModel model)
        {
            var game = _context.Games.Include(x=>x.Devices).SingleOrDefault(x => x.Id == model.Id);
            var NewCover = model.Cover != null;
            var oldCover = game!.Cover;
            if (game == null)
                return null;
            game.Description = model.Description;
            game.CategoryId = model.CategoryId;
            game.Name = model.Name;
            game.Devices = model.SelectDevices.Select(x => new GameDevice { DeviceId = x }).ToList();
            if(NewCover)
            {
                game.Cover =await SaveCover(model.Cover!);
            }

            int ER = _context.SaveChanges();
            if (ER > 0) 
            {
                if(NewCover)
                {
                    var cover = Path.Combine(_ImagePath, oldCover);
                    File.Delete(cover);
                }
                return game;
            }
            else 
            {
                var cover = Path.Combine(_ImagePath, game.Cover);
                File.Delete(cover);
                return null;
            }
        }

        public bool Delete(int id)
        {
            var isv = false;
            var game = _context.Games.Find(id);

            if (game == null)
                return isv;
            
            _context.Remove(game!);
            var effectiveRows = _context.SaveChanges();
            if (effectiveRows > 0) {
                isv = true;
                var cover = Path.Combine(_ImagePath,game.Cover);
                File.Delete(cover);
            }
            return isv;
        }
    }
}
