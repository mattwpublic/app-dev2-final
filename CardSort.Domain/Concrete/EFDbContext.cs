using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardSort.Domain.Entities;
using System.Data.Entity;

namespace CardSort.Domain.Concrete
{
    internal class EFDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
    }
}
