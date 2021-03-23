using Csoft.EnoviaAtmIntegration.Domain;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    public class SystemsRelationships : List<SystemsRelationship>
    {
        private readonly string npps;
        private readonly string systems;
        private readonly ICa eca;

        public SystemsRelationships(ICa eca) : this(eca.Npps, eca.Systems, eca) { }

        private SystemsRelationships(string npps, string systems, ICa eca)
        {
            this.eca = eca;
            this.npps = npps;
            this.systems = systems;
            this.GenerateItems();
        }

        private void GenerateItems()
        {
            var pairs = npps.ToList().Zip(systems.ToList(), (npp, system) => new { npp = npp, system = system });
            var groupedPairs = pairs.GroupBy(pair => pair.npp);

            var NppRelationship = groupedPairs.
                Select(g => new { npp = g.Key, systems = g.Select(p => p.system).ToList() });

            var groupedSystems = NppRelationship.GroupBy(NppRelationshipItem => NppRelationshipItem.systems, new ListContentEqualityComparer());

            var SystemRelationship = groupedSystems.Select(g => new { systems = g.Key, npps = g.Select(p => p.npp).ToList() });

            SystemRelationship.ToList().ForEach(g => this.Add(new SystemsRelationship(String.Join(", ", g.systems), String.Join(", ", g.npps), this.eca)));

        }
    }
}
