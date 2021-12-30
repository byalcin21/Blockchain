using System.Data.Entity;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Conrete
{
    //Burada tanımlanan isimler SQL tablo ismi olarak işlem görecek.
    public class Context : DbContext
    {
        //About: Sınıf ismi >> Abouts: Tabloda yer alacak isim
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Authority> Authoritys { get; set; }
        public DbSet<Sell> Sells { get; set; }
        public DbSet<Sold> Solds { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Balance> Balances { get; set; }
    }
}
