using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowSelenium.Testes.PageObjects
{
    class RegisterPageObject
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = "[ng-model='FirstName']")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[ng-model='LastName']")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[ng-model='Adress']")]
        public IWebElement Addres { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[ng-model='EmailAdress']")]
        public IWebElement EmailAddress { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[ng-model='Phone']")]
        public IWebElement Phone { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Gender*']/parent::div")]
        public IWebElement Gender { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Hobbies']/parent::div")]
        public IWebElement Hobbies { get; set; }

        [FindsBy(How = How.Id, Using = "msdd")]
        public IWebElement Languages { get; set; }

        [FindsBy(How = How.Id, Using = "Skills")]
        public IWebElement Skills { get; set; }

        [FindsBy(How = How.Id, Using = "countries")]
        public IWebElement Country { get; set; }

        [FindsBy(How = How.Id, Using = "country")]
        public IWebElement SelectCountry { get; set; }

        [FindsBy(How = How.Id, Using = "yearbox")]
        public IWebElement DateBirthYear { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[ng-model='monthbox']")]
        public IWebElement DateBirthMonth { get; set; }

        [FindsBy(How = How.Id, Using = "daybox")]
        public IWebElement DateBirthDay { get; set; }

        [FindsBy(How = How.Id, Using = "firstpassword")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "secondpassword")]
        public IWebElement ConfirmPassword { get; set; }

        [FindsBy(How = How.Id, Using = "submitbtn")]
        public IWebElement Submit { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[value='Refresh']")]
        public IWebElement Refresh { get; set; }

        public RegisterPageObject(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }

        public string RetornarTituloDaPagina()
        {
            var elementoTitulo = _driver.FindElement(By.CssSelector("div[class='container center'] h2"));
            return elementoTitulo.Text;
        }

        public void SelecionarGenero(string valor)
        {
            var elementoGenero = Gender.FindElement(By.XPath($"//input[@value='{valor}']"));
            elementoGenero.Click();
        }

        public void SelecionarHobbies(string hobbies)
        {
            var itens = hobbies.Split(", ");
            foreach (var item in itens)
            {
                var elementoGenero = Hobbies.FindElement(By.XPath($"//input[@value='{item}']"));
                elementoGenero.Click();
            }
        }

        public void SelecionarIdiomas(string idiomas)
        {
            var itens = idiomas.Split(", ");

            Languages.Click();

            foreach (var item in itens)
            {
                var elementoGenero = Languages.FindElement(By.XPath($"//parent::multi-select//ul/li/a[text()='{item}']"));
                elementoGenero.Click();
            }

            FirstName.Click();
        }

        public void SelecionarPais(string valor)
        {
            Country.Click();

            var opcao = Country.FindElement(By.CssSelector($"option[value='{valor}']"));
            opcao.Click();
        }

        public void SelecionarPaises(string valor)
        {
            var comboboxPaises = SelectCountry.FindElement(By.XPath("//parent::div//span[@role='combobox']"));
            comboboxPaises.Click();

            var opcao = SelectCountry.FindElement(By.XPath($"//ul[@id='select2-country-results']/li[text()='{valor}']"));
            opcao.Click();

            FirstName.Click();
        }

        public void SelecionarSkills(string valor)
        {
            Skills.Click();

            var opcao = Skills.FindElement(By.CssSelector($"option[value='{valor}']"));
            opcao.Click();

            FirstName.Click();
        }

        public void SelecionarDataDeAniversario(string valor)
        {
            var ano = valor.Split("/")[0];
            var mes = valor.Split("/")[1];
            var dia = valor.Split("/")[2];

            DateBirthYear.Click();
            DateBirthYear.FindElement(By.CssSelector($"option[value='{ano}']"));

            DateBirthMonth.Click();
            DateBirthMonth.FindElement(By.CssSelector($"option[value='{mes}']"));

            DateBirthDay.Click();
            DateBirthDay.FindElement(By.CssSelector($"option[value='{dia}']"));
        }
    }
}
