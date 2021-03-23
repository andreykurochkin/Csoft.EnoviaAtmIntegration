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
    class PrintAnalyticsWhenNoCorrectionActionInTdms : ITdmsTest
    {
        private TDMSApplication app;

        public PrintAnalyticsWhenNoCorrectionActionInTdms(
            TDMSApplication app)
        {
            this.app = app;
        }

        public void Execute()
        {
            try
            {
                new Analysis.Analytics(app).Print();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка экспорта данных из Enovia в TDMS \n {ex.Message}");
            };
        }
    }
}
