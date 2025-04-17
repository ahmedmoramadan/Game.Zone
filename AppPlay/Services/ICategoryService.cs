using Microsoft.AspNetCore.Mvc.Rendering;

namespace APPPlay.Services
{
    public interface ICategoryService
    {
        IEnumerable<SelectListItem> GetCategories();
        void Updata(int id , Categorie categorie);
        IEnumerable<Categorie> getAll();
        Categorie get(int id);
        void Add(Categorie categorie);
        void Delete(int id);

    }
}
