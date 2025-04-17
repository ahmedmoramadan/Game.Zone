using System.Collections;

namespace APPPlay.Services
{
    public interface IGamesService
    {
        Task Create(CreateGameViewModel model);
        IEnumerable<Game> GetAll();
        Game? GetById(int id);
        Task<Game?> Edit(EditGameViewModel model);
        bool Delete(int id); 
    }
}
