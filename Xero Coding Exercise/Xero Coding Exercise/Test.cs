using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading.Tasks;

//As a Xero User,
//In order to manage my business successfully,
//I want to be able to add an “ANZ(NZ)” bank account inside any Xero Organisation

namespace WebDriver_CSharp_Example
{
    [TestFixture]
    public class Chrome_Sample_test
    {
        private IWebDriver driver;
        public string homeURL;
        public string userName;
        public string userPassword;

        [Test(Description = "Test")]
        public void Login_is_on_home_page()
        {
            //Elements
            //Logging page

            //Dashboard
            //IWebElement chartAccounts = driver.FindElement(By.Id("ext-gen16")); //Add bank Account-button
            //IWebElement profile = driver.FindElement(By.Id("password"));
            //IWebElement logOut = driver.FindElement(By.Id("password"));

            //Accounting
            //IWebElement accountVal = driver.FindElement(By.Id("password"));
            //IWebElement anzImg = driver.FindElement(By.Id("password"));
            //IWebElement bankLink = driver.FindElement(By.Id("password"));

            ////Add Bank Accounts
            //IWebElement searchBank = driver.FindElement(By.Id("password"));
            //IWebElement searchBtn = driver.FindElement(By.Id("password"));
            //IWebElement otherCountries = driver.FindElement(By.Id("password"));
            //IWebElement anzBank = driver.FindElement(By.Id("password"));
            //IWebElement accountName = driver.FindElement(By.Id("password"));
            //IWebElement accountType = driver.FindElement(By.Id("password"));
            //    //Drop down options
            //    IWebElement everyday = driver.FindElement(By.Id("password"));
            //    IWebElement loan = driver.FindElement(By.Id("password"));
            //    IWebElement termDeposit = driver.FindElement(By.Id("password"));
            //    IWebElement creditCard = driver.FindElement(By.Id("password"));
            //    IWebElement other = driver.FindElement(By.Id("password"));
            //IWebElement accountNumber = driver.FindElement(By.Id("password"));
            //IWebElement additonalAccount = driver.FindElement(By.Id("password"));
            //IWebElement continueBtn = driver.FindElement(By.Id("password"));
            //IWebElement PageVal = driver.FindElement(By.Id("password"));

            ////Chart of Accounts
            //IWebElement searchField = driver.FindElement(By.Id("password"));
            //IWebElement searchBtn2 = driver.FindElement(By.Id("password"));
            //IWebElement tickBox = driver.FindElement(By.Id("password"));
            //IWebElement deleteBtn = driver.FindElement(By.Id("password"));
            //IWebElement okBtn = driver.FindElement(By.Id("password"));
            //IWebElement deletedVal = driver.FindElement(By.Id("password"));

            homeURL = "https://login.xero.com/";
            userName = "bknipler@gmail.com";
            userPassword = "XeroTest123";

            //go to login page
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));

            //enter email address
            wait.Until(driver => driver.FindElement(By.Id("email")));
            IWebElement email = driver.FindElement(By.Id("email"));
            email.Click();
            email.SendKeys(userName);

            Task.Delay(1000).Wait();

            //enter password
            IWebElement password = driver.FindElement(By.Id("password"));
            password.Click();
            password.SendKeys(userPassword);

            Task.Delay(1000).Wait();

            //click login button
            IWebElement login = driver.FindElement(By.Id("submitButton"));
            login.Click();

            Task.Delay(1000).Wait();

            wait.Until(driver => driver.FindElement(By.CssSelector(".xui-button:nth-child(4)")));

            //choose alt authentication method
            IWebElement altAuth = driver.FindElement(By.CssSelector(".xui-button:nth-child(4)"));
            altAuth.Click();
            
            Task.Delay(1000).Wait();

            //choose security questions
            IWebElement securityQuestions = driver.FindElement(By.CssSelector(".xui-contentblockitem:nth-child(2)>.xui-button"));
            securityQuestions.Click();

            Task.Delay(1000).Wait();


            //first security question
            var firstQuestionIs = driver.FindElement(By.CssSelector(".auth-firstquestion"));
            if (!string.IsNullOrEmpty(firstQuestionIs.Text) && firstQuestionIs.Text == "What was the name of your first pet?")
            {
                IWebElement firstQuestion = driver.FindElement(By.XPath("//input[@class='xui-textinput--input'][1]"));
                firstQuestion.Click();
                firstQuestion.SendKeys("Test3");
            }
            else if (!string.IsNullOrEmpty(firstQuestionIs.Text) && firstQuestionIs.Text == "What is your dream job?")
            {
                IWebElement firstQuestion = driver.FindElement(By.XPath("//input[@class='xui-textinput--input'][1]"));
                firstQuestion.Click();
                firstQuestion.SendKeys("Test2");
            }
            else if (!string.IsNullOrEmpty(firstQuestionIs.Text) && firstQuestionIs.Text == "What is your dream car?")
            {
                IWebElement firstQuestion = driver.FindElement(By.XPath("//input[@class='xui-textinput--input'][1]"));
                firstQuestion.Click();
                firstQuestion.SendKeys("Test");
            }

            //second security question
            var secondQuestionIs = driver.FindElement(By.CssSelector(".auth-secondquestion"));
            if (!string.IsNullOrEmpty(secondQuestionIs.Text) && secondQuestionIs.Text == "What was the name of your first pet?")
            {
                IWebElement secondQuestion = driver.FindElement(By.XPath("/html//div[@id='auth-splashpage']//form/label[2]/div/input"));
                secondQuestion.Click();
                secondQuestion.SendKeys("Test3");
            }
            else if (!string.IsNullOrEmpty(secondQuestionIs.Text) && secondQuestionIs.Text == "What is your dream job?")
            {
                IWebElement secondQuestion = driver.FindElement(By.XPath("/html//div[@id='auth-splashpage']//form/label[2]/div/input"));
                secondQuestion.Click();
                secondQuestion.SendKeys("Test2");
            }
            else if (!string.IsNullOrEmpty(secondQuestionIs.Text) && secondQuestionIs.Text == "What is your dream car?")
            {
                IWebElement secondQuestion = driver.FindElement(By.XPath("/html//div[@id='auth-splashpage']//form/label[2]/div/input"));
                secondQuestion.Click();
                secondQuestion.SendKeys("Test");
            }

            Task.Delay(1000).Wait();

            //submit security questions
            IWebElement mainBtn = driver.FindElement(By.CssSelector(".xui-button-main"));
            mainBtn.Click();

            IWebElement accounting = driver.FindElement(By.Id("accounting"));
            accounting.Click();

            Task.Delay(1000).Wait();

            IWebElement bankAccounts = driver.FindElement(By.Id("accounting-bank-accounts"));
            bankAccounts.Click();

            Task.Delay(1000).Wait();

            IWebElement addAccount = driver.FindElement(By.Id("ext-gen16"));
            addAccount.Click();

            Task.Delay(1000).Wait();

        }

        [TearDown]
        public void TearDownTest()
        {
          //  driver.Close();
        }

        [SetUp]
        public void SetupTest()
        {
            homeURL = "https://login.xero.com/";
            driver = new ChromeDriver();
        }
    }
}