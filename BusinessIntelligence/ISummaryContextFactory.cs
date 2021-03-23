using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Csoft.EnoviaAtmIntegration.Domain.Analysis
{
    public interface ISummaryContextFactory
    {
        Cas CreateEcas();
        Cas CreateNoSentToTdmsEcas();
        Cas CreateTcas();
        Cas CreateTcasWithFiles();
    }
}
