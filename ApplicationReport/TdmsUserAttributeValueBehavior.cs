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
using Csoft.EnoviaAtmIntegration.Domain;
//using System.Web.Http.Routing;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    /// <summary>
    /// Invokes TdmsUser from TdmsAttribute
    /// </summary>
    public class TdmsUserAttributeValueBehavior
        : TdmsAttributeValueBehavior<TDMSUser>
    {
        public TdmsUserAttributeValueBehavior(TDMSAttribute attribute)
            : base(attribute)
        {
            this.value = new InvocationSilent<TDMSAttribute, TDMSUser>(
                attribute, a => a.User);
        }
    }
}
