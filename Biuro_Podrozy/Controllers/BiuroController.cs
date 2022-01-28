using Biuro_Podrozy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biuro_Podrozy.Controllers
{
    public class BiuroController : Controller
    {
        //Repo

        public IDataRepository repository;
        public ICrudDataRepository rep;
        public ICrudBookRepository repbook;
        public BiuroController(
            IDataRepository repository, 
            ICrudDataRepository rep, 
            ICrudBookRepository repbook)
        {
            this.repbook = repbook;
            this.repository = repository;
            this.rep = rep;
        }

        //Strony dla wszystkich
        public IActionResult Logowanie()
        {
            return View();
        }

        public IActionResult BiuroList()
        {
            var repo = repository.Data
                .Include(b => b.DepartureCities)
                .Include(C => C.Photos)
                .Include(z => z.Books)
                .ToList();
            return View("BiuroList", repo);
        }

        public IActionResult BiuroListAdmin()
        {
            var repo = repository.Data
                .Include(b => b.DepartureCities)
                .Include(C => C.Photos)
                .Include(z => z.Books)
                .ToList();
            return View("BiuroListAdmin", repo);
        }
        public IActionResult BookInfo(int id)
        {
            BiuroItem item = rep.Find(id);
            return View("BookInfo", item);
        }

        public IActionResult BookForm(int id)
        {
            BiuroItem item = rep.Find(id);
            return View("BookForm", item);
        }


        //Rezerwacja biletu
        [HttpPost]
        public IActionResult BookF(Book model, int id)
        {
            BiuroItem item = rep.Find(id);
            var repo = repository.Data
                .Include(b => b.DepartureCities)
                .Include(C => C.Photos)
                .Include(z => z.Books)
                .ToList();

            if (ModelState.IsValid)
            {
                model = repbook.Save(model);
                return View("BookSuccess", model);
            }    
            else
                return View("BookForm", item);
        }


        public IActionResult BookSuccess()
        {
            return View();
        }

        //Strony dla adminów
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }


        [Authorize]
        public IActionResult AddForm()
        {
            return View();
        }

        [Authorize]
        public IActionResult Panel()
        {
            return View();
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            BiuroItem editedItem = rep.Find(id);
            return View("EditForm", editedItem);
        }

        //Akcje
        [Authorize]
        public IActionResult Add(BiuroItem item)
        {
            if (ModelState.IsValid)
            {
                item = rep.Save(item);
                return View("ConfirmBiuroItem", item);
            }
            return View("AddForm");
        }

        [Authorize]
        public IActionResult Delete(BiuroItem item)
        {
            rep.Delete(item.Id);
            return View("BiuroList", repository.Data);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(BiuroItem item)
        {
            int id = item.Id;
            BiuroItem originItem = rep.Find(id);
            originItem.TravelPlace = item.TravelPlace;
            originItem.Price = item.Price;
            originItem.Seats = item.Seats;
            originItem.TravelDate = item.TravelDate;
            rep.Update(originItem);

            return View("BiuroList", repository.Data);
        }

    }
}
