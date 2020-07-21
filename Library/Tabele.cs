using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public partial class Database
    {
        public DbSet<Client> ClientList { get; set; }
        public DbSet<Angajat> AngajatList { get; set; }
        public DbSet<Abonament> AbonamentList { get; set; }
        public DbSet<TipAngajat> TipAngajatList { get; set; }
        public DbSet<Review> ReviewList { get; set; }
        public DbSet<Sala> SalaList { get; set; }
    }
}
