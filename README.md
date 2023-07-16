For this task, please, use the Selenium WebDriver, framework unit test, and Page Object concepts. Automate the following script: Launch Url https://www.saucedemo.com/

UC -1 - Test Login form with empty credentials:

Type any credentials.

Clear the inputs.

Check the error messages:

3.1 Username is required.

UC -2 - Test Login form with credentials by passing Username:

Type any credentials in username.
Enter password and Clear the input.
Check the error messages:
3.1 Password is required.
UC -3 - Test Login form with credentials by passing Username & Password:

Type credentials in username which are under Accepted username are sections.
Enter password as secret sauce.
Click on Login and validate the title �Swag Labs� in the dashboard.
Provide parallel execution, add logging for test s and use Data Provider to parametrize tests. Make sure that all tasks supported by this 3 conditions: 1. UC - 1; 2. UC - 2; 3. UC -3.