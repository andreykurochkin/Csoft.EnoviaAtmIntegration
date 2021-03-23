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
using Tdms.Log;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class ArStringContent : StringContent
    {
        public ArStringContent(Ar ar)
            : base(ar.ToJsonSafe(), Encoding.UTF8,
                  "application/json")
        { }
    }
}