using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string UserSurname { get; set; }

        [StringLength(50)]
        public string UserMail { get; set; }

        [StringLength(50)]
        public  string UserPassword { get; set; }

        public int AuthorityID { get; set; }
        public virtual Authority Authority { get; set; }

        public int AccountID { get; set; }
        public virtual Account Account { get; set; }

        [StringLength(50)]
        public string TCNumber { get; set; }

        public bool State { get; set; }

        public ICollection<Sold> Sold { get; set; }
        public ICollection<Sell> Sell { get; set; }

    }
}
