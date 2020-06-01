using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MojKomisEMPTY.Models;
using MojKomisEMPTY.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MojKomisEMPTY.Controllers
{
    public class HomeController : Controller
    {
        ISamochodRepository _samochodRepository;
        public HomeController(ISamochodRepository samochodRepository)
        {
            _samochodRepository = samochodRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var samochody = _samochodRepository.PobierzWszystkieSamochody().OrderBy(s => s.Marka);
            HomeVM homevm = new HomeVM
            {
                Samochody = samochody.ToList(),
                Tytul = "Przegląd samochodów"
            };
            
            return View(homevm);
        }

        public IActionResult Szczegoly(int id)
        {
            var samochod = _samochodRepository.PobierzSamochodOID(id);
            if (samochod == null)
                return NotFound();
            return View(samochod);
        }
    }
}
