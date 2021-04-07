using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Csoft.EnoviaAtmIntegration.Utilities {
    public class RussianDateTimeFormat : IFormattable {
        private readonly DateTime cache;
        public RussianDateTimeFormat(DateTime cache) {
            this.cache = cache;
        }
        public string Format() {
            return cache.ToString("dd.MM.yyyy HH.mm.ss");
        }
    }
}
