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
        public DbSet<Client> Clienti { get; set; }
    }
}
