using System;
using System.Collections.Generic;

namespace Crater.Models.Entities
{
    public partial class CraterDetails
    {
        public string LocationId { get; set; }
        public string CraterName { get; set; }
        public string Diameter { get; set; }
        public string Age { get; set; }
        public string CompositionType { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int CraterId { get; set; }

        public CraterLocation Location { get; set; }
    }
}
