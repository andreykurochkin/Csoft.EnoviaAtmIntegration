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
    /// Invokes string value from TdmsAttribute by name or string.Empty
    /// </summary>
    public class StringValueBehavior : TdmsAttributeValueBehavior<string>
    {
        public StringValueBehavior(TDMSAttribute attribute)
            : base(attribute)
        {
            this.value = new InvocationSilent<TDMSAttribute, string>(
                this.attribute,
                a =>
                {
                    string result;
                    try { result = a.Value.ToString(); }
                    catch (Exception) { result = string.Empty; }
                    return result;
                });
        }
    }
}