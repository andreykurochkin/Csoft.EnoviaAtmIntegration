using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Tdms;
using Tdms.Api;
using Tdms.Log;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    public class DateUpdateContext
    {
        private HttpClient httpClient;
        private string id;
        private string date;

        /// <summary>
        /// Context to update data in Enovia
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="id">id of correction action</param>
        /// <param name="date">date to be updated</param>
        public DateUpdateContext(HttpClient httpClient, string id,
            string date)
        {
            this.httpClient = httpClient;
            this.id = id;
            this.date = date;
        }

        public HttpResponseMessage PutAsync() => PutAsync(id, date);

        private HttpResponseMessage PutAsync(string id, string date)
        {
            ILogger logger = LogManager.GetLogger("DateUpdateContext");
            
            var uri = $"...";
            var json = "{\"pdSentToTDMS\":" + "\"" + $"{date}" + "\"" + "}";
            logger.Debug($"json: {json}");
            var content = new StringContent(json, Encoding.UTF8, 
                "application/json");
            
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new EnoviaBasicAuthenticationHeaderValue();

            var response = httpClient.PutAsync(uri, content).Result;
            logger.Debug($"update date: tdsm->enovia id: {id}, date: {date}, httpResponse: {response.StatusCode}");
            return response;
        }
    }
}