using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace AutomationAssesmentTests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver webDriver)
        {
            this.driver = webDriver;
        }

        private IWebElement UserNameInput => driver.FindElement(By.Id("user-name"));
        private IWebElement PasswordInput => driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => driver.FindElement(By.Id("login-button"));

        private IWebElement ErrorMessage => driver.FindElement(By.XPath("//*[contains(@class, 'error-message-container')]"));

        private IWebElement HeaderMessage => driver.FindElement(By.XPath("//*[@id='header_container']//*[contains(@class,'header_label')]//*[contains(@class,'app_logo')]"));

        public void Login(string username, string password)
        {
            EnterUserName(username);
            EnterPassword(password);
            ClickLogin();
        }

        public void EnterPassword(string password)
        {
            PasswordInput.SendKeys(password);
        }

        public void EnterUserName(string username)
        {
            UserNameInput.SendKeys(username);
        }

        public void ClearUserName()
        {
            ClearInput(UserNameInput);
        }

        public void ClearPassword()
        {
            ClearInput(PasswordInput);
        }

        private void ClearInput(IWebElement input)
        {
            input.Click();
            string value = input.GetAttribute("value");
            int length = string.IsNullOrEmpty(value) ? 0: value.Length;
            for (int i = 0; i < length; i++)
            {
                input.SendKeys(Keys.Backspace);
            }
        }

        public void ClickLogin()
        {
            LoginButton.Submit();
        }

        public string GetError()
        {
            return ErrorMessage.Text;
        }

        public string GetTitle()
        {
            return HeaderMessage.Text;
        }
    }
}
