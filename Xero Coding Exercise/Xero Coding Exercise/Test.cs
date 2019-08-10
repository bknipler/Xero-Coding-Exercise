using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
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
            userName = "bknipler@gmail.com";
            userPassword = "XeroTest123";

            //go to login page
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));

            //enter email address
            Task.Delay(1000).Wait();

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

            Task.Delay(1000).Wait();


            //accounting drop down
            IWebElement accounting = driver.FindElement(By.CssSelector(".xrh-tab:nth-child(3)>.xrh-focusable"));
            accounting.Click();

            Task.Delay(1000).Wait();

            //bank accounts tab
            IWebElement bankAccounts = driver.FindElement(By.LinkText("Bank accounts"));
            bankAccounts.Click();

            Task.Delay(1000).Wait();

            IWebElement addAccount = driver.FindElement(By.Id("ext-gen16"));
            addAccount.Click();

            Task.Delay(1000).Wait();

            wait.Until(driver => driver.FindElement(By.Id("xui-searchfield-1018-inputEl")));


            IWebElement searchBank = driver.FindElement(By.Id("xui-searchfield-1018-inputEl"));
            searchBank.Click();
            searchBank.SendKeys("ANZ (NZ)");

            Task.Delay(1000).Wait();

            IWebElement otherCountries = driver.FindElement(By.LinkText("Show 1 result from other countries..."));
            otherCountries.Click(); 

            Task.Delay(1000).Wait();

            

            wait.Until(driver => driver.FindElement(By.XPath("//div[@id='view']//section/div[3]/ul/li[.='ANZ (NZ)']")));

            IWebElement selectANZ_NZ = driver.FindElement(By.XPath("//div[@id='view']//section/div[3]/ul/li[.='ANZ (NZ)']"));
            selectANZ_NZ.Click();

            //wait.Until(driver => driver.FindElement(By.CssSelector(".x-view-item-focused")));

            //IWebElement selectANZ_NZ = driver.FindElement(By.CssSelector(".x-view-item-focused"));
            //selectANZ_NZ.Click();
            Task.Delay(1000).Wait();

            wait.Until(driver => driver.FindElement(By.Id("accountname-1037-inputEl")));

            IWebElement accountName = driver.FindElement(By.Id("accountname-1037-inputEl"));
            accountName.Click();
            accountName.SendKeys("TestAccount");

            Task.Delay(1000).Wait();

            IWebElement accountType = driver.FindElement(By.Id("accounttype-1039-inputEl"));
            accountType.Click();
            Task.Delay(1000).Wait();

            //dropdown of account types
            IWebElement typeEveryday = driver.FindElement(By.CssSelector(".ba-combo-list-item:nth-child(1)"));
          //  IWebElement typeLoan = driver.FindElement(By.CssSelector(".ba-combo-list-item:nth-child(2)"));
          //  IWebElement typeTermDeposit = driver.FindElement(By.CssSelector(".ba-combo-list-item:nth-child(3)"));
          //  IWebElement typeCC = driver.FindElement(By.CssSelector(".ba-combo-list-item:nth-child(4)"));
          //  IWebElement typeOther = driver.FindElement(By.CssSelector(".ba-combo-list-item:nth-child(5)"));
            typeEveryday.Click();

            Task.Delay(1000).Wait();

            IWebElement accountNumber = driver.FindElement(By.Id("accountnumber-1068-inputEl"));
            accountNumber.Click();
            accountNumber.SendKeys("111111");

            Task.Delay(1000).Wait();

            IWebElement subBtn = driver.FindElement(By.Id("common-button-submit-1015"));
            subBtn.Click();

            Task.Delay(1000).Wait();

            wait.Until(driver => driver.FindElement(By.CssSelector(".xrh-tab:nth-child(3)>.xrh-focusable")));

            //accounting drop down
            IWebElement accounting2 = driver.FindElement(By.CssSelector(".xrh-tab:nth-child(3)>.xrh-focusable"));
            accounting2.Click();

            Task.Delay(1000).Wait();

            //Chart of accounts
            IWebElement chartAccounts = driver.FindElement(By.LinkText("Chart of accounts"));
            chartAccounts.Click();

            Task.Delay(1000).Wait();

            IWebElement valAccount = driver.FindElement(By.LinkText("TestAccount"));
            valAccount.Click();

            Task.Delay(1000).Wait();

            IWebElement closeWindow = driver.FindElement(By.Id("popupCancel"));
            closeWindow.Click();

            Task.Delay(1000).Wait();

            IWebElement wilDelete = driver.FindElement(By.Id("WillDelete"));
            wilDelete.Click();

            Task.Delay(1000).Wait();

            IWebElement delete = driver.FindElement(By.Id("ext-gen20"));
            delete.Click();

            Task.Delay(1000).Wait();

            IWebElement closePopup = driver.FindElement(By.Id("popupOK"));
            closePopup.Click();

            Task.Delay(1000).Wait();

            IWebElement deleteSuccessful = driver.FindElement(By.Id("ext-gen15"));
            deleteSuccessful.Click();
        }

        [TearDown]
        public void TearDownTest()
        {
            driver.Close();
        }

        [SetUp]
        public void SetupTest()
        {
            homeURL = "https://login.xero.com/";
            driver = new ChromeDriver();
        }
    }
}