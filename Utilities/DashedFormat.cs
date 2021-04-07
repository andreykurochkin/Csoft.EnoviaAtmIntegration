using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Utilities {
    /// <summary>
    /// replaces masked characters to dashes
    /// </summary>
    public class DashedFormat : IFormattable {
        private readonly IFormattable origin;
        public DashedFormat(IFormattable origin) {
            this.origin = origin;
        }
        public string Format() {
            return origin.Format()
                .Replace(" ", "-")
                .Replace(".", "-")
                .Replace(":", "-");
        }
    }
}