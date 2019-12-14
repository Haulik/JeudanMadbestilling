using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JeudanMadbestilling.Models.ViewModels
{
    public class JeudanVM
    {
        
        public IEnumerable<JeudanMadbestilling.Models.MadMenu> Locations { get; set; }
        public JeudanMadbestilling.Models.Madbestillings Location { get; set; }

        public JeudanVM()
        {
        }
    }
}
