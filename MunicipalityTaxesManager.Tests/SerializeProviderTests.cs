using Microsoft.VisualStudio.TestTools.UnitTesting;
using MunicipalityTaxesManager.DataLayer;
using MunicipalityTaxesManager.Models;
using MunicipalityTaxesManager.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MunicipalityTaxesManager.Tests
{
    [TestClass()]
    public class SerializeProviderTests
    {
        private InitialData _initialData;
        public SerializeProviderTests()
        {
            _initialData = new InitialData();
        }

        [TestMethod()]
        public void CreateFolderTest()
        {
            _initialData.DeleteTestFolders();
            SerializeProvider.CreateFolderIfNotExist();
            Assert.IsTrue(Directory.Exists(SerializeProvider.FolderPath));

            SerializeProvider.CreateFolderIfNotExist();
            Assert.IsTrue(Directory.Exists(SerializeProvider.FolderPath));
        }

        [TestMethod()]
        public void SerializeDeserializeMunicipalitiesTest()
        {
            var dataSource = new DataSourceProvider();
            dataSource.Municipalities = _initialData.DataSource.Municipalities;

            dataSource.SerializeMunicipalities();

            var deserialized = dataSource.DeserializeMunicipalities() as List<Municipality>;

            Assert.IsTrue(dataSource.Municipalities.Count == deserialized.Count);

            dataSource.Municipalities.Add(new Municipality { Id = 99, Name = "Test99" });

            dataSource.SerializeMunicipalities();
            deserialized = dataSource.DeserializeMunicipalities() as List<Municipality>;
            Assert.IsTrue(dataSource.Municipalities.Count == deserialized.Count);
        }

        [TestMethod()]
        public void SerializeDeserializeTaxSchedulesTest()
        {
            var dataSource = new DataSourceProvider();
            dataSource.TaxSchedules = _initialData.DataSource.TaxSchedules;

            dataSource.SerializeTaxSchedules();

            var deserialized = dataSource.DeserializeTaxSchedules() as List<TaxSchedule>;

            Assert.IsTrue(dataSource.TaxSchedules.Count == deserialized.Count);

            dataSource.TaxSchedules.Add(new TaxSchedule {  MunicipalityId = 1, Period = new TaxPeriod(), TypeId = 1, Rate = 0 });

            dataSource.SerializeTaxSchedules();
            deserialized = dataSource.DeserializeTaxSchedules() as List<TaxSchedule>;
            Assert.IsTrue(dataSource.TaxSchedules.Count == deserialized.Count);
        }
    }
}