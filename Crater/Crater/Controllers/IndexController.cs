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
        private readonly CraterRepository repository;

        public IndexController(CraterRepository repository)
        {
            this.repository = repository;
        }

        // GET: /<controller>/
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Info(string craterInputParameter)
        {
             //var crater = repository.GetCraterByName(craterInputParameter);

            return PartialView("_InfoBox", new IndexInfoVM
            {
                
                CraterLocation = "Sweden",
                CraterName = "Dellen",
                Diameter = 23,
                Type = "Stone"

            });
        }


        public IActionResult Map()
        {
            return PartialView("_MapBox", new InfoMapVM
            {
                CraterName = "Dellen",
                Lat = "61.48",
                Lng = "16.48"

            });

        }
    }
}
