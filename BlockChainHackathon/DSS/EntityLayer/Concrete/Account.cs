using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }

        public float Balance { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
