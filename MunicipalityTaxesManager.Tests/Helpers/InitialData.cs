using MunicipalityTaxesManager.DataLayer;
using MunicipalityTaxesManager.Enums;
using MunicipalityTaxesManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MunicipalityTaxesManager.Tests.Helpers
{
    public class InitialData
    {
        public InitialData()
        {
            LoadMunicipalitiesTestData();
            LoadTaxSchedulesTestData();
        }

        public string DataFolder { get; set; } = "DataTest";
        public string LogFolder { get; set; } = "LogTest";

        public DataSourceProvider DataSource { get; set; } = new DataSourceProvider();

        public void DeleteTestFolders()
        {
            SerializeProvider.DeleteFolderIfExist();
        }

        private void LoadMunicipalitiesTestData()
        {
            DataSource.Municipalities.Add(new Municipality { Id = 1, Name = "Municipality1" });
            DataSource.Municipalities.Add(new Municipality { Id = 2, Name = "Municipality2" });
            DataSource.Municipalities.Add(new Municipality { Id = 3, Name = "Municipality3" });
        }

        private void LoadTaxSchedulesTestData()
        {
            TaxPeriodProvider taxPeriodProvider = new TaxPeriodProvider();

            DataSource.TaxSchedules.Add(new TaxSchedule { MunicipalityId = 1, TypeId = (int)Tax.Yearly, Period = taxPeriodProvider.CreateNewPeriod(new DateTime(2020, 1, 1), (int)Tax.Yearly), Rate = 0.2 });
            DataSource.TaxSchedules.Add(new TaxSchedule { MunicipalityId = 1, TypeId = (int)Tax.Monthly, Period = taxPeriodProvider.CreateNewPeriod(new DateTime(2020, 5, 2), (int)Tax.Monthly), Rate = 0.4 });
            DataSource.TaxSchedules.Add(new TaxSchedule { MunicipalityId = 1, TypeId = (int)Tax.Daily, Period = taxPeriodProvider.CreateNewPeriod(new DateTime(2020, 1, 1), (int)Tax.Daily), Rate = 0.1 });
            DataSource.TaxSchedules.Add(new TaxSchedule { MunicipalityId = 1, TypeId = (int)Tax.Daily, Period = taxPeriodProvider.CreateNewPeriod(new DateTime(2020, 12, 25), (int)Tax.Daily), Rate = 0.1 });

        }
    }
}