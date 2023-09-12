namespace CoreBlog.Models
{
    public class UserUpdateViewModel
    {
        public string nameSurname { get; set; }
        public string mail { get; set; }
        public string userName { get; set; }
        public string imageUrl { get; set; }
        public string password{ get; set; }
        public bool ChangePassword { get; set; }
    }
}
