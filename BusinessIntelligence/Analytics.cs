using System;
using Tdms.Api;
using Csoft.EnoviaAtmIntegration.Utilities.IO;

namespace Csoft.EnoviaAtmIntegration.Domain.BusinessIntelligence {
    public class Analytics {
        private readonly string path = "C:\\Users\\AP_Petrosyan_TV\\Documents\\kurochkin";
        private readonly FolderFactory folderFactory;
        private TDMSApplication App { get; }
        public Analytics(TDMSApplication app) {
            App= app;
            folderFactory = new(DateTime.Now, path);
        }
        public void Print() {
            FileFactory.CreateFile(folderFactory.GetLayoutFolder(),
                "allEca.txt",
                new EcasJson().ToString()
            ); 
            FileFactory.CreateFile(folderFactory.GetLayoutFolder(),
                "ecaWithNoSentToTdmsDate.txt",
                new NoSentToTdmsEcasJson().ToString()
            );
            FileFactory.CreateFile(folderFactory.GetLayoutFolder(),
                "forecast.txt",
                new CaForecast(
                    new SummaryContextFactory()
                ).ToString()
            );
            FileFactory.CreateFile(folderFactory.GetLayoutFolder(),
                "report.txt",
                new CaReport(
                    new TdmsContext(
                        App
                    )
                ).ToString()); ;
        }
    }
}
