using System.Net.Http;
using Csoft.EnoviaAtmIntegration.Domain.Http;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// fetches json from Enovia
    /// </summary>
    internal class NoSentToTdmsEcasJson : JsonDispatch {
        internal protected override HttpRequestMessage HttpRequestMessage { get; } = 
            new NoSentToTdmsEcasPostHttpRequestMessage();
    }
}