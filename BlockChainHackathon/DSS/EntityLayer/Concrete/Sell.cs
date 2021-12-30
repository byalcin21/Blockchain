using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace EntityLayer.Concrete
{
    public class Sell
    {
        [Key]
        public int SellID { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

        [StringLength(50)]
        public string ServerIP { get; set; }

        [StringLength(50)]
        public string StorageSize { get; set; }

        public float SellValue { get; set; }
    
        public DateTime SellTime { get; set; }

        public bool State { get; set; }
    
        public ICollection<Sold> Sold { get; set; }
    
    }
}
