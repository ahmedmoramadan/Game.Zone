namespace APPPlay.Models
{
    public class Device:BaseEntity
    {
        public string Name { get; set; }
        [MaxLength(100)]
        public string Icon { get; set; }
        public ICollection<GameDevice> Games { get; set; } 

    }
}
