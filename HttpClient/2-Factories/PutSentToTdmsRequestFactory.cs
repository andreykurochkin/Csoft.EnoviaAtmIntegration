using Csoft.EnoviaAtmIntegration.Domain.Analysis;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// configures put request to update pdSentToTdms Enovia attribute
    /// </summary>
    public class PutSentToTdmsRequestFactory :
        IPutHttpRequestMessageFactory {
        protected string Id { get; }
        private DateTime date;
        public PutSentToTdmsRequestFactory(string id, DateTime date) {
            this.Id = id;
            this.date = date;
        }
        public AuthenticationHeaderValue CreateAuthenticationHeaderValue() {
            return new EnoviaBasicAuthenticationHeaderValue();
        }
        public StringContent CreateStringContent() {
            var formattedDate = new SlashedFormat(
                new Analysis.RussianDateFormat(
                    date));
            var json = "{\"pdSentToTDMS\":" + "\"" +
                $"{formattedDate.Format()}" + "\"" + "}";

            return new StringContent(json, Encoding.UTF8,
                "application/json");
        }
        public Uri CreateUri() {
            return new Endpoints.UpdateUri(Id);
        }
    }
}