using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class UpdateContext {
        internal TDMSApplication application;
        public UpdateContext(TDMSApplication application) {
            this.application = application;
            TdmsContext = new TdmsContext(application);
        }
        public TdmsContext TdmsContext { get; }
        private bool HasContent => TdmsContext.CaRoot.Objects.Count != 0;
        private List<IUpdateCorrectionActionsBehavior> CreateStrategies() {
            var strategies = new List<IUpdateCorrectionActionsBehavior>();
            if (HasContent) {
                strategies.Add(new UpdateFromEnoviaBehavior(this));
            } else {
                strategies.Add(new CreateNewItemsFromEnoviaBehavior(this));
            }
            return strategies;
        }
        public void CreateOrUpdateCorrectionActions() {
            CreateStrategies().ForEach(s => s.ProcessItems());
        }
    }

}
