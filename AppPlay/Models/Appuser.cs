using Microsoft.AspNetCore.Identity;

namespace APPPlay.Models
{
    public class Appuser:IdentityUser
    {
        public string Address { get; set; }
    }
}
