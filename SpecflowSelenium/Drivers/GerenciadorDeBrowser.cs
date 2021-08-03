using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace SpecflowSelenium.Drivers
{
    /// <summary>
    /// Classe reponsável pelo gerenciamento e abertura do browser a ser utilizado pela execução do teste
    /// </summary>
	public class GerenciadorDeBrowser
    {
        protected GerenciadorDeBrowser() { }

        /// <summary>
        /// Configura o browser desejado 
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="plataforma"></param>
        /// <returns>Retorna a configuiração nec essária para a abertura do browser</returns>
        public static ICapabilities RetornarBrowser(string browser, string plataforma, string nomeDoTesteCorrente, string chromeHeadless = "")
        {
            ICapabilities capacidade;

            switch (browser)
            {
                case "chrome":
                    {
                        var opcoesChrome = new ChromeOptions();

                        if (plataforma.ToLower().Equals("linux"))
                        {
                            opcoesChrome.AddAdditionalCapability(CapabilityType.Platform, new Platform(PlatformType.Linux), true);
                            opcoesChrome.AddAdditionalCapability("name", nomeDoTesteCorrente, true);
                            opcoesChrome.AddAdditionalCapability("idleTimeout", 450, true);
                            opcoesChrome.AddAdditionalCapability("tz", "America/Sao_Paulo", true);
                            opcoesChrome.AddAdditionalCapability(CapabilityType.AcceptInsecureCertificates, true, true);
                            opcoesChrome.AddAdditionalCapability(CapabilityType.AcceptSslCertificates, true, true);
                            opcoesChrome.AddUserProfilePreference("download.default_directory", @"..//Downloads");

                            if (chromeHeadless == "sim")
                            {
                                opcoesChrome.AddArguments("--headless");
                            }

                        }

                        capacidade = opcoesChrome.ToCapabilities();
                        break;
                    }
                case "firefox":
                    {
                        var opcoesFirefox = new FirefoxOptions();


                        if (plataforma.ToLower().Equals("linux"))
                        {
                            opcoesFirefox.AddAdditionalCapability(CapabilityType.Platform, new Platform(PlatformType.Linux), true);
                            opcoesFirefox.AddAdditionalCapability("name", nomeDoTesteCorrente, true);
                            opcoesFirefox.AddAdditionalCapability("idleTimeout", 480, true);
                            opcoesFirefox.AddAdditionalCapability("tz", "America/Sao_Paulo", true);
                            opcoesFirefox.AddAdditionalCapability(CapabilityType.AcceptInsecureCertificates, true, true);
                            opcoesFirefox.AddAdditionalCapability(CapabilityType.AcceptSslCertificates, true, true);
                            opcoesFirefox.Profile.SetPreference("download.default_directory", @"..//Downloads");

                            if (chromeHeadless == "sim")
                            {
                                opcoesFirefox.AddArguments("--headless");
                            }

                        }

                        capacidade = opcoesFirefox.ToCapabilities();
                        break;
                    }
                case "edge":
                    {
                        var opcoesEdge = new EdgeOptions();

                        if (plataforma.ToLower().Equals("linux"))
                        {
                            opcoesEdge.AddAdditionalCapability(CapabilityType.Platform, new Platform(PlatformType.Linux));
                            opcoesEdge.AddAdditionalCapability("name", nomeDoTesteCorrente);
                            opcoesEdge.AddAdditionalCapability("idleTimeout", 480);
                            opcoesEdge.AddAdditionalCapability("tz", "America/Sao_Paulo");
                        }

                        capacidade = opcoesEdge.ToCapabilities();
                        break;
                    }
                default:
                    {
                        throw new Exception("Browser " + browser + "não permitido.");
                    }
            }

            return capacidade;

        }

        /// <summary>
        /// Método responsável pela abertura da janela do browser desejado
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="plataforma"></param>
        /// <returns>Retorna o browser aberto</returns>
        public static IWebDriver AbrirJanelaBrowser(string diretorioPadraoDoProjeto, string browser, string chromeHeadless = "")
        {
            IWebDriver driver;

            switch (browser)
            {
                case "chrome":
                    {
                        var opcoesChrome = new ChromeOptions();
                        opcoesChrome.AddAdditionalCapability(CapabilityType.AcceptInsecureCertificates, true, true);
                        opcoesChrome.AddAdditionalCapability(CapabilityType.AcceptSslCertificates, true, true);
                        opcoesChrome.AddUserProfilePreference("download.default_directory", @"..//Downloads");

                        if (chromeHeadless == "sim")
                        {
                            opcoesChrome.AddArguments("--headless");
                        }

                        driver = new ChromeDriver(diretorioPadraoDoProjeto, opcoesChrome);

                        return driver;
                    }
                case "firefox":
                    {
                        var opcoesFirefox = new FirefoxOptions();
                        opcoesFirefox.AddAdditionalCapability(CapabilityType.AcceptInsecureCertificates, true, true);
                        opcoesFirefox.AddAdditionalCapability(CapabilityType.AcceptSslCertificates, true, true);
                        opcoesFirefox.SetPreference("browser.download.dir", @"..//Downloads");

                        driver = new FirefoxDriver(diretorioPadraoDoProjeto, opcoesFirefox);
                        return driver;
                    }
                case "edge":
                    {
                        var opcoesEdge = new EdgeOptions();
                        opcoesEdge.AddAdditionalCapability(CapabilityType.AcceptInsecureCertificates, true);
                        opcoesEdge.AddAdditionalCapability(CapabilityType.AcceptSslCertificates, true);
                        opcoesEdge.AddAdditionalCapability("acceptSslCerts", "true");

                        driver = new EdgeDriver(diretorioPadraoDoProjeto, opcoesEdge);
                        return driver;
                    }

                default:
                    {
                        throw new Exception("Browser " + browser + "não permitido");
                    }
            }
        }
    }
}