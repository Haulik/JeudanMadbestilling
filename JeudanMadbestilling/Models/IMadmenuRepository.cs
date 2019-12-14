using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeudanMadbestilling.Models
{
    public interface IMadmenuRepository
    {
        public void Save(MadMenu m);

        public List<MadMenu> Get();
        public MadMenu Get(int madmenuId);
        public void Delete(int madmenuId);
    }
}
