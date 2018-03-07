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

        public async Task<InfoMapVM[]> GetAllCraterAsync()
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

        public async Task<IndexIndexVM[]> GetAllCraterAsyncIndexIndexVM()
        {

            return await context.CraterDetails
                .OrderBy(o => o.CraterName)
                .Select(o => new IndexIndexVM
                {
                    CraterName = o.CraterName
                })
                .ToArrayAsync();

        }

        public IndexInfoVM GetCraterByName(string name)
        {
            var crater = context.CraterDetails
                .OrderBy(o => o.CraterName)
                .Single(o => o.CraterName == name);
            return new IndexInfoVM
            {
                CraterName = crater.CraterName,
                Age = crater.Age,
                Diameter = crater.Diameter,
                Type = crater.CompositionType
            };

        }


        //public IndexInfoVM GetCraterByName(string name)
        //{
        //    var crater = context.CraterDetails.Single(c => c.CraterName == name);

        //    return new IndexInfoVM {
        //        CraterName = crater.CraterName,
        //        Age = crater.Age,
        //        Diameter = crater.Diameter,
        //        Type = crater.CompositionType
        //    };
        //}



    }
}
