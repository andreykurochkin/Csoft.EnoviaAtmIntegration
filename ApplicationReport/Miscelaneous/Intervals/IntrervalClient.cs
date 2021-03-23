using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Tdms.Api;
using Tdms;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    /// <summary>
    /// acquires blocks numbers via different strategies
    /// </summary>
    public class BlocksNumbersClient
    {
        private TDMSObject document;

        public BlocksNumbersClient(TDMSObject document)
        {
            this.document = document;
        }

        public List<int> GetNumbers()
        {
            var strategy = GetStrategy();
            if (strategy == null) return new List<int>();
            return strategy.GetNumbers();
        }

        private BlocksNumbersStrategy GetStrategy()
        {
            var input = new InitialDataOfBlockNumbersStrategies(document);

            BlocksNumbersStrategy strategy = new DocumentBlocks(input.GetAttribute());
            if (strategy.IsAplicable) return strategy;

            strategy = new FolderBlocks(input.GetTable());
            if (strategy.IsAplicable) return strategy;

            strategy = new NppBlocks(input.GetNpp());
            if (strategy.IsAplicable) return strategy;

            return new DefaultBlocksStrategy();
        }

    }
}
