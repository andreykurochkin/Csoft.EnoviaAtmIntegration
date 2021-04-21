using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Tdms.Api;
using Tdms;
using Csoft.Tdms.Common.Attributes;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    public class NppBlocks : BlocksNumbersStrategy
    {
        private TDMSObject npp;

        public NppBlocks(TDMSObject npp)
        {
            this.npp = npp;
        }

        public override List<int> GetNumbers()
        {
            var result = new List<int>();

            GetBlocks().ForEach(block =>
            {
                int foo;
                string blockNumber = new StringTdmsAttributeValueBehavior(block.Attributes["A_Block_Number"]).GetValue();
                if (int.TryParse(blockNumber, out foo)) result.Add(foo);
            });

            return result;
        }

        protected override bool GetIsAplicable()
        {
            return !(GetBlocks().Count() == 0);
        }

        private IEnumerable<TDMSObject> GetBlocks() => npp.Content.ObjectsByDef("O_Block");
    }
}
