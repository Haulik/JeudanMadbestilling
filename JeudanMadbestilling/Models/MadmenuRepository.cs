using System;
using System.Collections.Generic;
using System.Linq;
using JeudanMadbestilling.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace JeudanMadbestilling.Models
{
    public class MadmenuRepository : IMadmenuRepository
    {

        private readonly MvcMadMenuContext _context;
        public MadmenuRepository(MvcMadMenuContext context)
        {
            this._context = context;
        }

        public void Delete(int madmenuId)
        {
            _context.Madmenu.Remove(this.Get(madmenuId));
            _context.SaveChanges();

        }

        public List<MadMenu> Get()
        {
            return _context.Madmenu.ToList();
        }

        public MadMenu Get(int madmenuId)
        {
            return _context.Madmenu.Find(madmenuId);
        }

        public void Save(MadMenu m)
        {
            if (m.MenuId == 0)
            {
                _context.Madmenu.Add(m);
            }
            else
            {
                _context.Madmenu.Update(m);
            }
            
            _context.SaveChanges();
        }
    }
}
