using Microsoft.AspNetCore.Mvc.Rendering;

namespace APPPlay.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public Categorie get(int id)
        {
            Categorie categorie = _context.Categories.FirstOrDefault(c => c.Id == id)!;
            return categorie;
        }
        
        public IEnumerable<Categorie> getAll()
        {
            IEnumerable<Categorie> categories = _context.Categories.ToList();
            return categories;
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
            return _context.Categories.Select(x => new
            SelectListItem { Value = x.Id.ToString(), Text = x.Name }).OrderBy(x => x.Text).AsNoTracking().ToList();
        }

        public void Updata(int id, Categorie categorie)
        {
            var Old_C = get(id);
            Old_C.Name = categorie.Name;
            _context.SaveChanges();
        }
        public void Add(Categorie newCategorie)
        {
            _context.Categories.Add(newCategorie);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _context.Categories.Remove(item);
            }
            _context.SaveChanges();
        }
    }
}
