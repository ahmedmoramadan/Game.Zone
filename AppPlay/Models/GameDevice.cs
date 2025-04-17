namespace APPPlay.Models
{
    public class GameDevice
    {
        public int DeviceId { get; set; }
        public int GameId { get; set; }
        public Game Games { get; set; }
        public Device Devices { get; set; }
    }
}
