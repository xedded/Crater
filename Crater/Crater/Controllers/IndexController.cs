using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crater.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Crater.Controllers
{
    public class IndexController : Controller
    {
        // GET: /<controller>/
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Info()
        //{
        //    return Content("buuu");
        //}

        //ajax anrop till controller
        [HttpGet]
        //[Route("movie/moviebox/{idName}")]
        public IActionResult Info(string craterNameInputParameter)
        {
            // var crater = repository.GetCraterByName(craterName);

            return PartialView("_InfoBox", new IndexInfoVM
            {
                Age = 11,
                CraterLocation="sweden",
                CraterName="Dellen",
                Diameter=23,
                Type="Stone"
                
                // CraterName = crater.craternname;
                //MovieName = movie.MovieName,
                //MovieSum = movie.MovieSum

            });
        }


        public IActionResult Map()
        {
            return Content("buu2");
        }
    }
}
