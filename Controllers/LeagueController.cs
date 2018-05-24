using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using The_Dojo_League.Factory;
using The_Dojo_League.Models;

namespace The_Dojo_League.Controllers
{
    public class LeagueController : Controller
    {
        private NinjaFactory _ninjafactory;
        private DojoFactory _dojofactory;
        public LeagueController()
        {
            _ninjafactory = new NinjaFactory();
            _dojofactory = new DojoFactory();
        }
        [HttpGet]
        [Route("/ninjas")]
        public IActionResult Ninjas()
        {
            ViewBag.allNinjas = _ninjafactory.GetAllNinjas();
            ViewBag.allDojos = _dojofactory.GetAllDojos();
            return View("Ninjas");
        }
        [Route("/ninja/{id}")]
        public IActionResult Ninja(int id)
        {
            ViewBag.Ninja = _ninjafactory.FindNinja(id);
            return View("Ninja");
        }
        [Route("/dojos")]
        public IActionResult Dojos()
        {
            ViewBag.allDojos = _dojofactory.GetAllDojos();
            return View("Dojos");
        }
        [Route("/dojo/{id}")]
        public IActionResult Dojo(int id)
        {
            ViewBag.Dojo = _dojofactory.FindDojo(id);
            ViewBag.rogueNinjas = _ninjafactory.RogueNinjas();
            return View("Dojo");
        }
        [HttpPost]
        [Route("/Ninja/create")]
        public IActionResult NinjaCreate(Ninja model)
        {
            if (ModelState.IsValid)
            {
                Ninja newNinja = new Ninja
                {
                    Name = model.Name,
                    Level = model.Level,
                    Description = model.Description,
                    dojo_id = model.dojo_id,
                };
                _ninjafactory.AddNewNinja(newNinja);
                return RedirectToAction("Ninjas");
            }
            ViewBag.allNinjas = _ninjafactory.GetAllNinjas();
            ViewBag.allDojos = _dojofactory.GetAllDojos();
            return View("Ninjas");
        }
        [Route("/Dojo/create")]
        public IActionResult DojoCreate(Dojo model)
        {
            if (ModelState.IsValid)
            {
                Dojo newDojo = new Dojo
                {
                    Name = model.Name,
                    Location = model.Location,
                    Info = model.Info,
                };
                _dojofactory.AddNewDojo(newDojo);
                return RedirectToAction("Dojos");
            }
            ViewBag.allDojos = _dojofactory.GetAllDojos();
            return View("Dojos");
        }
        [Route("Dojo/{dojoid}/Banish/{ninjaid}")]
        public IActionResult Banish(int dojoId, int ninjaId)
        {
            _dojofactory.Banish(ninjaId);
            return RedirectToAction("Dojo", new { id = dojoId });
        }
        [Route("Dojo/{dojoid}/Recruit/{ninjaid}")]
        public IActionResult Recruit(int dojoId, int ninjaId)
        {
            _dojofactory.Recruit(dojoId, ninjaId);
            return RedirectToAction("Dojo", new { id = dojoId });
        }
    }
}
