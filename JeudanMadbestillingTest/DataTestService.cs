using System;
using System.Collections.Generic;
using System.Text;
using JeudanMadbestilling;
using JeudanMadbestilling.Models;
using JeudanMadbestilling.Data;
using JeudanMadbestilling.Controllers;
using Microsoft.EntityFrameworkCore;

namespace JeudanMadbestillingTest
{
    class DataTestService
    {
        public static List<MadMenu> GetTestMadmenu()
        {
            var sessions = new List<MadMenu>();
            sessions.Add(new MadMenu()
            {
                MenuId = 1,
                Menu = "Burger"
            });
            sessions.Add(new MadMenu()
            {
                MenuId = 2,
                Menu = "Fisk"
            });
            return sessions;
        }

        public DataTestService()
        {
        }

        public static List<Madbestillings> GetTestMadbestilling()
        {
            var sessions = new List<Madbestillings>();

            sessions.Add(new Madbestillings()
            {
                MadbestillingId = 1,
                MenuTekst = "Burger"


            });
            sessions.Add(new Madbestillings()
            {
                MadbestillingId = 1,
                MenuTekst = "Fisk"
            });
            return sessions;
        }
        
        public int Add(int a, int b)
        {
            return a + b;
        }
        
        
        public static IMadbestillingRepository GetInMemoryRepo() //This helper function creates a new AnimalRepository using In-Memory Database which we can use to test repo functions
        {
            DbContextOptions<MvcMadMenuContext> options;
            var builder = new DbContextOptionsBuilder<MvcMadMenuContext>();
            builder.UseInMemoryDatabase("testDB");
            options = builder.Options;
            MvcMadMenuContext mvcMadMenuContextTest = new MvcMadMenuContext(options);
            mvcMadMenuContextTest.Database.EnsureDeleted();
            mvcMadMenuContextTest.Database.EnsureCreated();

            return new MadbestillingRepository(mvcMadMenuContextTest);
        }
    }
}