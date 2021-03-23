using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public interface ICa
    {
        string Npps { get; set; }
        string Buildings { get; set; }
        string Name { get; set; }
        string Description { get; set; }

        string LongDescription { get; set; }

        string RelationShip3 { get; set; }
        string Id { get; set; }
        string Systems { get; set; }
        string Type { get; set; }
        string Modified { get; set; }
        string Export { get; set; }
        string Specialization { get; set; }
        string HasFiles { get; set; }

        string SentToTdms { get; set; }
    }
}
