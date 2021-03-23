using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tdms.Api;
namespace Csoft.EnoviaAtmIntegration.Domain.Analysis {
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
                return;
                //Append("IDs missing from TDMS: ");
                //WebMinusTdms.ToList().ForEach(id => AppendLine(id));
            }
        }
    }
    public interface IReportContextFactory
        : ISummaryContextFactory, ICachedActiveVersions { }
    public interface ICachedActiveVersions {
        CachedActiveVersions CreateCachedItems();
    }
    public class ReportContextFactory : IReportContextFactory {
        public TDMSApplication App { get; }
        public ISummaryContextFactory Origin { get; }
        public ReportContextFactory(ISummaryContextFactory origin, TDMSApplication app) {
            this.Origin = origin;
            App = app;
        }
        public Cas CreateEcas() {
            return Origin.CreateEcas();
        }
        public Cas CreateNoSentToTdmsEcas() {
            return Origin.CreateNoSentToTdmsEcas();
        }
        public Cas CreateTcas() {
            return Origin.CreateTcas();
        }
        public Cas CreateTcasWithFiles() {
            return Origin.CreateTcasWithFiles();
        }
        public CachedActiveVersions CreateCachedItems() {
            return new CachedActiveVersions(
                new TdmsContext(App)
            );
        }
    }
}
