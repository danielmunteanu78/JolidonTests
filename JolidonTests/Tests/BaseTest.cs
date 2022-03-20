using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using JolidonTests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace JolidonTests.Tests
{
    class BaseTest
    {
        ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        public IWebDriver _driver;
        public static ExtentReports _extent;
        public ExtentTest _test;
        public string testName;

        [OneTimeSetUp]
        protected void ExtentStart()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            DateTime time = DateTime.Now;
            var reportPath = projectPath + "Reports\\Report_" + time.ToString("h_mm_ss")+ ".html";
            var htmlReporter = new ExtentV3HtmlReporter(reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("Host Name", Environment.MachineName);
            _extent.AddSystemInfo("Enviroment", "Test ENV");
            _extent.AddSystemInfo("Username", "Dan M");
            htmlReporter.LoadConfig(projectPath + "report-config.xml");
        }

        [SetUp]
        public void Setup()
        {
            driver.Value = Browsers.GetDriver();
            _driver = driver.Value;
        }

        [TearDown]
        public void TearDown()
        {
            var currentStatus = TestContext.CurrentContext.Result.Outcome.Status;            
            var currentStackTrace = TestContext.CurrentContext.Result.StackTrace;
            var stackTrace = string.IsNullOrEmpty(currentStackTrace) ? "" : currentStackTrace;
            Status logstatus = Status.Pass;
            String filename, screenshotPath;
            DateTime time = DateTime.Now;
            filename = "SShot_" + time.ToString("HH_mm_ss") + testName + ".png";
            switch (currentStatus)
            {
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                {
                        logstatus = Status.Fail;
                        var screenshotEntity = Utils.CaptureScreenShot(_driver, filename);
                        _test.Log(Status.Fail, "Fail");
                        _test.Fail("Test failed: ", screenshotEntity);                        
                        break;
                }

                case NUnit.Framework.Interfaces.TestStatus.Passed:
                    {
                        logstatus = Status.Pass;
                        _test.Log(Status.Pass, "Passed");
                        _test.Pass("Test passed:", Utils.CaptureScreenShot(_driver, filename));
                        break;
                    }
                case NUnit.Framework.Interfaces.TestStatus.Inconclusive:
                    {
                        logstatus = Status.Warning;
                        _test.Log(Status.Warning, "Test is inconclusive");
                        break;
                    }
                case NUnit.Framework.Interfaces.TestStatus.Skipped:
                    {
                        logstatus = Status.Skip;
                        _test.Log(Status.Skip, "Test is skipped");
                        break;
                    }
                default:
                    {
                        logstatus = Status.Error;
                        _test.Log(Status.Error, "The test had errors while running");
                        break;
                    }
            }
            _test.Log(logstatus, "Test " + testName + " was " + logstatus + "\n" + stackTrace);
            _driver.Quit();
        }

        [OneTimeTearDown]
        public void AllTeardown()
        {
            _extent.Flush();
        }

    }
}
