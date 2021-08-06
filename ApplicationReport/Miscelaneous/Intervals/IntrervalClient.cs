using System.Collections.Generic;
using Tdms.Api;
using Tdms;
using Csoft.Common.NumbersInterval;
using Csoft.Tdms.Common.Attributes;
using System.Linq;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// acquires blocks numbers via different strategies
    /// </summary>
    public class BlocksNumbersClient {
        private TDMSObject document;
        public BlocksNumbersClient(TDMSObject document) {
            this.document = document;
        }
        public List<int> GetNumbers() {
            var strategy = GetStrategy();
            if (strategy == null) return new List<int>();
            return strategy.Numbers.Values.Select(i => (int)i).ToList();
        }
        private INumbersStrategy GetStrategy() {
            var input = new InitialDataOfBlockNumbersStrategies(document);
            INumbersStrategy strategy;
            strategy = new DocumentBlocks(new StringTdmsAttributeValueBehavior(input.GetAttribute()).GetValue());
            if (strategy.IsAplicable) {
                return strategy;
            }
            strategy = new FolderBlocks(input.GetAttributeValuesFromTable(input.GetTable()));
            if (strategy.IsAplicable) {
                return strategy;
            }
            strategy = new BlocksOfDesignObject(
               input.GetBlocksNumbersAsStrings(input.GetBlocks(input.GetNpp()))
            );
            if (strategy.IsAplicable) {
                return strategy;
            }
            return new DefaultBlocksStrategy();
        }
    }
}
