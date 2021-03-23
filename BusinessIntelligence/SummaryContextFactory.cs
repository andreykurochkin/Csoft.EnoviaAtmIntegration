using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Csoft.EnoviaAtmIntegration.Domain.Analysis {
    /// <summary>
    /// creates IEnumerable<ICa> items for summary items
    /// </summary>
    public class SummaryContextFactory : ISummaryContextFactory {
        private Cas ecas;
        private Cas noSentToTdmsEcas;
        private Cas tcas;
        private Cas tcasWithFiles;

        public Cas CreateEcas() {
            if (ecas == null) {
                ecas = new Ecas();
            }
            return ecas;
        }

        public Cas CreateNoSentToTdmsEcas() {
            if (noSentToTdmsEcas == null) {
                noSentToTdmsEcas = new NoSentToTdmsEcas();
            }
            return noSentToTdmsEcas;
        }

        public Cas CreateTcas() {
            if (tcas == null) {
                tcas = new Tcas((Cas)CreateEcas());
            }
            return tcas;
        }

        public Cas CreateTcasWithFiles() {
            if (tcasWithFiles == null) {
                tcasWithFiles = new TcasWithFiles(CreateTcas());
            }
            return tcasWithFiles;
        }
    }
}
