using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using System.IO;
using Microsoft.Office.Core;
using Microsoft;
using Microsoft.Office;
using Microsoft.Office.Interop;
using Word = Microsoft.Office.Interop.Word;

namespace TestingTool
{
    [TestCaseIdentifier("SSMSW", "desctop")] //атрибуты, считываемые из csv в папке TestInitCSV
    public class SolarSecMSWord : TestCaseBaseDesctop
    {

        #region Test execution
        public override TestResult RunTestDesctop()
        {
            var directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Doc");
            var wordApp = new Word.Application();
//            wordApp.Visible = true;
            var wordDoc = wordApp.Documents.Open(directory + "\\" + "example.docx");
            wordApp.ActivePrinter = "Microsoft XPS Document Writer";
            wordDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
            wordApp.PrintOut(Background: true, Append: false, OutputFileName: directory + "\\" + "out.xps", PrintToFile: true, Pages: "2,4-6", PrintZoomColumn: 2);
            return TestResult.Success("Test successfully completed");            
        }
        #endregion
    }
}
