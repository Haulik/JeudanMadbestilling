using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeudanMadbestilling.Models
{
    public interface IMadbestillingRepository
    {
        public void Save(Madbestillings m);

        public List<Madbestillings> Get();
        public Madbestillings Get(int madbestillingsId);
        public void Delete(int madbestillingsId);
    }
}
