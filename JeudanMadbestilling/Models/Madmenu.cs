using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JeudanMadbestilling.Models
{
    public class MadMenu
    {
        [Key]
        public int MenuId { get; set; }
        public String Menu { get; set; }
        public String Med_Hjem_Køkken { get; set; }

        [DataType(DataType.Date)]
        public DateTime Dato { get; set; }
        public int Uge { get; set; }
        public String UgeNavn { get; set; }
        public String MenuStatus { get; set; }

        public List<Madbestillings> Madbestillinger { get; set; }

        public MadMenu()
        {

        }

    }
}
