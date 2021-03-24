using Tdms.Api;
namespace Csoft.EnoviaAtmIntegration.Domain.Analysis {
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
