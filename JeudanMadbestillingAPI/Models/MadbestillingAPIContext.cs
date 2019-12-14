using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JeudanMadbestillingAPI.Models
{
    public class MadbestillingAPIContext : DbContext
    {
        public MadbestillingAPIContext(DbContextOptions<MadbestillingAPIContext> options)
            : base(options)
        {
        }

        public DbSet<JeudanMadbestilling.Models.Madbestillings> Madbestillings { get; set; }
    }
}
