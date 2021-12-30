using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Balance
    {
        [Key]
        public int BalanceID { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }

        public float BalanceValue { get; set; }

        public bool State { get; set; }
    }
}
