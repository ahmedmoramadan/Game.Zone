using Microsoft.AspNetCore.Mvc.Rendering;

namespace APPPlay.Services
{
    public class DevicesServices : IDevicesService
    {
        private readonly AppDbContext _context;
        public DevicesServices(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetDevices()
        {
            return _context.Devices.Select(x=> new 
            SelectListItem { Value = x.Id.ToString() , Text = x.Name }).OrderBy(x => x.Text).AsNoTracking().ToList();
        }
    }
}
