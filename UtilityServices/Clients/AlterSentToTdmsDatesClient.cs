using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Log;

namespace Csoft.EnoviaAtmIntegration.Domain.UtilityServices {
    public class AlterSentToTdmsDatesClient : IUtilityService {
        public AlterSentToTdmsDatesClient(IEnumerable<string> ids,
                                          TDMSApplication app,
                                          CachedActiveVersions cache,
                                          EnoviaPutHttpClient client) {
            Ids = ids;
            App = app;
            Cache = cache;
            Client = client;
        }
        private readonly IEnumerable<string> Ids;
        private TDMSApplication App { get; }
        private CachedActiveVersions Cache { get; }
        private EnoviaPutHttpClient Client { get; }
        public void Execute() {
            foreach (var id in Ids) {
                var cacheItem = Cache.FirstOrDefault(c => c.Id.Equals(id));
                if (cacheItem != null) {
                    // Дата обновления A_Date
                    var date = new DateTimeValueBehavior(
                        App.GetObjectByGUID(cacheItem.Guid).Attributes["A_Date"]
                    ).GetValue();
                    new UpdateDateInEnoviaAtm(id, date, Client).Execute();
                }
            }
        }
    }
}
