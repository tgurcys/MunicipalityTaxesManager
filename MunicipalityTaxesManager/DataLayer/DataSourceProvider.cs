using MunicipalityTaxesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MunicipalityTaxesManager.DataLayer
{
    public class DataSourceProvider
    {
        public string CultureCode { get; set; }
        public List<Municipality> Municipalities { get; set; } = new List<Municipality>();
        public List<TaxSchedule> TaxSchedules { get; set; } = new List<TaxSchedule>();

        public void SerializeMunicipalities()
        {
            SerializeProvider.SerializeXml(Municipalities, nameof(Municipalities) + ".xml");
        }

        public object DeserializeMunicipalities()
        {
            return SerializeProvider.DeserializeXml(Municipalities.GetType(), nameof(Municipalities) + ".xml");
        }

        public void SerializeTaxSchedules()
        {
            SerializeProvider.SerializeXml(TaxSchedules, nameof(TaxSchedules) + ".xml");
        }

        public object DeserializeTaxSchedules()
        {
            return SerializeProvider.DeserializeXml(TaxSchedules.GetType(), nameof(TaxSchedules) + ".xml");
        }
    }
}
