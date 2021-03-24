namespace Csoft.EnoviaAtmIntegration.Domain.Http {
    /// <summary>
    /// configures specific HttpRequestMessage
    /// </summary>
    public class NoSentToTdmsEcasPostHttpRequestMessage : PostHttpRequestMessage {
        public NoSentToTdmsEcasPostHttpRequestMessage() : base(
            new NoSentToTdmsRequestFactory(
                new AllEcaRequestFactory()
            )
        ) { }
    }
}