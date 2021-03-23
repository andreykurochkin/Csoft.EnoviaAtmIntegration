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
    /// creates application reports in Enovia
    /// </summary>
    public class EarsService
    {
        readonly TDMSApplication app;
        private static bool isServiceRunning = false;
        private readonly ILogger log = LogManager
            .GetLogger($"{typeof(EarsService)}");

        public EarsService(TDMSApplication app) =>
            this.app = app;

        public async Task Execute(CancellationToken ct)
        {
            if (isServiceRunning) return;
            isServiceRunning = true;

            this.log.Debug($"{typeof(EarsService)} is running");

            try
            {

                var kspps = new TdmsContext(app)
                    .GetKsppQuery().Objects;
                var cou = kspps.Count;

                this.log.Debug($"forecast");
                this.log.Debug($"N kspps: {cou}");
                
                for (int i = 0; i < kspps.Count - 1; i++)
                {
                    var kspp = kspps[i];
                    this.log.Debug($"kspp progress: " +
                        $"#{i + 1} of {cou}," +
                        $"{kspp.GUID}");
                    new SendToEnovia(app).Execute(kspp);
                }
            }
            catch (Exception ex)
            {
                log.Debug($"{typeof(EarsService)} error");
                log.Debug($"Message: {ex.Message}");
                log.Debug($"StackTrace: {ex.StackTrace}");
            }
            finally
            {
                isServiceRunning = false;
            }
        }
    }
}
