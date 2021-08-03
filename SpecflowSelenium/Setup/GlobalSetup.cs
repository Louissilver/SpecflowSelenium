using TechTalk.SpecFlow;

namespace SpecflowSelenium.Setup
{
    [Binding]
    public class GlobalSetup
    {
        private BaseTest BaseTest { get; set; }

        [BeforeScenario]
        public void Setup(ScenarioContext scenarioContext)
        {
            BaseTest = new BaseTest();
            BaseTest.Setup();

            scenarioContext.Set(BaseTest._driver);
        }

        [AfterScenario]
        public virtual void Cleanup()
        {
            BaseTest.Cleanup();
        }
    }
}
