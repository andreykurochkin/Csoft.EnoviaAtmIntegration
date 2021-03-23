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
    public abstract class TdmsAttributeValueBehavior<TResult>
        : IAttributeValueBehavior<TResult>
    {
        protected TDMSAttribute attribute;
        protected InvocationSilent<TDMSAttribute, TResult> value;

        public TdmsAttributeValueBehavior(TDMSAttribute attribute)
        {
            this.attribute = attribute;
        }

        public TResult GetValue()
        {
            return value.Invoke();
        }
    }
}