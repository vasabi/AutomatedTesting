using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
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
            try
            {
                var watch = new Stopwatch();
                var directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Doc");
                var wordApp = new Word.Application();
                String printResult;
                //            wordApp.Visible = true;
                var wordDoc = wordApp.Documents.Open(directory + "\\" + "test.docx");
                watch.Reset();
                watch.Start();
                wordApp.ActivePrinter = "Microsoft XPS Document Writer";
                wordDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
                wordDoc.PrintOut(Background: true, Range: Word.WdPrintOutRange.wdPrintRangeOfPages, Pages: "2,4-6", Append: false, OutputFileName: directory + "\\" + "out.oxps", PrintToFile: true, PrintZoomRow: 1, PrintZoomColumn: 2);
                wordDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientPortrait;
                printResult = "failed";
                if (wordApp.BackgroundPrintingStatus == 1)
                {
                    printResult = "successed";
                }
                watch.Stop();
                File.WriteAllText(directory + "\\" + "log.txt", "File printing was " + printResult + ". Elapsed teme = " + watch.ElapsedMilliseconds + "ms");
                wordApp.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
                wordApp.ActiveDocument.Close();
                wordApp.Quit();
                if (wordDoc != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordDoc);
                if (wordApp != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                wordDoc = null;
                wordApp = null;
                return TestResult.Success("Test SSMSW successfully completed");
            }
            catch 
            {
                return TestResult.Fail("Test SSMSW failed");
            }
        }
        #endregion
    }
}
