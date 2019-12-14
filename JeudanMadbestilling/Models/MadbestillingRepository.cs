using System;
using System.Collections.Generic;
using System.Linq;
using JeudanMadbestilling.Data;
using Microsoft.EntityFrameworkCore;

namespace JeudanMadbestilling.Models
{
    public class MadbestillingRepository : IMadbestillingRepository
    {
        private readonly MvcMadMenuContext _context;
        public MadbestillingRepository(MvcMadMenuContext context)
        {
            this._context = context;
        }

        public void Delete(int madbestillingsId)
        {
            _context.Madbestillings.Remove(this.Get(madbestillingsId));
            _context.SaveChanges();
        }

        public List<Madbestillings> Get()
        {
            
            return _context.Madbestillings.ToList();
        }

        public Madbestillings Get(int madbestillingsId)
        {
            return _context.Madbestillings.Find(madbestillingsId);
        }

        public void Save(Madbestillings m)
        {
            if (m.MadbestillingId == 0)
            {
                _context.Madbestillings.Add(m);
            }
            else
            {
                _context.Madbestillings.Update(m);
            }

            _context.SaveChanges();
        }
    }
}
