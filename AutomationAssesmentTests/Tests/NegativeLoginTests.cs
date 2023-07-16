using Xunit.Abstractions;

namespace AutomationAssesmentTests.Tests
{
    public sealed class NegativeLoginTests : LoginTestsBase
    {
        public NegativeLoginTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void LoginWithEmptyCredentialsShowsUsernameRequiredMessage()
        {
            string anyUserName = "jibberish";
            string anyPassword = "youshallnotpass";
            string errorMessage = "Username is required";

            loginPage.EnterUserName(anyUserName);
            output.WriteLine("Entered {0} as username", anyUserName);
            
            loginPage.EnterPassword(anyPassword);
            output.WriteLine("Entered {0} as password", anyPassword);

            loginPage.ClearUserName();
            loginPage.ClearPassword();
            output.WriteLine("Cleared the username and password fields");

            loginPage.ClickLogin();
            output.WriteLine("Clicked the login button");

            var result = loginPage.GetError();
            output.WriteLine("Received the following error message: {0}", result);
            Assert.EndsWith(errorMessage, result);
        }

        [Fact]
        public void LoginWithEmptyPasswordShowsPasswordRequiredMessage()
        {
            string anyUserName = "jibberish";
            string anyPassword = "youshallnotpass";
            string errorMessage = "Password is required";

            loginPage.EnterUserName(anyUserName);
            output.WriteLine("Entered {0} as username", anyUserName);

            loginPage.EnterPassword(anyPassword);
            output.WriteLine("Entered {0} as password", anyPassword);

            loginPage.ClearPassword();
            output.WriteLine("Cleared the password field");


            loginPage.ClickLogin();
            output.WriteLine("Clicked the login button");

            var result = loginPage.GetError();
            output.WriteLine("Received the following error message: {0}", result);

            Assert.EndsWith(errorMessage, result);
        }
    }
}
