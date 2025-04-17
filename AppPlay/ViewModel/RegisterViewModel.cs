namespace APPPlay.ViewModel
{
    public class RegisterViewModel
    {
        public string Name { get; set; }  

        [DataType(DataType.Password)]
        public string password { get; set; } 

        [DataType(DataType.Password)]
        [Compare("password")]
        public string confirm { get; set; }
        
        public string Address { get; set; } 
    }
}
