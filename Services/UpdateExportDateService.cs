using Csoft.EnoviaAtmIntegration.Domain.UtilityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tdms;
using Tdms.Api;
using Tdms.Log;
namespace Csoft.EnoviaAtmIntegration.Domain.Services {
    /// <summary>
    /// updates export date of TDMSObjects
    /// </summary>
    class UpdateExportDateService {
        readonly TDMSApplication app;
        private static bool isServiceRunning = false;
        private readonly ILogger log;

        public UpdateExportDateService(TDMSApplication app) {
            this.app = app;
            this.log = LogManager
                .GetLogger($"{nameof(UpdateExportDateService)}");
        }

        public async Task Execute(CancellationToken ct) {
            if (isServiceRunning) return;
            isServiceRunning = true;

            this.log
                .Debug($"{typeof(UpdateExportDateService)} " +
                $"is running.");

            try {
                //new T2EUpdateExportDate(app).Execute();
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
            catch (Exception ex) {
                log.Debug($"{typeof(UpdateExportDateService)} error");
                log.Debug($"Message: {ex.Message}");
                log.Debug($"StackTrace: {ex.StackTrace}");
            }
            finally {
                isServiceRunning = false;
            }
        }
    }
}
