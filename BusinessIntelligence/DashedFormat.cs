using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain.Analysis
{
    /// <summary>
    /// replaces masked characters to dashes
    /// </summary>
    public class DashedFormat : IFormattable
    {
        private IFormattable origin;

        public DashedFormat(IFormattable origin)
        {
            this.origin = origin;
        }

        public string Format()
        {
            return origin.Format()
                .Replace(" ", "-")
                .Replace(".", "-")
                .Replace(":", "-");
        }
    }
}
