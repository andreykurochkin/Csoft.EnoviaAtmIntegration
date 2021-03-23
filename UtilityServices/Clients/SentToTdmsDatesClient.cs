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
    /// updates SentToTdms attribute value in Enovia
    /// </summary>
    class SentToTdmsDatesClient : IUtilityService {
        private IEnumerable<string> ids;
        private DateTime date;
        private EnoviaPutHttpClientLogged httpClient;

        public SentToTdmsDatesClient(IEnumerable<string> ids,
                                     DateTime date,
                                     ILogger log) {
            this.ids = ids;
            this.date = date;
            this.httpClient = new EnoviaPutHttpClientLogged(
                new EnoviaPutHttpClient(), log);
        }

        public void Execute() {
            ids.ToList().ForEach(
                id => httpClient.PutAsync(
                    new PutSentToTdmsRequestFactory(
                        id, date)));
        }
    }
}
