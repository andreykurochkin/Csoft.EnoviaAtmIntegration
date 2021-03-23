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
    /// updates SentToTdms attribute value in AtomExpert
    /// <summary>
    internal class UpdateDateInEnoviaAtm : IUtilityService {
        private string Id { get; }
        private DateTime Date { get; }
        private IPutHttpRequestMessageFactory Factory { get; }
        private EnoviaPutHttpClient Client { get; }
        public UpdateDateInEnoviaAtm(string id, DateTime date, EnoviaPutHttpClient client) {
            Id = id;
            Date = date;
            Client = client;
            Factory = new PutSentToTdmsRequestFactory(Id, Date);
        }
        public void Execute() {
            Client.PutAsync(Factory);
        }
    }
}
