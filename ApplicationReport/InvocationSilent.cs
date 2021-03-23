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
    public class InvocationSilent<T, TResult> : Invocation<T, TResult>
    {
        public InvocationSilent(T attribute, Func<T, TResult> command) 
            : base(attribute, command) { }
        public override TResult Invoke()
        {
            try
            {
                return base.Invoke();
            }
            catch (Exception)
            {
                return default(TResult);
            }
        }
    }
}
