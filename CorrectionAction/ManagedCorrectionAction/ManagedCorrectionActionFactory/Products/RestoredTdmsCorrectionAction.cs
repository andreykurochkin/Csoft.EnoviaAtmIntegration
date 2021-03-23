using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// Deserializes TdmsObject to TdmsCorrectionAction
    /// </summary>
    public class RestoredTdmsCorrectionAction : Ca 
    {
        public readonly TDMSObject tdmsObject;

        public RestoredTdmsCorrectionAction(ICaFactory factory, TDMSObject tdmsObject) : base(factory)
        {
            this.tdmsObject = tdmsObject;
        }
    }
}
