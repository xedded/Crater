using Crater.Models.Entities;
using Crater.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crater.Models
{
    public class CraterRepository
    {

        private readonly CraterContext context;

        public CraterRepository(CraterContext context)
        {
            this.context = context;
        }

        public async Task<InfoMapVM[]> GetAllPeopleAsync()
        {

            return await context.CraterDetails
                .OrderBy(o => o.CraterName)
                .Select(o => new InfoMapVM
                {
                    CraterName = o.CraterName,
                    Lng = o.Longitude,
                    Lat = o.Latitude
                })
                .ToArrayAsync();

        }

        public async Task<IndexIndexVM[]> GetAllPeopleAsyncIndexIndexVM()
        {

            return await context.CraterDetails
                .OrderBy(o => o.CraterName)
                .Select(o => new IndexIndexVM
                {
                    CraterName = o.CraterName
                })
                .ToArrayAsync();

        }

        public dynamic GetAllCraters(string craterName)
        {

            var q = context
                .CraterDetails
                .Select(c => new IndexInfoVM
                {
                    CraterName = c.CraterName,
                 //   CraterLocation = GetCorrectLocation(c.Location),//c.Location, //hur gör man detta, fel signatur
                    Diameter = c.Diameter,
                    Age = c.Age,
                    Type = c.CompositionType,
                    
                    
                });

            return q;
        }

        //private string GetCorrectLocation(dynamic location)
        //{
        //    var r = context
        //        .CraterLocation
        //        .Select(p=>p.Location)
        //        {

        //        }
        //    return r;
        //}

        public CraterDetails GetCraterById(int id)
        {
            return context.CraterDetails.Find(name.ToLower());
        }



    }
}
