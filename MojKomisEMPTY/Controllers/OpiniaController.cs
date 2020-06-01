using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MojKomisEMPTY.Models;

namespace MojKomisEMPTY.Controllers
{
    [Authorize]
    public class OpiniaController : Controller
    {
        IOpiniaRepository _opiniaRepository;
        public OpiniaController(IOpiniaRepository opiniaRepository)
        {
            _opiniaRepository = opiniaRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Opinia opinia)
        {
            if (ModelState.IsValid)
            {
                _opiniaRepository.DodajOpinie(opinia);
                return RedirectToAction("OpiniaWyslana");
            }
            else return View(opinia);
        }
        public IActionResult OpiniaWyslana()
        {
            return View();
        }
    }
}