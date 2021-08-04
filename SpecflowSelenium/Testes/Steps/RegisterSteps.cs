using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowSelenium.Testes.PageObjects;
using TechTalk.SpecFlow;

namespace SpecflowSelenium.Testes.Steps
{
    [Binding]
    public sealed class RegisterSteps
    {

        private readonly IWebDriver _driver;

        private readonly ScenarioContext _scenarioContext;

        private RegisterPageObject _registerPageObject;

        public RegisterSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
        }

        #region PageObjects
        private RegisterPageObject RegisterPageObject
        {
            get
            {
                if (_registerPageObject == null)
                {
                    _registerPageObject = new RegisterPageObject(_driver);
                }

                return _registerPageObject;
            }
        }
        #endregion

        #region Dado
        [Given(@"que o usuário preenche os campos do registro com os seguintes valores")]
        public void DadoQueOUsuarioPreencheOsCamposDoRegistroComOsSeguintesValores(Table valoresFormulario)
        {
            foreach (var row in valoresFormulario.Rows)
            {
                var campo = row["Campo"];
                var valor = row["Valor"];

                switch (campo)
                {
                    case "First Name":
                        {
                            RegisterPageObject.FirstName.Clear();
                            RegisterPageObject.FirstName.SendKeys(valor);
                            break;
                        }
                    case "Last Name":
                        {
                            RegisterPageObject.LastName.Clear();
                            RegisterPageObject.LastName.SendKeys(valor);
                            break;
                        }
                    case "Address":
                        {
                            RegisterPageObject.Addres.Clear();
                            RegisterPageObject.Addres.SendKeys(valor);
                            break;
                        }
                    case "Email address":
                        {
                            RegisterPageObject.EmailAddress.Clear();
                            RegisterPageObject.EmailAddress.SendKeys(valor);
                            break;
                        }
                    case "Phone":
                        {
                            RegisterPageObject.Phone.Clear();
                            RegisterPageObject.Phone.SendKeys(valor);
                            break;
                        }
                    case "Gender":
                        {
                            RegisterPageObject.SelecionarGenero(valor);
                            break;
                        }
                    case "Hobbies":
                        {
                            RegisterPageObject.SelecionarHobbies(valor);
                            break;
                        }
                    case "Languages":
                        {
                            RegisterPageObject.SelecionarIdiomas(valor);
                            break;
                        }
                    case "Skills":
                        {
                            RegisterPageObject.SelecionarSkills(valor);
                            break;
                        }
                    case "Country":
                        {
                            RegisterPageObject.SelecionarPais(valor);
                            break;
                        }
                    case "Select Country":
                        {
                            RegisterPageObject.SelecionarPaises(valor);
                            break;
                        }
                    case "Date Of Birth":
                        {
                            RegisterPageObject.SelecionarDataDeAniversario(valor);
                            break;
                        }
                    case "Password":
                        {
                            RegisterPageObject.Password.Clear();
                            RegisterPageObject.Password.SendKeys(valor);
                            break;
                        }
                    case "Confirm Password":
                        {
                            RegisterPageObject.ConfirmPassword.Clear();
                            RegisterPageObject.ConfirmPassword.SendKeys(valor);
                            break;
                        }
                }
            }
        }
        #endregion

        #region Quando
        [When(@"o usuário solicita para enviar o formulário")]
        public void QuandoOUsuarioSolicitaParaEnviarOFormulario()
        {
            RegisterPageObject.Submit.Click();
        }
        #endregion

        #region Então
        [Then(@"visualiza a tela de registro com o título ""(.*)""")]
        public void EntaoVisualizaATelaDeRegistroComOTitulo(string tituloEsperado)
        {
            var tituloEncontrado = RegisterPageObject.RetornarTituloDaPagina();

            Assert.AreEqual(tituloEsperado, tituloEncontrado);
        }
        #endregion
    }
}
