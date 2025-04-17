namespace APPPlay.Models
{
    public class Categorie:BaseEntity
    {
         public string Name { get; set; }
         public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
