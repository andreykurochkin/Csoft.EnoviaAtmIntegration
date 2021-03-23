using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Csoft.EnoviaAtmIntegration.Domain.Analysis
{
    public class RussianDateFormat : IFormattable
    {
        private DateTime cache;

        public RussianDateFormat(DateTime cache)
        {
            this.cache = cache;
        }

        public string Format()
        {
            return cache.Date.ToString("dd.MM.yyyy",
                CultureInfo.InvariantCulture);
        }
    }
}
