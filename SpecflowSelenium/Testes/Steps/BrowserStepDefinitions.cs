using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecflowSelenium.Testes.Steps
{
    [Binding]
    public sealed class BrowserStepDefinitions
    {

        private readonly IWebDriver _driver;

        private readonly ScenarioContext _scenarioContext;

        public BrowserStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<IWebDriver>();
        }

        [Given(@"I select the first item")]
        public void GivenISelectTheFirstItem()
        {
            _driver.FindElement(By.Name("li1")).Click();
        }

        [Given(@"I select the second item")]
        public void GivenISelectTheSecondItem()
        {
            _driver.FindElement(By.Name("li2")).Click();
        }

        [Given(@"I enter the new value in textbox")]
        public void GivenIEnterTheNewValueInTextbox()
        {
            IWebElement textfield = _driver.FindElement(By.Id("sampletodotext"));
            textfield.SendKeys("sampletodotext");
        }

        [When(@"I click the Submit button")]
        public void WhenIClickTheSubmitButton()
        {
            IWebElement addButton = _driver.FindElement(By.Id("addbutton"));
            addButton.Click();
        }

        [Then(@"I verify wheter the item is added to the list")]
        public void ThenIVerifyWheterTheItemIsAddedToTheList()
        {
            Assert.That(_driver.FindElement(By.XPath("/html/body/div/div/div/ul/li[6]/span")).Text, Is.EqualTo("sampletodotext"));
        }
    }
}
