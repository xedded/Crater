using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crater.Models.ViewModels
{
    public class IndexInfoVM
    {
        public string CraterName { get; set; }
        public string CraterLocation { get; set; }
        public double Diameter { get; set; }
        public double Age { get; set; }
        public string Type { get; set; }
    }
}
