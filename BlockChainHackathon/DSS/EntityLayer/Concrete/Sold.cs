using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Sold
    {
        [Key]
        public int SoldID { get; set; }

        public int SellID { get; set; }
        public virtual Sell Sell { get; set; }

        //Satın Alan Kullanıcı
        public int? UserID { get; set; }
        public virtual User User { get; set; }

        [StringLength(256)]
        public string PrevHash { get; set; }

        [StringLength(256)]
        public string LastHash { get; set; }
    }
}
