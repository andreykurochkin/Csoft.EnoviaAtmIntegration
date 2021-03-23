using System;
using System.Collections.Generic;
using System.Linq;
using Tdms.Api;
namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// Encapsulates algorithms of pairing elements.
    /// RestoredTdmsCorrectionAction is paired to the TdmsCorrectionAction from Enovia
    /// RestoredTdmsCorrectionAction encapsulates tdmsObject created on previous export
    /// TdmsCorrectionAction encapsulates json from Enovia as task to creation tdmsObject on current export
    /// </summary>
    public interface IMapItemsFamilyBehavior {
        IEnumerable<IdMapItemFamily> CreateItems();
    }
}
