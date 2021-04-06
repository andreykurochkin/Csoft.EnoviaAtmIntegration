using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    /// <summary>
    /// filters ecas in order to get items with files
    /// </summary>
    public class EcasWithFiles : Cas
    {
        public EcasWithFiles(Cas ecas)
        {
            var query = ecas.Where(eca =>
                (Convert.ToBoolean(eca.HasFiles)));
            list = query.ToList();
        }
    }
}