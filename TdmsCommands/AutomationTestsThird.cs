
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Csoft.EnoviaAtmIntegration.Domain.Tests;
using Csoft.EnoviaAtmIntegration.Domain.UtilityServices;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Log;
using Tdms.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// For testing
    /// </summary>
    [TdmsApi("AutomationTestsThird")]
    public class AutomationTestsThird {
        private readonly TDMSApplication app;
        private readonly ILogger log = LogManager.GetLogger(
            $"{typeof(EnoviaPutHttpClientLogged)}"
        );
        public AutomationTestsThird(TDMSApplication app) {
            this.app = app;
        }
        public static void Execute() {
            //string id = "27736.38003.38696.46666";
            var ecas = new NoSentToTdmsEcas();
            Console.WriteLine($"no date CAa amount: {ecas.Count()}");
            //Flush(id);
            //ecas = new NoSentToTdmsEcas();
        }
        private void Flush(string id) {
            EnoviaPutHttpClient httpClient = new EnoviaPutHttpClientLogged(new EnoviaPutHttpClient(), log);
            IUtilityService service = new CleanOutDateInEnoviaAtm(id, httpClient);
            service.Execute();
        }
        public void Execute1() {
            new AlterSentToTdmsDatesClient(
                new NoSentToTdmsEcas().Select(i => i.Id),
                app,
                new CachedActiveVersions(
                    new TdmsContext(
                        app
                    )
                ),
                new EnoviaPutHttpClientLogged(
                    new EnoviaPutHttpClient(),
                    log
                )
            ).Execute();
        }
        private void PrintSentToTdmsDate(string inputString, string id) {
            var ecas = new Ecas();
            var eca = new Ecas().Where(i => i.Id.Equals(id)).FirstOrDefault();
            log.Debug($"{inputString}: {eca}");
        }
    }
}
