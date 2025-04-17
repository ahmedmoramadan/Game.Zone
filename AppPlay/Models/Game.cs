using System.ComponentModel.DataAnnotations.Schema;

namespace APPPlay.Models
{

    public class Game : BaseEntity
    {
        public string Name { get; set; }
        [MaxLength(2000)]
        public string Description { get; set; }
        [MaxLength(50)]
        public string Cover { get; set; }
        [ForeignKey(nameof(Categories))]
        public int CategoryId { get; set; }
        public Categorie Categories { get; set; }
        public ICollection<GameDevice> Devices { get; set; }
    }
}
