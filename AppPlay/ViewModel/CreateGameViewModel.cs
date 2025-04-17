using APPPlay.settings;
using APPPlay.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace APPPlay.ViewModel
{
    public class CreateGameViewModel :MainGameViewModel
    {
        [AllowedExtention(filesettings.AllowExtentions),
           MixSize(filesettings.maxSizeByByets)]
        public IFormFile Cover { get; set; } = default!;
    }
}
