using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JeudanMadbestilling.Models.ViewModels
{
    public class MadbestillingVM
    {
        public int MadbestillingId { get; set; }
        public int MenuId { get; set; }
        public MadMenu Menu { get; set; }
        [DataType(DataType.Date)]
        public DateTime MenuDato { get; set; }
        public String MenuTekst { get; set; }
        public int AntalBestillinger { get; set; }
        public String BestilingsType { get; set; }
        [DataType(DataType.Date)]
        public DateTime BestillingsDateTime { get; set; }
        public String Bruger { get; set; }

        public MadbestillingVM()
        {

        }
    }
}
