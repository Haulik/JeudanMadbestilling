using System;
using System.Collections.Generic;
using System.Text;
using JeudanMadbestilling;
using JeudanMadbestilling.Models;
using JeudanMadbestilling.Data;
using JeudanMadbestilling.Controllers;

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
    }
}