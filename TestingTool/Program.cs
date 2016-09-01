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
            #region Чтение параметров подключения к testlink из конфига
            String apiUrl = ConfigurationManager.AppSettings["testLinkUrl"];
            String apiKey = ConfigurationManager.AppSettings["testLinkApiKey"];
            #endregion

            //var asseblyPath = "";
            //var assembly = Assembly.LoadFile(asseblyPath);
            #region далее чтение конфигов тестов, запуск выполнения сценариев для каждой платформы
            var assembly = Assembly.GetEntryAssembly();
            String[] files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"TestInitCSV"), "*.csv", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                String[] testCaseConfigs = File.ReadAllLines(file);
                var platforms = testCaseConfigs[0].Split(';');

                if (testCaseConfigs.Length < 2)
                {
                    Console.WriteLine("ERROR: CSV file is not valid");
                    break;
                }
                for (int i = 1; i < testCaseConfigs.Length; i++)
                {
                    String testCaseConfig = testCaseConfigs[i];
                    String[] parameter = testCaseConfig.Split(';');
                    var projectName = parameter[0];
                    var testPlanName = parameter[1];
                    var testSuitName = parameter[2];
                    var testCaseName = parameter[3];

                    var caseType = assembly.GetTypes().FirstOrDefault(t =>
                    {
                        var attr = t.GetCustomAttribute<TestCaseIdentifierAttribute>();
                        if (attr != null)
                            return attr.ProjectName == projectName && attr.TestSuiteName == testSuitName
                                && attr.TestCaseName == testCaseName;
                        return false;
                    });

                    if (caseType == null)
                    {
                        Console.WriteLine("There are no classes to run test with name: " + testCaseName +" or csv file is invalid");
                        break;
                    }

                    var caseObject = (TestCaseBase)Activator.CreateInstance(caseType);

                    foreach (var platform in platforms)
                    {
                        var test = new TestLinkCaseWrapper(caseObject, apiKey, apiUrl, platform, projectName, testPlanName, testSuitName, testCaseName);
                        try
                        {
                            using (test)
                            {
                                test.SetPlatform(platform).Run();
                            }
                        }
                        catch (XmlRpcMissingUrl exception)
                        {
                            Console.WriteLine("ERROR:" + exception.Message);
                            break;
                        }
                        catch (TestLinkException  exception)
                        {
                            Console.WriteLine("ERROR:" + exception.Message);
                            break;
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