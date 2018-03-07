using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crater.Models;
using Crater.Models.Entities;
using Crater.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Crater.Controllers
{
    public class IndexController : Controller
    {
        public readonly CraterRepository repository;

        public IndexController(CraterRepository repository)
        {
            this.repository = repository;
        }


        // GET: /<controller>/
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var crater = await repository.GetAllCraterAsyncIndexIndexVM();

            return View(crater);
        }

        [HttpGet]
        [Route("/index/info/{name}")]
        public IActionResult Info(string name)
        {
            var newCrater = repository.GetCraterByName(name);
            
            return PartialView("_InfoBox", newCrater);
        }

        [HttpGet]
        [Route("/index/map/{name}")]
        public IActionResult Map(string name)
        {
            var crater = repository.GetCraterForMap(name);

            return PartialView("_MapBox", crater);
        }
    }
}
