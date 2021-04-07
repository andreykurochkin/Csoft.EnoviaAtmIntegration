namespace Csoft.EnoviaAtmIntegration.Domain.BusinessIntelligence {
    public interface ISummaryContextFactory {
        Cas CreateEcas();
        Cas CreateNoSentToTdmsEcas();
        Cas CreateTcas();
        Cas CreateTcasWithFiles();
    }
}
