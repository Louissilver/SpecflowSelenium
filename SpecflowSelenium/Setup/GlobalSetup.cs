using TechTalk.SpecFlow;

namespace SpecflowSelenium.Setup
{
    [Binding]
    public class GlobalSetup
    {
        private BaseTest BaseTest { get; set; }

        [BeforeTestRun]
        public static void OneTimeSetUp()
        {
            SetupTest.OneTimeSetUp();
        }

        [BeforeScenario]
        public void Setup(ScenarioContext scenarioContext)
        {
            BaseTest = new BaseTest(scenarioContext.ScenarioInfo.Title);
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
