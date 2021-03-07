using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MunicipalityTaxesManager.Models
{
    public class TaxSchedule
    {
        public int MunicipalityId { get; set; }
        public TaxPeriod Period { get; set; }
        public int TypeId { get; set; }
        public double Rate { get; set; }
    }
}
