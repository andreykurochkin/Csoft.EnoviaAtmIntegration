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

namespace Csoft.EnoviaAtmIntegration.Domain
{
    public interface IArFactory
    {
        string CreateApplicantName();
        string CreateBuildingName();
        string CreateRevision();
        string CreateDescription();
        string CreateNppId();
        string CreateNppUnit();
        string CreateSetCode();
        string CreateSetName();
        string CreateStatus();
        string CreateSystemName();
        string CreateEcaId();
    }
}