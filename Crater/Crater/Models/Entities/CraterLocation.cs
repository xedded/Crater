using System;
using System.Collections.Generic;

namespace Crater.Models.Entities
{
    public partial class CraterLocation
    {
        public CraterLocation()
        {
            CraterDetails = new HashSet<CraterDetails>();
        }

        public int LocationId { get; set; }
        public string Location { get; set; }

        public ICollection<CraterDetails> CraterDetails { get; set; }
    }
}
