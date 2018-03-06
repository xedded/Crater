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



    }
}
