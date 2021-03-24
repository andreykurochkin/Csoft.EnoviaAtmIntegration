using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class Ecas : Cas {
        private readonly string json;
        public Ecas() {
            json = new EcasJson().ToString();
            list = CreateICas(json).ToList();
        }
    }
}