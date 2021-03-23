using System;
using System.Collections.Generic;
using System.Linq;
using Csoft.EnoviaAtmIntegration.Domain;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// Compares items by all fields
    /// </summary>
    public class CorrectionActionFatEqualityComparer : IEqualityComparer<ICa>
    {
        public bool Equals(ICa x, ICa y)
        {
            //if (!x.Id.Equals(y.Id)) return false;
            //if (!x.Npps.Equals(y.Npps)) return false;
            //if (!x.Buildings.Equals(y.Buildings)) return false;
            //if (!x.Name.Equals(y.Name)) return false;
            //if (!x.Description.Equals(y.Description)) return false;
            //if (!x.RelationShip3.Equals(y.RelationShip3)) return false;
            //if (!x.Systems.Equals(y.Systems)) return false;
            //if (!x.Type.Equals(y.Type)) return false;
            //if (!x.Specialization.Equals(y.Specialization)) return false;
            //if (!x.HasFiles.Equals(y.HasFiles)) return false;

            if (!Compare(x.Id, y.Id)) return false;
            if (!Compare(x.Npps, y.Npps)) return false;
            if (!Compare(x.Buildings, y.Buildings)) return false;
            if (!Compare(x.Name, y.Name)) return false;
            //if (!Compare(x.Description, y.Description)) return false;
            if (!Compare(x.LongDescription, y.LongDescription)) return false;

            if (!Compare(x.RelationShip3, y.RelationShip3)) return false;
            if (!Compare(x.Systems, y.Systems)) return false;
            if (!Compare(x.Type, y.Type)) return false;
            if (!Compare(x.Specialization, y.Specialization)) return false;
            if (!Compare(x.HasFiles, y.HasFiles)) return false;

            return true;
        }

        private bool Compare(string x, string y) 
        { 
            if ((x==null) && (y==null)) return true;
            if (x == null) return false;
            if (y == null) return false;
            return x.Equals(y);
        }

        public int GetHashCode(ICa obj)
        {
            return ((obj.Id == null) ? string.Empty.GetHashCode() : obj.Id.GetHashCode()) ^
            ((obj.Npps == null) ? string.Empty.GetHashCode() : obj.Npps.GetHashCode()) ^
            ((obj.Buildings == null) ? string.Empty.GetHashCode() : obj.Buildings.GetHashCode()) ^
            ((obj.Name == null) ? string.Empty.GetHashCode() : obj.Name.GetHashCode()) ^
            //((obj.Description == null) ? string.Empty.GetHashCode() : obj.Description.GetHashCode()) ^
            ((obj.LongDescription == null) ? string.Empty.GetHashCode() : obj.LongDescription.GetHashCode()) ^

            ((obj.RelationShip3 == null) ? string.Empty.GetHashCode() : obj.RelationShip3.GetHashCode()) ^
            ((obj.Systems == null) ? string.Empty.GetHashCode() : obj.Systems.GetHashCode()) ^
            ((obj.Type == null) ? string.Empty.GetHashCode() : obj.Type.GetHashCode()) ^
            ((obj.Specialization == null) ? string.Empty.GetHashCode() : obj.Specialization.GetHashCode()) ^
            ((obj.HasFiles == null) ? string.Empty.GetHashCode() : obj.HasFiles.GetHashCode());
        }
    }
}
