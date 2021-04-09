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
using Tdms.Tasks;
using Tdms.Data;
using System.Runtime.CompilerServices;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    /// <summary>
    /// Invokes bool value from TdmsAttributes by name
    /// </summary>
    public class BoolValueBehavior : TdmsAttributeValueBehavior<bool>
    {
        public BoolValueBehavior(TDMSAttribute attribute) : base(attribute)
        {
            this.value = new InvocationSafe<TDMSAttribute, bool>(attribute,
                a => Convert.ToBoolean(a.Value));
        }
    }
}