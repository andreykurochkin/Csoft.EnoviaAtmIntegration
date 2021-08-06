using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain.Tests
{
    class CreateBlocksNumbersTest : ITdmsTest {
        // TODO move to unit tests
        //private TDMSApplication application;
        //public CreateBlocksNumbersTest(TDMSApplication application) => this.application = application;

        //public void Execute()
        //{
        //    TestDocumentBlocks1();
        //    TestDocumentBlocks2();
        //    TestFolderBlocks1();
        //    TestFoldersBlock();
        //    TestNppsBlock();
        //}

        //private void TestDocumentBlocks1()
        //{
        //    var guid = "{70167460-4FA4-4F12-AB83-53E8E0CB4D8A}";
        //    var document = application.GetObjectByGUID(guid);
        //    var attribute = document.Attributes["A_Block_Number"];
        //    BlocksNumbersStrategy blocksNumbers = new DocumentBlocks(attribute);
        //    Console.WriteLine(blocksNumbers.GetType());
        //    Console.WriteLine($"{nameof(blocksNumbers.IsAplicable)}: {blocksNumbers.IsAplicable}");
        //    Console.WriteLine($"{nameof(blocksNumbers.GetNumbers)}: {Print(blocksNumbers.GetNumbers())}");
        //    Console.WriteLine();
        //}

        //private void TestDocumentBlocks2()
        //{
        //    var guid = "{B9B204A4-0800-4746-8AC6-94EC022B78B4}";
        //    var document = application.GetObjectByGUID(guid);
        //    var attribute = document.Attributes["A_Block_Number"];
        //    BlocksNumbersStrategy blocksNumbers = new DocumentBlocks(attribute);
        //    Console.WriteLine(blocksNumbers.GetType());
        //    Console.WriteLine($"{nameof(blocksNumbers.IsAplicable)}: {blocksNumbers.IsAplicable}");
        //    Console.WriteLine($"{nameof(blocksNumbers.GetNumbers)}: {Print(blocksNumbers.GetNumbers())}");
        //    Console.WriteLine();
        //}

        //private void TestFolderBlocks1()
        //{
        //    var guid = "{2BCFADEE-42FF-4E7D-8C8C-C5A50A076A16}";
        //    PrintFolderBlocks(application.GetObjectByGUID(guid));
        //}

        //private void PrintFolderBlocks(TDMSObject folder)
        //{
        //    var table = folder.Attributes["A_Blocks_Tbl"];
        //    BlocksNumbersStrategy blocksNumbers = new FolderBlocks(table);
        //    Console.WriteLine(blocksNumbers.GetType());
        //    Console.WriteLine($"{nameof(blocksNumbers.IsAplicable)}: {blocksNumbers.IsAplicable}");
        //    Console.WriteLine($"{nameof(blocksNumbers.GetNumbers)}: {Print(blocksNumbers.GetNumbers())}");
        //    Console.WriteLine();
        //}

        //private void TestFoldersBlock()
        //{
        //    var folders = application.ObjectDefs["O_Folder_Doc"].Objects;
        //    Console.WriteLine($"amount of folders: {folders.Count}");
        //    folders.ForEach(folder => PrintFolderBlocks(folder));
        //}

        //private void TestNppsBlock()
        //{
        //    var npps = application.ObjectDefs["O_Object"].Objects;
        //    npps.ForEach(npp => PrintNppBlocks(npp));
        //}

        //private void PrintNppBlocks(TDMSObject npp)
        //{
        //    var blocks = npp.Content.ObjectsByDef("O_Block");
        //    Console.WriteLine($"{npp.Description}: {blocks.Count} блоков");
        //    BlocksNumbersStrategy blocksNumbers = new BlocksOfDesignObject(npp);
        //    Console.WriteLine(blocksNumbers.GetType());
        //    Console.WriteLine($"{nameof(blocksNumbers.IsAplicable)}: {blocksNumbers.IsAplicable}");
        //    Console.WriteLine($"{nameof(blocksNumbers.GetNumbers)}: {Print(blocksNumbers.GetNumbers())}");
        //    Console.WriteLine();
        //}

        //private string Print(List<int> input)
        //{
        //    if (input == null) return $"{nameof(input)} is null";
        //    if (input.Count == 0) return $"{nameof(input)} count is 0";
        //    return string.Join("; ", input);
        //}
        public void Execute() {
            throw new NotImplementedException();
        }
    }
}
