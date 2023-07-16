using AutomationAssesmentTests.Configuration;
using AutomationAssesmentTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Xunit.Abstractions;

namespace AutomationAssesmentTests.Tests
{

    public class LoginTestsBase : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly string url = "https://www.saucedemo.com/";
        protected readonly LoginPage loginPage;
        protected readonly ITestOutputHelper output;
        public LoginTestsBase(ITestOutputHelper output)
        {
            this.output = output;
            driver = CreateDriver(ConfigurationProvider.Configuration["browser"]);
            output.WriteLine("Created the driver");
            loginPage = new LoginPage(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        private IWebDriver CreateDriver(string browserName)
        {
            return browserName.ToLower() switch
            {
                "chrome" => new ChromeDriver(),
                "firefox" => new FirefoxDriver(),
                _ => throw new ArgumentException("This browser is not supported",nameof(browserName)),
            };
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            driver.Quit();
            output.WriteLine("The driver has quit");
        }
    }
}
