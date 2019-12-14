using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JeudanMadbestilling.Data;
using JeudanMadbestilling.Models;
using Microsoft.AspNetCore.Authorization;
using JeudanMadbestilling.Models.ViewModels;
using Microsoft.Data.SqlClient;

namespace JeudanMadbestilling.Controllers
{
    [Authorize]
    public class MadbestillingsController : Controller
    {
        private readonly IMadbestillingRepository madbestillingRepository;
        private readonly IMadmenuRepository madmenuRepository;
     

        public MadbestillingsController(IMadbestillingRepository madbestillingRepo, IMadmenuRepository madmenuRepo)
        {
            
            this.madbestillingRepository = madbestillingRepo;
            this.madmenuRepository = madmenuRepo;
        }


        // GET: Madbestillings/MineBestillinger
        public IActionResult MineBestillinger()
        {

            List<Madbestillings> madbestillings = this.madbestillingRepository.Get();

            return View(madbestillings.ToList());
        }

        // GET: Madbestillings
        public IActionResult Index()
        {

           List<Madbestillings> madbestillings = this.madbestillingRepository.Get();

            return View(madbestillings.ToList());
        }

        // GET: Madbestillings/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            Madbestillings madbestillings = madbestillingRepository.Get(id);
            MadmenuBestillingVM vm = ViewModelCreator.createMadmenuBestillingVM(madmenuRepository);
            vm.Madbestillings = madbestillings;

            return View(vm);
        }

        // GET: Madbestillings/Create
        public IActionResult Create()
        {
           
            return View(ViewModelCreator.createMadmenuBestillingVM(madmenuRepository));
        }

        [HttpPost]
        public IActionResult Create(MadmenuBestillingVM vm)
        {
            if (ModelState.IsValid) {

                madbestillingRepository.Save(vm.Madbestillings);
                
                return Redirect ("/MadMenu/bestilling");
            }
            
            return View(ViewModelCreator.createMadmenuBestillingVM(madmenuRepository));

        }

        // GET: Madbestillings/Edit/5
        public IActionResult Edit(int id)
        {
            var Madbestillings = madbestillingRepository.Get(id);
            if (Madbestillings == null)
            {
                return NotFound();
            }
            return View(Madbestillings);
            // Create an edit view
            // Look up cat object from catId in the database
            // Show an edit view to the user, displaying the cat object

        }

        // POST: MadMenu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Edit(Madbestillings m)
        {
            if (ModelState.IsValid)
            {
                madbestillingRepository.Save(m);
                // Save it to the database
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Madbestillings/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var madbestillings = madbestillingRepository.Get((int)id);
            if (madbestillings == null)
            {
                return NotFound();
            }

            return View(madbestillings);
        }

        // POST: Madbestillings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            madbestillingRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        private bool MadbestillingExists(int id)
        {
            // unit test
            return false;
        }
    }
}
