using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; } //ilişkili tablolarda silme işlemi problem olduğundan,
                                                 //bir categoryi silmek yerine aktif ya da pasif duruma
                                                 //getireceğiz bu nedenle CategoryStatus kullanıyoruz.
                                                 //bool iki tane ihtimalin olduğu yerlerde kullanılır evet ya da hayır gibi.

        public List<Blog> Blogs { get; set; }
        //icollection veya listle bağlantı tanımlanabilir

        //İKİSİ ARASINDAKİ FARK
        //List<int> liste = new List<int>();
        /*Böyle bir kullanım senaryosunda sen list yerine arraylist kullanma kararı aldığında,
          sadece list yerine arraylist yazmak işi kurtaramayabiliyor.Sen list yerine arraylist yazdığın zaman
         nesnenin fonksiyonları değişiyor ve sen değişen bu fonksiyonlarıda kodunu da değiştirmen gerekiyor. 
        ICollection<int> liste = new List<int>();
        Eğer şu şekilde tanımlama yapıp kodlamanı yaparsan, artık list sınıfına bağımlı olmaktan kurtuluyorsun
        ve ileride list yerine "= new ArrayList<int>()" yazdığın zamanda kodun sıkıntısız bir şekilde çalışmaya devam ediyor.*/

    }
}
