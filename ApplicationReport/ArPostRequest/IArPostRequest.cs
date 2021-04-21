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
    public interface IArPostRequest
    {
        Ar Ar { get; }
        HttpResponseMessage PostAsync();
    }
}