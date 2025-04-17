using Microsoft.AspNetCore.Mvc.Rendering;

namespace APPPlay.ViewModel
{
    public class MainGameViewModel
    {
        [MinLength(3)]
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "El Category")]
        public int CategoryId { get; set; } = default;
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        [Display(Name = "El Support Devices")]
        public List<int> SelectDevices { get; set; } = default!;
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;
      
    }
}
