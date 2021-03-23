using Csoft.EnoviaAtmIntegration.Domain;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    public class SystemsRelationship
    {
        public readonly string Systems;
        public readonly string Npps;
        public readonly ICa Eca;

        public SystemsRelationship(string systems, string npps, ICa eca)
        {
            this.Systems = systems;
            this.Npps = npps;
            this.Eca = eca;
        }
    }
}
