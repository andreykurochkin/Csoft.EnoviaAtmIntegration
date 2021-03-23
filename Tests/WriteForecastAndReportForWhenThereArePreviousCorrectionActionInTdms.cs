using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain.Tests
{

    class WriteForecastAndReportForWhenThereArePreviousCorrectionActionInTdms 
        : ITdmsTest
    {
        private readonly TDMSApplication app;
        private IEnumerable<ICa> ecaItemsExpectedToBeUpdated;

        public WriteForecastAndReportForWhenThereArePreviousCorrectionActionInTdms(
            TDMSApplication application)
        {
            this.app = application;
        }

        public IEnumerable<ICa> EcaItemsExpectedToBeUpdated
        {
            get
            {
                if (ecaItemsExpectedToBeUpdated == null) 
                    ecaItemsExpectedToBeUpdated = GetEcaItemsExpectedToBeUpdated();
                return ecaItemsExpectedToBeUpdated;
            }
        }

        public void Execute()
        {
            try
            {
                var cachedDateTime = DateTime.Now;
                //var folder = origin.AcquireLayoutFolder(origin.AcquireRootFolder(), cachedDateTime);
                //origin.SaveJsonToFile(cachedDateTime);
                SaveForecastToFile(cachedDateTime);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SaveForecastToFile(DateTime dateTime)
        {
            throw new NotImplementedException();
            //var folder = origin.AcquireLayoutFolder(origin.AcquireRootFolder(), dateTime);
            //var fileName = "forecast.txt";
            //var file = File.CreateText($"{folder.FullName}\\{fileName}");
            //file.WriteLine("Forecast");
            //file.WriteLine($"expected number of correction actions to be updated: {EcaItemsExpectedToBeUpdated.Count()}");
            //EcaItemsExpectedToBeUpdated.ToList().ForEach(eca => file.WriteLine($"{eca.Id}"));
            //file.WriteLine($"expected number of Ids with files: {GetEcaItemsExpectedToBeUpdatedWithFiles().Count()}");
            //GetEcaItemsExpectedToBeUpdatedWithFiles().ToList().ForEach(eca => file.WriteLine(eca.Id));
            //file.Close();

            //fileName = "allEca.txt";
            //file = File.CreateText($"{folder.FullName}\\{fileName}");
            //var json = new EnoviaHttpClient().GetResponse("json");
            //file.Write(json);
            //file.Close();

            //fileName = "NoTdmsDateEca.txt";
            //file = File.CreateText($"{folder.FullName}\\{fileName}");
            //json = new ServiceEnoviaHttpClient(
            //        new NoSentToTdmsRequestFactory(
            //            new AllEcaRequestFactory()))
            //    .GetResponse("json");
            //file.Write(json);
            //file.Close();
        }

        private IEnumerable<ICa> GetEcaItemsExpectedToBeUpdated()
        {
            UpdateContext client = new(app);

            var ids = new List<string>() {
                "27736.38003.3456.53205",
                "27736.38003.64960.12362",
                "27736.38003.11352.58051",
                "27736.38003.49712.5693",
                "27736.38003.51928.23798",
                "27736.38003.52721.14724",
                "27736.38003.41408.48878",
                "27736.38003.8940.57787",
                "27736.38003.38848.14821",
                "27736.38003.9440.30115",
                "27736.38003.24352.53538",
                "27736.38003.33376.23320",
                "27736.38003.55432.39910",
                "27736.38003.55096.41900",
                "27736.38003.51360.45969",
                "27736.38003.37480.20230",
                "27736.38003.16400.33595",
                "27736.38003.49456.55703"
            };

            DateTime exportDate = new LastExportDate(
                client.TdmsContext.CaRoot.Objects, 
                TdmsContext.CaAttrExportName
            ).DateTime;

            //return Utility.GetObjects().Where(c => ids.Contains(c.Id));

            return Utility.GetObjects().Where(c =>
            {
                try
                {
                    return (Utility.ConvertToDateTime(c.Modified) >= exportDate);
                }
                catch (Exception)
                {
                    return false;
                }
            });

            //return Utility.GetObjects().Where(c =>
            //{
            //    try
            //    {
            //        return (Convert.ToDateTime(c.Modified).Date == new DateTime(2020, 11, 5));
            //    }
            //    catch (Exception)
            //    {
            //        return false;
            //    }
            //});
        }

        private IEnumerable<ICa> GetEcaItemsExpectedToBeUpdatedWithFiles()
        {
            return EcaItemsExpectedToBeUpdated.Where(ca => (Convert.ToBoolean(ca.HasFiles)));
        }
    }
}
