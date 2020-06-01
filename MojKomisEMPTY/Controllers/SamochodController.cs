using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MojKomisEMPTY.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MojKomisEMPTY.Controllers
{
    public class SamochodController : Controller
    {
        private readonly ISamochodRepository _samochodRepository;
        public SamochodController(ISamochodRepository samochodRepository)
        {
            _samochodRepository = samochodRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {

            return View(_samochodRepository.PobierzWszystkieSamochody());
        }

        public IActionResult Details(int id)
        {
            return View(_samochodRepository.PobierzSamochodOID(id));

        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Samochod samochod)
        {
            if (ModelState.IsValid)
                _samochodRepository.DodajSamochod(samochod);
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
           var samochod=  _samochodRepository.PobierzSamochodOID(id);
            return View(samochod);

        }

        [HttpPost]
        public IActionResult Edit(Samochod samochod)
        {
            if (ModelState.IsValid)
                _samochodRepository.EdytujSamochod(samochod);
            return RedirectToAction("Index");

        }



        public IActionResult Delete(int id)
        {
            var samochod = _samochodRepository.PobierzSamochodOID(id);
            return View(samochod);

        }

        [HttpPost]
        public IActionResult Delete(Samochod samochod)
        {
            if (ModelState.IsValid)
                _samochodRepository.UsunSamochod(samochod);
            return RedirectToAction("Index");

        }

    }
}
