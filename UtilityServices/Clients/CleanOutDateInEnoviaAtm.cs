using Csoft.EnoviaAtmIntegration.Domain.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Log;

namespace Csoft.EnoviaAtmIntegration.Domain.UtilityServices {
    /// <summary>
    /// erases SentToTdms attribute value in AtomExpert
    /// </summary>
    internal class CleanOutDateInEnoviaAtm : IUtilityService {
        private string Id { get; }
        private IPutHttpRequestMessageFactory Factory { get; } 
        private EnoviaPutHttpClient Client { get; }
        public CleanOutDateInEnoviaAtm(string id, EnoviaPutHttpClient client) {
            Id = id;
            Client = client;
            Factory = new CleanOutDatePutSentToTdmsRequestFactory(
                new PutSentToTdmsRequestFactory(Id, default(DateTime))
            );
        }
        public void Execute() {
            Client.PutAsync(Factory);
        }
    }
}
