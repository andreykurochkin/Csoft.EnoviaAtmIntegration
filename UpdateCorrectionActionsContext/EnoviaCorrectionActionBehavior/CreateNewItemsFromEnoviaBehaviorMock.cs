using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    public class CreateNewItemsFromEnoviaBehaviorMock : CreateNewItemsFromEnoviaBehavior
    {
        public CreateNewItemsFromEnoviaBehaviorMock(UpdateContext client) : base (client) { }

        protected override IEnumerable<ICa> GetEnoviaCorrectionActions()
        {
            return Utility.GetObjects(@"c:\Users\kurochkin.andrei\Documents\02-work\01-Projects\01-web-service\content\results-Strings\EnoviaCorrectionActions\10-09-2020-9-30-46.txt");
        }
    }

    public class CreateFromFileBehaviorMock : IUpdateCorrectionActionsBehavior
    {
        //private DateTime exportDateTime;
        //private string fullPath;

        public void ProcessItems()
        {
            throw new NotImplementedException();
        }
    }
}
