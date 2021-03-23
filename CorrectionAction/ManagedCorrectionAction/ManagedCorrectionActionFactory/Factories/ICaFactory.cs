using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public interface ICaFactory
    {
        string CreateName();
        string CreateDescription();

        string CreateLongDescription();

        string CreateRelationShip3();
        string CreateId();
        string CreateType();
        string CreateEnoviaModifiedDate();
        string CreateExportDate();
        string CreateSystems();
        string CreateNpps();
        string CreateBuildings();
        string CreateHasFiles();
        string SentToTdms();
    }
}
