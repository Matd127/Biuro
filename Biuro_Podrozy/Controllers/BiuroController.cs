using Biuro_Podrozy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biuro_Podrozy.Controllers
{
    public class BiuroController : Controller
    {
        //Strony
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logowanie()
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

        public IActionResult BiuroList()
        {
            return View("BiuroList", repository.Data);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            BiuroItem editedItem = rep.Find(id);
            return View("EditForm", editedItem);
        }

        //Repo

        public IDataRepository repository;
        public ICrudDataRepository rep;
        public BiuroController(IDataRepository repository, ICrudDataRepository rep)
        {
            this.repository = repository;
            this.rep = rep;
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
