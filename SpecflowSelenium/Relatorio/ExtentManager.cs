using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using System;
using System.IO;

namespace SpecflowSelenium.Relatorio
{
    public class ExtentManager
    {
        private const Theme standard = Theme.Standard;
        private static readonly Lazy<AventStack.ExtentReports.ExtentReports> _lazy = new Lazy<AventStack.ExtentReports.ExtentReports>(() => new AventStack.ExtentReports.ExtentReports());

        public static AventStack.ExtentReports.ExtentReports Instance { get { return _lazy.Value; } }

        static ExtentManager()
        {
            if (!Directory.Exists(@"..\..\Log\"))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(@"..\..\Log\");
            }
            var htmlReporter = new ExtentHtmlReporter(TestContext.CurrentContext.TestDirectory + @"\..\..\Log\Relatorio_Execucao_.html");
            htmlReporter.Config.DocumentTitle = "Extent/NUnit Samples";
            htmlReporter.Config.ReportName = "Extent/NUnit Samples";
            htmlReporter.Config.Theme = standard;

            Instance.AttachReporter(htmlReporter);
        }

        private ExtentManager()
        {
        }
    }
}