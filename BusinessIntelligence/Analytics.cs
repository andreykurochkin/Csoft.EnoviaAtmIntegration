using System;
using System.IO;
using Tdms.Api;
using Csoft.EnoviaAtmIntegration.Utilities.IO;

namespace Csoft.EnoviaAtmIntegration.Domain.BusinessIntelligence {
    public class Analytics {
        private FolderFactory folderFactory = new FolderFactory(DateTime.Now);
        private TDMSApplication App { get; }
        public Analytics(TDMSApplication app) {
            App= app;
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
