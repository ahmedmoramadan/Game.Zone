namespace APPPlay.ViewModel
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
        public bool rememberme { get; set; }
    }
}
