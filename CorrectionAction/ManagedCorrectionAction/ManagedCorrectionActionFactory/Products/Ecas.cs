using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class Ecas : Cas, IAsJson {
        private readonly string json;
        public Ecas() {
            json = CasJsonFactory.CreateEcasAsJson();
            list = CreateICas(json).ToList();
        }
        public string AsJson() {
            return json;
        }
    }
}