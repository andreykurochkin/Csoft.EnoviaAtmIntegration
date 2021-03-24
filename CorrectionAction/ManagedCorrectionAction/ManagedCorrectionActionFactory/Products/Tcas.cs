using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class Tcas : Cas {
        public Tcas(Cas ecas) {
            list = new KudanTcaClient(
                new TcaClient(
                    new McaClient(
                        ecas
                    )
                )
            )
            .CreateItems()
            .ToList();
        }
    }
}