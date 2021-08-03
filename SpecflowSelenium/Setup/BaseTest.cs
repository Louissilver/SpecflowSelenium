using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;
using System.IO;
using System;
using SpecflowSelenium.Drivers;

namespace SpecflowSelenium.Setup
{
    public class BaseTest
    {

        protected string FilePath { get; private set; }

        private string _nomeDoTesteCorrente;

        public IWebDriver _driver { get; set; }

        public IConfigurationRoot Configuration { get; set; }

        public BaseTest(string nomeDoTesteCorrente = null)
        {
            _nomeDoTesteCorrente = nomeDoTesteCorrente;
            var builder = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        [SetUp]
        public void Setup()
        {
            InicializarDriver();
        }

        [TearDown]
        public virtual void Cleanup()
        {
            EncerrarDriver();
        }

        #region Métodos de apoio

        private void InicializarDriver(string url = null)
        {
            var diretorioPadraoDoProjeto = Path.GetDirectoryName(typeof(BaseTest).Assembly.Location).Replace("\\", "/");

            if (url == null)
            {
                url = Configuration["appsettings:UrlAplicacao"];
            }

            var rodarChromeHeadless = Configuration["appsettings:chromeHeadless"];
            var browser = Configuration["appsettings:browser"];
            _nomeDoTesteCorrente = RetornarNomeDoTesteCorrenteFormatado();

            _driver = GerenciadorDeBrowser.AbrirJanelaBrowser(diretorioPadraoDoProjeto, browser, rodarChromeHeadless);


            _driver.Navigate().GoToUrl(url);


            FilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Arquivos"));


            _driver.Manage().Window.Maximize();
        }

        private void EncerrarDriver()
        {
            if (_driver != null)
            {
                _driver.Close();
                _driver.Quit();
                _driver = null;
            }
        }

        private string RetornarNomeDoTesteCorrenteFormatado()
        {
            if (string.IsNullOrEmpty(_nomeDoTesteCorrente))
            {
                var descricao = TestContext.CurrentContext.Test.Properties["Description"];

                _nomeDoTesteCorrente = descricao.Count() != 0
                    ? descricao.FirstOrDefault().ToString()
                    : TestContext.CurrentContext.Test.Name;
            }

            return _nomeDoTesteCorrente.Replace(": ", "_").Replace("\"", "_").Replace("__", "_");
        }

        #endregion
    }
}
