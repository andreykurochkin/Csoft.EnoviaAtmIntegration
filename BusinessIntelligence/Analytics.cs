using System;
using System.IO;
using Tdms.Api;
using Csoft.EnoviaAtmIntegration.Domain;
namespace Csoft.EnoviaAtmIntegration.Domain.BusinessIntelligence {
    public class Analytics {
        private FolderFactory folderFactory = new FolderFactory(DateTime.Now);
        private ISummaryContextFactory forecastFactory = new SummaryContextFactory();
        private IReportContextFactory reportFactory;

        public Analytics(TDMSApplication app) {
            reportFactory = new ReportContextFactory(forecastFactory, app);
        }
        public void Print() {
            CreateFile(folderFactory.GetLayoutFolder(),
                "allEca.txt",
                //CasJsonFactory.CreateEcasAsJson()
                //new Ecas().ToJson()
                new EcasJson().ToString()
            ); 
            CreateFile(folderFactory.GetLayoutFolder(),
                "ecaWithNoSentToTdmsDate.txt",
                //CasJsonFactory.CreateNoSentToTdmsEcasAsJson()
                new NoSentToTdmsEcasJson().ToString()
            );
            CreateFile(folderFactory.GetLayoutFolder(),
                "forecast.txt",
                new CaForecast(forecastFactory).ToString()
            );
            CreateFile(folderFactory.GetLayoutFolder(),
                "report.txt",
                new CaReport(reportFactory).ToString());
        }
        private static void CreateFile(DirectoryInfo folder, string fileName, string content) {
            using (var file = File.CreateText($"{folder.FullName}\\{fileName}")) {
                file.WriteLine(content);
                file.Close();
            }
        }
    }
}
