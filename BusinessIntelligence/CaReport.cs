using System;
using System.Linq;

namespace Csoft.EnoviaAtmIntegration.Domain.BusinessIntelligence {
    public class CaReport : Summary {
        TdmsContext TdmsContext { get; }
        Lazy<Ecas> Ecas { get; }
        public CaReport(TdmsContext tdmsContext) {
            TdmsContext = tdmsContext;
            Ecas = new(new Ecas());
        }
        public override void AppendLines() {
            AppendLine("Report");
            Append("amount of IDs in Enovia ");
            AppendLine($"{Ecas.Value.Count()}");
            Append("amount of IDs in TDMS ");
            var uniqueCachedIds = new CachedActiveVersions(TdmsContext).Select(i => i.Id)
                .Distinct();
            AppendLine(uniqueCachedIds.Count().ToString());
            var uniqueWebIds = Ecas.Value.Select(i => i.Id);
            var WebMinusTdms = uniqueWebIds.Except(uniqueCachedIds);
            if (WebMinusTdms.Any()) {
                Append("IDs missing from TDMS: ");
                WebMinusTdms.ToList().ForEach(id => AppendLine(id));
            }
        }
    }
}