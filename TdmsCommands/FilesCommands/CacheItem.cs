using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using Tdms;
using System.IO.Compression;
using System.Globalization;
using Csoft.EnoviaAtmIntegration.Domain.Analysis;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class CacheItem {
        internal string Id { get; }
        internal string Guid { get; }
        public CacheItem(string id, string guid) {
            Id = id;
            Guid = guid;
        }
    }
}
