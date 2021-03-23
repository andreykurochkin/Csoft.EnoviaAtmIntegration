using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    public class TcasWithFiles : Cas
    {
        public TcasWithFiles(Cas tcas)
        {
            var query = tcas
                    .Where(tca => 
                    (Convert.ToBoolean(tca.HasFiles)));
            list =  query.ToList();
        }
    }
}