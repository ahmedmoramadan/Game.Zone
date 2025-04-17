using Microsoft.AspNetCore.Mvc.Rendering;

namespace APPPlay.Services
{
    public interface IDevicesService
    {
        IEnumerable<SelectListItem> GetDevices();
    }
}
