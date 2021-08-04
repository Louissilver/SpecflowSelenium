using AventStack.ExtentReports;
using log4net;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SpecflowSelenium.Relatorio;
using System;
using System.IO;

namespace SpecflowSelenium.Drivers
{
    public class ResultadosTeste
    {
        public void Resultados(IWebDriver driver, TestStatus status, ILog log, string screenshotsPasta, string nomeDoTesteCorrente)
        {
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;


            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fatal;

                    LogErro(log);

                    FazerScreenshotSePastaNaoForNula(driver, screenshotsPasta, nomeDoTesteCorrente);

                    break;

                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;

                    LogErro(log);

                    FazerScreenshotSePastaNaoForNula(driver, screenshotsPasta, nomeDoTesteCorrente);

                    break;

                case TestStatus.Skipped:
                    logstatus = Status.Skip;

                    LogErro(log);

                    FazerScreenshotSePastaNaoForNula(driver, screenshotsPasta, nomeDoTesteCorrente);

                    break;

                default:
                    logstatus = Status.Pass;

                    break;
            }

            ExtentTestManager.GetTest().Log(logstatus, "Teste finalizado com " + logstatus + stacktrace);
        }

        private void LogErro(ILog log)
        {
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            var mensagem = TestContext.CurrentContext.Result.Message;

            log.Fatal(mensagem + " " + stackTrace);
        }

        public void CapturarScreenshot(IWebDriver driver, string screenshotsPasta, string nomeDoTesteCorrente)
        {
            var screenshot = driver is ITakesScreenshot;

            if (!screenshot)
            {
                return;
            }

            var hash = TestContext.CurrentContext.GetHashCode().ToString();

            var nomeArquivo = $"{screenshotsPasta}\\{nomeDoTesteCorrente}_{hash}.png";

            var screen = ((ITakesScreenshot)driver).GetScreenshot();

            if (!Directory.Exists(screenshotsPasta))
            {
                Directory.CreateDirectory(screenshotsPasta);
            }

            screen.SaveAsFile(nomeArquivo, ScreenshotImageFormat.Png);
        }

        private void FazerScreenshotSePastaNaoForNula(IWebDriver driver, string screenshotsPasta, string nomeDoTesteCorrente)
        {
            if (!String.IsNullOrEmpty(screenshotsPasta))
            {
                CapturarScreenshot(driver, screenshotsPasta, nomeDoTesteCorrente);
            }
        }
    }
}
