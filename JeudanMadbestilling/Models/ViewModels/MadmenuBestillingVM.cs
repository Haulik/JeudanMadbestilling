using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JeudanMadbestilling.Models.ViewModels
{
    public class MadmenuBestillingVM
    {
        public Madbestillings Madbestillings { get; set; }
        public MadMenu MadMenu { get; set; }
        public SelectList MenuselectList { get; set; }
        public IEnumerable<JeudanMadbestilling.Models.MadMenu> MenuIE { get; set; }

        public MadmenuBestillingVM()
        {
        }
         

         
    }
}
