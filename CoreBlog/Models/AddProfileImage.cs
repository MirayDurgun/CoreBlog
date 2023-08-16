using Microsoft.AspNetCore.Http;

namespace CoreBlog.Models
{
    public class AddProfileImage
    {
        //Entityde değişiklik yapmak istemedik, Ekleme işlemini buradan gerçekleştireceğiz bu sebebple model içindeki claas içinden yapıyoruz. Image Propunda değişiklik sağlayacağız
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public IFormFile WriterImage { get; set; } //dosyadan veri/ dosya değeri seçebilmek için kullanılır
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public string WriterPassword2 { get; set; }
        public bool WriterStatus { get; set; }
    }
}
