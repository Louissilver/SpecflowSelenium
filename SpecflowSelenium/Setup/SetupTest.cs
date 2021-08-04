using NUnit.Framework;
using SpecflowSelenium.Relatorio;
using System;
using System.IO;

namespace SpecflowSelenium.Setup

{
    public static class SetupTest
    {
        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(typeof(SetupTest).Assembly.Location);

            var diretorioScreenshot = @"..\..\Screenshots\";
            var diretorioLog = @"..\..\Log\";

            if (Directory.Exists(diretorioScreenshot))
            {
                Directory.Delete(diretorioScreenshot, true);
            }

            if (Directory.Exists(diretorioLog))
            {
                Directory.Delete(diretorioLog, true);
            }

            Directory.CreateDirectory(diretorioScreenshot);
            Directory.CreateDirectory(diretorioLog);
        }

        [OneTimeTearDown]
        public static void TearDownExtentReports()
        {
            ExtentManager.Instance.Flush();
        }
    }
}
