using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingTool
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region RunTest_1
            //Googling_1 Googling_1 = new Googling_1();
            //Googling_1.Setup();
            //Googling_1.TestlinkAPISendResult();
            //Googling_1.Exit();
            #endregion
            #region RunTest_2
            WUICreateNewUser WUICreateNewUser = new WUICreateNewUser();
            WUICreateNewUser.Setup();
            WUICreateNewUser.TestlinkAPISendResult();
          //  WUICreateNewUser.Exit();
            #endregion
        }
    }

    public class TestResult
    {
        public Int32 IssueId { get; set; }
        public String Message { get; set; }
    }

}