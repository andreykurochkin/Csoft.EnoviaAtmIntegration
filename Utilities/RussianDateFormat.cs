using System;
using System.Globalization;

namespace Csoft.EnoviaAtmIntegration.Utilities {
    public class RussianDateFormat : IFormattable {
        private readonly DateTime cache;
        public RussianDateFormat(DateTime cache) {
            this.cache = cache;
        }
        public string Format() {
            return cache.Date.ToString(
                "dd.MM.yyyy",
                CultureInfo.InvariantCulture);
        }
    }
}
