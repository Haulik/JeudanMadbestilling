using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JeudanMadbestilling.Data;
using JeudanMadbestilling.Models;
using JeudanMadbestilling.Models.ViewModels;
using System.Dynamic;
using Microsoft.AspNetCore.Authorization;

namespace JeudanMadbestilling.Controllers
{
    [Authorize]
    public class MadMenuController : Controller
    {

        private readonly IMadmenuRepository madmenuRepository;
        private readonly IMadbestillingRepository madbestillingRepository;

        public MadMenuController(IMadbestillingRepository madbestillingRepo, IMadmenuRepository madmenuRepo)
        {
            
            this.madmenuRepository = madmenuRepo;
            this.madbestillingRepository = madbestillingRepo;

        }
        // GET: MadMenu
        public IActionResult Index()
        {
            List<MadMenu> madmenu = this.madmenuRepository.Get();

            return View(madmenu.ToList());
        }

        // GET: MadMenu/Bestilling
         public IActionResult Bestilling()
         {
            //DateTime.Today

            //List<MadMenu> madmenu = this.madmenuRepository.Get();
            MadmenuBestillingVM mymodel = new MadmenuBestillingVM();
            mymodel.MenuIE = this.madmenuRepository.Get();

            return View(mymodel);
        }

        // GET: MadMenu/HovedMenu
        public IActionResult HovedMenu()
        {
         
            List<MadMenu> madmenu = this.madmenuRepository.Get();

            return View(madmenu.ToList());
        }

        // GET: MadMenu/Info
        public IActionResult Info()
        {

            return View();
        }


        // GET: MadMenu/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            MadMenu madMenu = madmenuRepository.Get(id);
            MadmenuBestillingVM vm = ViewModelCreator.createMadmenuBestillingVM(madmenuRepository);
            vm.MadMenu = madMenu;

            return View(vm);
        }

        // GET: MadMenu/Create MANGELER NOGET HER! POST!
        [HttpGet]
        public IActionResult Create()
        {
            return View(ViewModelCreator.createMadmenuBestillingVM(madmenuRepository));
        }

        // POST: MadMenu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MenuId,Menu,Med_Hjem_Køkken,Dato,Uge,UgeNavn,MenuStatus")] MadMenu madMenu)
        {
            if (ModelState.IsValid)
            {

                madmenuRepository.Save(madMenu);

                return RedirectToAction(nameof(Index)); //Runs the action named Index in this controller
            }
            
            return View(madMenu);

        }

        // GET: MadMenu/Edit/5
        public IActionResult Edit(int id)
        {

            var madMenu = madmenuRepository.Get(id);
            if (madMenu == null)
            {
                return NotFound();
            }
            return View(madMenu);
            // Create an edit view
            // Look up cat object from catId in the database
            // Show an edit view to the user, displaying the cat object

        }

        // POST: MadMenu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Edit(MadMenu m)
        {
            if (ModelState.IsValid)
            {
                madmenuRepository.Save(m);
                // Save it to the database
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: MadMenu/Delete/5!
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var madmenu = madmenuRepository.Get((int)id);
            if (madmenu == null)
            {
                return NotFound();
            }

            return View(madmenu);
        }

        // POST: MadMenu/Delete/5!
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            madmenuRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private bool MadmenuExists(int id)
        {
            // unit test
            return false;
        }
    }
}
