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
using Tdms.Api;
using Tdms.Data;
using System.Runtime.CompilerServices;
using System.Globalization;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    /// <summary>
    /// Invokes DateTime value from TdmsAttribute or default(DateTime)
    /// </summary>
    public class DateTimeValueBehavior
        : TdmsAttributeValueBehavior<DateTime>
    {
        public DateTimeValueBehavior(TDMSAttribute attribute)
            : base(attribute)
        {
            this.value = new InvocationSilent<TDMSAttribute, DateTime>(attribute,
                a => Convert.ToDateTime(attribute.Value));
        }
    }
}