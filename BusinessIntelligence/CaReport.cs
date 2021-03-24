using System.Linq;

namespace Csoft.EnoviaAtmIntegration.Domain.BusinessIntelligence {
    public class CaReport : Summary {
        private IReportContextFactory Factory { get; }
        public CaReport(IReportContextFactory factory) {
            Factory = factory;
        }
        public override void AppendLines() {
            AppendLine("Report");
            Append("amount of IDs in Enovia ");
            AppendLine($"{Factory.CreateEcas().ToList().Count}");
            Append("amount of IDs in TDMS ");
            var uniqueCachedIds = Factory.CreateCachedItems().Select(i => i.Id).Distinct();
            AppendLine(uniqueCachedIds.Count().ToString());
            var uniqueWebIds = Factory.CreateEcas().Select(i => i.Id);
            var WebMinusTdms = uniqueWebIds.Except(uniqueCachedIds);
            if (WebMinusTdms.Any()) {
                Append("IDs missing from TDMS: ");
                WebMinusTdms.ToList().ForEach(id => AppendLine(id));
            }
        }
    }
}