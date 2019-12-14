using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using JeudanMadbestilling.Models;

namespace JeudanMadbestilling.Models.ViewModels
{
    public class ViewModelCreator
    {

        public static MadmenuBestillingVM createMadmenuBestillingVM(IMadmenuRepository madmenuRepository)
        {
            return new MadmenuBestillingVM()
            {
                Madbestillings = new Madbestillings(),
                MenuselectList = new SelectList(madmenuRepository.Get(), "MenuId", "MenuId"),
                MadMenu = new MadMenu()
               
            };
        
        }

        public ViewModelCreator()
        {
        }
    }
}
