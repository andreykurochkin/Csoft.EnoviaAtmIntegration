using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tdms;
using Tdms.Api;
using Tdms.Tasks;
using System.Net.Http.Headers;

namespace Csoft.EnoviaAtmIntegration.Domain {
    [TdmsApi("SendToEnovia")]
    public class SendToEnovia {
        private readonly TDMSApplication app;
        public SendToEnovia(TDMSApplication app) => this.app = app;
        public void Execute(TDMSObject obj) {
            var rows = Utility.GetRowsSafe(obj.Attributes["A_TblWorkability"]);
            var requests = new LoggedArRequests(
                new ArRequests(
                    new AdditionalFilter(
                        new MainFilter(
                            new AtomicArs(
                                new Ars(
                                    new TarFactories(rows)
                                )
                            )
                        )
                    )
                )
            );
            requests.PostAsync();
            var successfulResponses = requests.Where(r => (r.TaskResponse.Result.IsSuccessStatusCode));
            if (successfulResponses.Any()) {
                obj.Attributes["A_Fl_Record"].Value = true;
            }
        }
    }
}
