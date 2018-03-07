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
            var crater = await repository.GetAllPeopleAsyncIndexIndexVM();

            return View(crater);
        }

        [HttpGet]
        public IActionResult Info(string name)
        {
            var crater = repository.GetCraterByName(name);
            return PartialView("_InfoBox", new IndexInfoVM
            {
                Age = crater.Age,
                CraterName = crater.CraterName,
                Diameter = crater.Diameter,
                Type = crater.Type,
                CraterLocation = crater.CraterLocation

            });
        }


        public IActionResult Map()
        {
            return PartialView("_MapBox", new InfoMapVM[]{

                });
        }
    }
}
