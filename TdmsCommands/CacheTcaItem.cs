using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tdms;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    /// <summary>
    /// Encapsulates values of TdmsAttributes
    /// </summary>
    public class CacheTcaItem
    {
        public readonly string Id;
        public readonly string date;

        public CacheTcaItem(string id, string date)
        {
            Id = id;
            this.date = date;
        }
    }
}