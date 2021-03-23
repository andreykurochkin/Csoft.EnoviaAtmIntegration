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

namespace Csoft.EnoviaAtmIntegration.Domain.Services
{
    /// <summary>
    /// runs services of TDMS application server. 
    /// 1) updates correction actions in TDMS
    /// 2) updates dates in Enovia
    /// 3) updates files correction actions in TDMS
    /// </summary>
    public class UpdateService
    {
        readonly TDMSApplication app;
        private static bool isServiceRunning = false;
        private readonly ILogger log;
        public UpdateService(TDMSApplication app)
        {
            this.app = app;
            this.log = LogManager.GetLogger($"{typeof(UpdateService)}");
        }
        public async Task Execute(CancellationToken ct)
        {
            if (isServiceRunning) return;
            isServiceRunning = true;

            this.log.Debug($"{typeof(UpdateService)} is running");

            try
            {
                var client = new UpdateContext(app);
                client.CreateOrUpdateCorrectionActions();
            }
            catch (Exception ex)
            {
                log.Debug($"{typeof(UpdateService)} " +
                    $"- update tdmsObjects error");
                log.Debug($"Message: {ex.Message}");
                log.Debug($"StackTrace: {ex.StackTrace}");
            }

            try {
                //new T2EUpdateExportDate(application).Execute();
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
                log.Debug($"{typeof(UpdateService)} " +
                    $"- update export date error");
                log.Debug($"Message: {ex.Message}");
                log.Debug($"StackTrace: {ex.StackTrace}");
            }

            //try
            //{
            //    new AlterFileDownload(app).Execute();
            //}
            //catch (Exception ex)
            //{
            //    log.Debug($"{typeof(UpdateService)} " +
            //        $"- update files error");
            //    log.Debug($"Message: {ex.Message}");
            //    log.Debug($"StackTrace: {ex.StackTrace}");
            //}
            finally
            {
                isServiceRunning = false;
            }
        }
    }
}
