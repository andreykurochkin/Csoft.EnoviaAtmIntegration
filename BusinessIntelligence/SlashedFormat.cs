using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain.Analysis
{
    public class SlashedFormat : IFormattable
    {
        private IFormattable origin;

        public SlashedFormat(IFormattable origin)
        { 
            this.origin = origin;
        }

        public string Format()
        {
            return origin.Format()
                .Replace(" ", "/")
                .Replace(".", "/")
                .Replace(":", "/");
        }
    }
}
