using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// filters enovia correction actions to be not later than specified date
    /// </summary>
    public class EcasBeforeDate : Cas {
        public EcasBeforeDate(Cas ecas, DateTime date ) {
            var query = ecas
                .Select(eca => new { Self = eca, Date = eca.Modified.ToDateTime() })
                .Where(o => o.Date >= date)
                .Select(o => o.Self);
            this.list = query.ToList();
        }
    }
}