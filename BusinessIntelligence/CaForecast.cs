using System.Linq;

namespace Csoft.EnoviaAtmIntegration.Domain.BusinessIntelligence {
    public class CaForecast : Summary {
        private ISummaryContextFactory Factory { get; }
        public CaForecast(ISummaryContextFactory factory) {
            Factory = factory;
        }
        public override void AppendLines() {
            AppendLine("Forecast");
            Append("expected number of new correction actions: ");
            AppendLine($"{Factory.CreateTcas().Count()}");
            Append("expected number of new correction actions with files: ");
            AppendLine($"{Factory.CreateTcasWithFiles().Count()}");
            Append($"amount of CA in Enovia with no SentToTdmsDate: ");
            var noDate = Factory.CreateNoSentToTdmsEcas().ToList();
            AppendLine($"{noDate.Count()}");
            noDate.ForEach(eca => AppendLine(eca.Id));
        }
    }
}
