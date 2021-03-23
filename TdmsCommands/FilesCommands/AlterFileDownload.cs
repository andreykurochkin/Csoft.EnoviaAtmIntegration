using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using Tdms;
using System.IO.Compression;
using System.Globalization;
using Csoft.EnoviaAtmIntegration.Domain.Analysis;
namespace Csoft.EnoviaAtmIntegration.Domain {
    [TdmsApi("FileDownload")]
    class AlterFileDownload {
        private readonly TDMSApplication app;
        public AlterFileDownload(TDMSApplication app) {
            this.app = app;
        }
        public void Execute() {
            HttpClient httpClient = new HttpClient();
            CachedActiveVersions cache = new CachedActiveVersions(
                new TdmsContext(app)
            );
            DirectoryInfo layoutFolder = new DirectoryInfo(app.WorkFolder)
                .CreateSubdirectory(
                    new DashedFormat(
                        new RussianDateTimeFormat(DateTime.Now)
                    ).Format()
                );
            new EcasWithFiles(new Ecas()).ToList().ForEach(eca =>
                new CheckOut(httpClient, layoutFolder, cache, app).Process(eca));
        }
    }
    /// <summary>
    /// uploads files to tcas, having specific id
    /// </summary>
    [TdmsApi("FileDownload")]
    public class MockAlterFileDownload {
        private TDMSApplication App { get; }
        private string Id { get; }

        public MockAlterFileDownload(TDMSApplication app, string id) {
            App = app;
            Id = id;
            HttpClient httpClient = new HttpClient();
            CachedActiveVersions cache = new CachedActiveVersions(
                new TdmsContext(app)
            );
            DirectoryInfo layoutFolder = new DirectoryInfo(app.WorkFolder)
                .CreateSubdirectory(
                    new DashedFormat(
                        new RussianDateTimeFormat(DateTime.Now)
                    ).Format()
                );
            var ecasWithFiles = new EcasWithFiles(new Ecas()).ToList();
            Console.WriteLine($"ecasWithFiles count: {ecasWithFiles.Count}");
            ecasWithFiles.ForEach(eca => Console.WriteLine(eca.Id));

            var source = ecasWithFiles.Where(eca => eca.Id.Equals(Id)).ToList();
            var cou = source.Count;
            foreach (var eca in source) {
                var pipeLine = new CheckOut(httpClient, layoutFolder, cache, app);
                pipeLine.Process(eca);
            }
        }
    }
}
