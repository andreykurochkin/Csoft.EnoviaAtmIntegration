using System;
using Tdms.Api;
using Csoft.EnoviaAtmIntegration.Domain.BusinessIntelligence;

namespace Csoft.EnoviaAtmIntegration.Domain.Tests {
    class PrintAnalyticsWhenNoCorrectionActionInTdms : ITdmsTest {
        private TDMSApplication App { get; }
        public PrintAnalyticsWhenNoCorrectionActionInTdms(TDMSApplication app) {
            App = app;
        }
        public void Execute() {
            try {
                new Analytics(App).Print();
            }
            catch (Exception ex) {
                throw new Exception($"Ошибка экспорта данных из Enovia в TDMS \n {ex.Message}");
            };
        }
    }
}
