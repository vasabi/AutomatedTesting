#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using System.IO;
using Meyn.TestLink;
using CookComputing.XmlRpc;
#endregion

namespace TestingTool
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var asseblyPath = "";
            //var assembly = Assembly.LoadFile(asseblyPath);
            #region далее чтение конфигов тестов, запуск выполнения сценариев для каждой платформы
            var assembly = Assembly.GetEntryAssembly();
            String[] files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"TestInitCSV"), "*.csv", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                String[] testCaseConfigs = File.ReadAllLines(file);
                //String[] platforms = new String[] {"Google Chrome","Firefox","IE"};
                String[] platforms = new String[] { "Google Chrome"};

                foreach (var testCaseConfig in testCaseConfigs)
                {
                    String[] parameter = testCaseConfig.Split(';');
                    var testCaseName = parameter[0];
                    var testCaseType = parameter[1];

                    var caseType = assembly.GetTypes().FirstOrDefault(t =>
                    {
                        var attr = t.GetCustomAttribute<TestCaseIdentifierAttribute>();
                        if (attr != null)
                            return attr.TestCaseName == testCaseName && attr.TestCaseType == testCaseType;
                        return false;
                    });

                    if (caseType == null)
                    {
                        Console.WriteLine("There are no classes to run test with name: " + testCaseName +" or csv file is invalid");
                        break;
                    }

                    var caseObject = (TestCaseBase)Activator.CreateInstance(caseType);

                    if (testCaseType == "web")
                    {
                        foreach (var platform in platforms)
                        {
                            var test = new TestCaseWrapper(caseObject, testCaseName, testCaseType);
                            try
                            {
                                using (test)
                                {
                                    test.SetPlatform(platform).Run();
                                }
                            }

                            catch (Exception exception)
                            {
                                Console.WriteLine("EXCEPTION:" + exception.Message);
                            }
                        }
                    }
                    else
                    {
                        var test = new TestCaseWrapper(caseObject, testCaseName, testCaseType);
                        try
                        {
                            using (test)
                            {
                                test.Run();
                            }
                        }

                        catch (Exception exception)
                        {
                            Console.WriteLine("EXCEPTION:" + exception.Message);
                        }
                    }
                }
            }
            #endregion

            #region Выход из консоли
            ConsoleKeyInfo OnExit;
            do
            {
                Console.WriteLine("Press Esc to exit");
                OnExit = Console.ReadKey();
            }
            while (OnExit.Key != ConsoleKey.Escape);
            #endregion
        }
    }
}