using Xunit.Abstractions;

namespace AutomationAssesmentTests.Tests
{
    public sealed class PositiveLoginTests : LoginTestsBase
    {
        public PositiveLoginTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData("standard_user", "secret_sauce")]
        [InlineData("problem_user", "secret_sauce")]
        [InlineData("performance_glitch_user", "secret_sauce")]
        public void LoginWithValidCredentialSucceeds(string userName, string password)
        {
            string dashboardTitle = "Swag Labs";

            loginPage.Login(userName, password);
            output.WriteLine("Logged in with {0} as username and {1} as password", userName, password);

            var result = loginPage.GetTitle();
            output.WriteLine("The title of the new page is {0}", result);
            Assert.Equal(dashboardTitle, result);
        }
    }
}
