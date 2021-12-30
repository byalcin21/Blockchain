using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Authority
    {
        [Key]
        public int AuthorityID { get; set; }

        public bool AuthorityLevel { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
