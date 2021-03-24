using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class NoSentToTdmsEcas : Cas, IAsJson {
        private readonly string json;
        public NoSentToTdmsEcas() {
            json = CasJsonFactory.CreateNoSentToTdmsEcasAsJson();
            list = CreateICas(json).ToList();
        }
        public string ToJson() {
            return json;
        }
    }
}