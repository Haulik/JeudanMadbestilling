using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JeudanMadbestilling.Models;
using JeudanMadbestilling.Models.ViewModels;


namespace JeudanMadbestilling.Data
{
    public class MvcMadMenuContext : DbContext
    {
        public MvcMadMenuContext(Microsoft.EntityFrameworkCore.DbContextOptions<MvcMadMenuContext> options) : base(options)
        {
        }

        public DbSet<MadMenu> Madmenu { get; set; }
        public DbSet<Madbestillings> Madbestillings { get; set; }
        
        
    }
}
