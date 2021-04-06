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
    /// <summary>
    /// caches state of active objects from database
    /// </summary>
    public class CachedActiveVersions : List<CacheItem> {
        private TdmsContext TdmsContext { get; }
        public CachedActiveVersions(TdmsContext context) {
            TdmsContext = context;
            CacheDataBase();
        }
        private void CacheDataBase() {
            TdmsContext.CaRoot.Objects
                .Where(obj => obj.ActiveVersion)
                .ForEach(obj => this.Add(
                    new CacheItem(
                        id: obj.Attributes["A_ObjectGUID"].Value.ToString(),
                        guid: obj.GUID
                    )
                ));
        }
    }
}
