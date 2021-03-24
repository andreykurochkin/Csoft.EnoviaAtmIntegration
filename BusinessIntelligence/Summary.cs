using System.Text;

namespace Csoft.EnoviaAtmIntegration.Domain.BusinessIntelligence {
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
