using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Csoft.EnoviaAtmIntegration.Domain.Analysis {
    public abstract class Summary {
        protected StringBuilder stringBuilder = new StringBuilder();
        public void Append(string input) {
            this.stringBuilder.Append(input);
        }
        public void AppendLine(string input) {
            this.stringBuilder.AppendLine(input);
        }
        public abstract void AppendLines();
        public override string ToString() {
            AppendLines();
            return stringBuilder.ToString();
        }
    }
}
