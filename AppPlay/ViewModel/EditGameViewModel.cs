using APPPlay.settings;
using APPPlay.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace APPPlay.ViewModel
{
    public class EditGameViewModel :MainGameViewModel
    {
       public int Id { get; set; }
        public string? Curuntcover { get; set; }
        [AllowedExtention(filesettings.AllowExtentions),
            MixSize(filesettings.maxSizeByByets)]
        public IFormFile? Cover { get; set; }
    }
}
