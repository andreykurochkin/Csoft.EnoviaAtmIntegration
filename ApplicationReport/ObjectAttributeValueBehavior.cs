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

namespace Csoft.EnoviaAtmIntegration.Domain
{
    /// <summary>
    /// Invokes TdmsObject from TdmsAttribute
    /// </summary>
    public class TdmsObjectValueBehavior
        : TdmsAttributeValueBehavior<TDMSObject>
    {
        public TdmsObjectValueBehavior(TDMSAttribute attribute)
            : base(attribute)
        {
            this.value = new InvocationSilent<TDMSAttribute, TDMSObject>(
                this.attribute, a => a.Object);
        }
    }
}