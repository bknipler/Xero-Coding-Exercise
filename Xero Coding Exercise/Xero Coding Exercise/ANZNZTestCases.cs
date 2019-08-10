using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading.Tasks;

//As a Xero User,
//In order to manage my business successfully,
//I want to be able to add an “ANZ(NZ)” bank account inside any Xero Organisation

namespace AddANZNZBank
{
    [TestFixture]
    public class EveryDayBankType
    {
        private IWebDriver driver;
        public string homeURL;
        public string userName;
        public string userPassword;
        public string questionCar;
        public string questionJob;
        public string questionPet;
        public string bankName;
        public string testAccount;
        public string testNumber;
        public string ccDigits;

        [Test(Description = "Testing everyday account type for ANZ (NZ) BANK")]
        public void EverydayAccountType()
        {
            //set wait span to 15 seconds
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));

            //go to login page
            driver.Navigate().GoToUrl(homeURL);
            Task.Delay(1000).Wait();

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

            //choose alt authentication method
            wait.Until(driver => driver.FindElement(By.CssSelector(".xui-button:nth-child(4)")));
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
                firstQuestion.SendKeys(questionPet);
            }
            else if (!string.IsNullOrEmpty(firstQuestionIs.Text) && firstQuestionIs.Text == "What is your dream job?")
            {
                IWebElement firstQuestion = driver.FindElement(By.XPath("//input[@class='xui-textinput--input'][1]"));
                firstQuestion.Click();
                firstQuestion.SendKeys(questionJob);
            }
            else if (!string.IsNullOrEmpty(firstQuestionIs.Text) && firstQuestionIs.Text == "What is your dream car?")
            {
                IWebElement firstQuestion = driver.FindElement(By.XPath("//input[@class='xui-textinput--input'][1]"));
                firstQuestion.Click();
                firstQuestion.SendKeys(questionCar);
            }

            //second security question
            var secondQuestionIs = driver.FindElement(By.CssSelector(".auth-secondquestion"));
            if (!string.IsNullOrEmpty(secondQuestionIs.Text) && secondQuestionIs.Text == "What was the name of your first pet?")
            {
                IWebElement secondQuestion = driver.FindElement(By.XPath("/html//div[@id='auth-splashpage']//form/label[2]/div/input"));
                secondQuestion.Click();
                secondQuestion.SendKeys(questionPet);
            }
            else if (!string.IsNullOrEmpty(secondQuestionIs.Text) && secondQuestionIs.Text == "What is your dream job?")
            {
                IWebElement secondQuestion = driver.FindElement(By.XPath("/html//div[@id='auth-splashpage']//form/label[2]/div/input"));
                secondQuestion.Click();
                secondQuestion.SendKeys(questionJob);
            }
            else if (!string.IsNullOrEmpty(secondQuestionIs.Text) && secondQuestionIs.Text == "What is your dream car?")
            {
                IWebElement secondQuestion = driver.FindElement(By.XPath("/html//div[@id='auth-splashpage']//form/label[2]/div/input"));
                secondQuestion.Click();
                secondQuestion.SendKeys(questionCar);
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

            //add new bank account button
            IWebElement addAccount = driver.FindElement(By.Id("ext-gen16"));
            addAccount.Click();
            Task.Delay(1000).Wait();

            //search for ANZ NZ account
            wait.Until(driver => driver.FindElement(By.Id("xui-searchfield-1018-inputEl")));
            IWebElement searchBank = driver.FindElement(By.Id("xui-searchfield-1018-inputEl"));
            searchBank.Click();
            searchBank.SendKeys(bankName);
            Task.Delay(1000).Wait();

            //show results from other countries
            IWebElement otherCountries = driver.FindElement(By.LinkText("Show 1 result from other countries..."));
            otherCountries.Click(); 
            Task.Delay(1000).Wait();

            //select ANZ NZ bank
            wait.Until(driver => driver.FindElement(By.XPath("//div[@id='view']//section/div[3]/ul/li[.='ANZ (NZ)']")));
            IWebElement selectANZ_NZ = driver.FindElement(By.XPath("//div[@id='view']//section/div[3]/ul/li[.='ANZ (NZ)']"));
            selectANZ_NZ.Click();
            Task.Delay(1000).Wait();

            //insert account name
            wait.Until(driver => driver.FindElement(By.Id("accountname-1037-inputEl")));
            IWebElement accountName = driver.FindElement(By.Id("accountname-1037-inputEl"));
            accountName.Click();
            accountName.SendKeys(testAccount);
            Task.Delay(1000).Wait();

            //open up account type drop down box
            IWebElement accountType = driver.FindElement(By.Id("accounttype-1039-inputEl"));
            accountType.Click();
            Task.Delay(1000).Wait();

            //select Everyday account type from drop down
            IWebElement typeEveryday = driver.FindElement(By.CssSelector(".ba-combo-list-item:nth-child(1)"));
            typeEveryday.Click();
            Task.Delay(1000).Wait();

            //insert account number
            IWebElement accountNumber = driver.FindElement(By.Id("accountnumber-1068-inputEl"));
            accountNumber.Click();
            accountNumber.SendKeys(testNumber);
            Task.Delay(1000).Wait();

            //submit new bank account
            IWebElement subBtn = driver.FindElement(By.Id("common-button-submit-1015"));
            subBtn.Click();
            Task.Delay(1000).Wait();

            //accounting drop down
            wait.Until(driver => driver.FindElement(By.CssSelector(".xrh-tab:nth-child(3)>.xrh-focusable")));         
            IWebElement accounting2 = driver.FindElement(By.CssSelector(".xrh-tab:nth-child(3)>.xrh-focusable"));
            accounting2.Click();
            Task.Delay(1000).Wait();

            //select Chart of accounts
            IWebElement chartAccounts = driver.FindElement(By.LinkText("Chart of accounts"));
            chartAccounts.Click();
            Task.Delay(1000).Wait();

            //ensure new account exists and is clickable
            IWebElement valAccount = driver.FindElement(By.LinkText("TestAccount"));
            valAccount.Click();
            Task.Delay(1000).Wait();

            //close window
            IWebElement closeWindow = driver.FindElement(By.Id("popupCancel"));
            closeWindow.Click();
            Task.Delay(1000).Wait();

            //CLEANUP - select the account to be deleted
            IWebElement wilDelete = driver.FindElement(By.Id("WillDelete"));
            wilDelete.Click();
            Task.Delay(1000).Wait();

            //click delete button
            IWebElement delete = driver.FindElement(By.Id("ext-gen20"));
            delete.Click();
            Task.Delay(1000).Wait();

            //confirm deletion
            IWebElement closePopup = driver.FindElement(By.Id("popupOK"));
            closePopup.Click();
            Task.Delay(1000).Wait();

            //confirm delete success message shows
            IWebElement deleteSuccessful = driver.FindElement(By.Id("ext-gen15"));
            deleteSuccessful.Click();
        }

        [Test(Description = "Testing loan account type for ANZ (NZ) BANK")]
        public void LoanAccountType()
        {
            //set wait span to 15 seconds
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));

            //go to login page
            driver.Navigate().GoToUrl(homeURL);
            Task.Delay(1000).Wait();

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

            //choose alt authentication method
            wait.Until(driver => driver.FindElement(By.CssSelector(".xui-button:nth-child(4)")));
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
                firstQuestion.SendKeys(questionPet);
            }
            else if (!string.IsNullOrEmpty(firstQuestionIs.Text) && firstQuestionIs.Text == "What is your dream job?")
            {
                IWebElement firstQuestion = driver.FindElement(By.XPath("//input[@class='xui-textinput--input'][1]"));
                firstQuestion.Click();
                firstQuestion.SendKeys(questionJob);
            }
            else if (!string.IsNullOrEmpty(firstQuestionIs.Text) && firstQuestionIs.Text == "What is your dream car?")
            {
                IWebElement firstQuestion = driver.FindElement(By.XPath("//input[@class='xui-textinput--input'][1]"));
                firstQuestion.Click();
                firstQuestion.SendKeys(questionCar);
            }

            //second security question
            var secondQuestionIs = driver.FindElement(By.CssSelector(".auth-secondquestion"));
            if (!string.IsNullOrEmpty(secondQuestionIs.Text) && secondQuestionIs.Text == "What was the name of your first pet?")
            {
                IWebElement secondQuestion = driver.FindElement(By.XPath("/html//div[@id='auth-splashpage']//form/label[2]/div/input"));
                secondQuestion.Click();
                secondQuestion.SendKeys(questionPet);
            }
            else if (!string.IsNullOrEmpty(secondQuestionIs.Text) && secondQuestionIs.Text == "What is your dream job?")
            {
                IWebElement secondQuestion = driver.FindElement(By.XPath("/html//div[@id='auth-splashpage']//form/label[2]/div/input"));
                secondQuestion.Click();
                secondQuestion.SendKeys(questionJob);
            }
            else if (!string.IsNullOrEmpty(secondQuestionIs.Text) && secondQuestionIs.Text == "What is your dream car?")
            {
                IWebElement secondQuestion = driver.FindElement(By.XPath("/html//div[@id='auth-splashpage']//form/label[2]/div/input"));
                secondQuestion.Click();
                secondQuestion.SendKeys(questionCar);
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

            //add new bank account button
            IWebElement addAccount = driver.FindElement(By.Id("ext-gen16"));
            addAccount.Click();
            Task.Delay(1000).Wait();

            //search for ANZ NZ account
            wait.Until(driver => driver.FindElement(By.Id("xui-searchfield-1018-inputEl")));
            IWebElement searchBank = driver.FindElement(By.Id("xui-searchfield-1018-inputEl"));
            searchBank.Click();
            searchBank.SendKeys(bankName);
            Task.Delay(1000).Wait();

            //show results from other countries
            IWebElement otherCountries = driver.FindElement(By.LinkText("Show 1 result from other countries..."));
            otherCountries.Click();
            Task.Delay(1000).Wait();

            //select ANZ NZ bank
            wait.Until(driver => driver.FindElement(By.XPath("//div[@id='view']//section/div[3]/ul/li[.='ANZ (NZ)']")));
            IWebElement selectANZ_NZ = driver.FindElement(By.XPath("//div[@id='view']//section/div[3]/ul/li[.='ANZ (NZ)']"));
            selectANZ_NZ.Click();
            Task.Delay(1000).Wait();

            //insert account name
            wait.Until(driver => driver.FindElement(By.Id("accountname-1037-inputEl")));
            IWebElement accountName = driver.FindElement(By.Id("accountname-1037-inputEl"));
            accountName.Click();
            accountName.SendKeys(testAccount);
            Task.Delay(1000).Wait();

            //open up account type drop down box
            IWebElement accountType = driver.FindElement(By.Id("accounttype-1039-inputEl"));
            accountType.Click();
            Task.Delay(1000).Wait();

            //select Loan account type from drop down
            IWebElement typeLoan = driver.FindElement(By.CssSelector(".ba-combo-list-item:nth-child(2)"));
            typeLoan.Click();
            Task.Delay(1000).Wait();

            //insert account number
            IWebElement accountNumber = driver.FindElement(By.Id("accountnumber-1068-inputEl"));
            accountNumber.Click();
            accountNumber.SendKeys(testNumber);
            Task.Delay(1000).Wait();

            //submit new bank account
            IWebElement subBtn = driver.FindElement(By.Id("common-button-submit-1015"));
            subBtn.Click();
            Task.Delay(1000).Wait();

            //accounting drop down
            wait.Until(driver => driver.FindElement(By.CssSelector(".xrh-tab:nth-child(3)>.xrh-focusable")));
            IWebElement accounting2 = driver.FindElement(By.CssSelector(".xrh-tab:nth-child(3)>.xrh-focusable"));
            accounting2.Click();
            Task.Delay(1000).Wait();

            //select Chart of accounts
            IWebElement chartAccounts = driver.FindElement(By.LinkText("Chart of accounts"));
            chartAccounts.Click();
            Task.Delay(1000).Wait();

            //ensure new account exists and is clickable
            IWebElement valAccount = driver.FindElement(By.LinkText("TestAccount"));
            valAccount.Click();
            Task.Delay(1000).Wait();

            //close window
            IWebElement closeWindow = driver.FindElement(By.Id("popupCancel"));
            closeWindow.Click();
            Task.Delay(1000).Wait();

            //CLEANUP - select the account to be deleted
            IWebElement wilDelete = driver.FindElement(By.Id("WillDelete"));
            wilDelete.Click();
            Task.Delay(1000).Wait();

            //click delete button
            IWebElement delete = driver.FindElement(By.Id("ext-gen20"));
            delete.Click();
            Task.Delay(1000).Wait();

            //confirm deletion
            IWebElement closePopup = driver.FindElement(By.Id("popupOK"));
            closePopup.Click();
            Task.Delay(1000).Wait();

            //confirm delete success message shows
            IWebElement deleteSuccessful = driver.FindElement(By.Id("ext-gen15"));
            deleteSuccessful.Click();
        }

        [Test(Description = "Testing Deposit account type for ANZ (NZ) BANK")]
        public void DepositAccountType()
        {
            //set wait span to 15 seconds
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));

            //go to login page
            driver.Navigate().GoToUrl(homeURL);
            Task.Delay(1000).Wait();

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

            //choose alt authentication method
            wait.Until(driver => driver.FindElement(By.CssSelector(".xui-button:nth-child(4)")));
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
                firstQuestion.SendKeys(questionPet);
            }
            else if (!string.IsNullOrEmpty(firstQuestionIs.Text) && firstQuestionIs.Text == "What is your dream job?")
            {
                IWebElement firstQuestion = driver.FindElement(By.XPath("//input[@class='xui-textinput--input'][1]"));
                firstQuestion.Click();
                firstQuestion.SendKeys(questionJob);
            }
            else if (!string.IsNullOrEmpty(firstQuestionIs.Text) && firstQuestionIs.Text == "What is your dream car?")
            {
                IWebElement firstQuestion = driver.FindElement(By.XPath("//input[@class='xui-textinput--input'][1]"));
                firstQuestion.Click();
                firstQuestion.SendKeys(questionCar);
            }

            //second security question
            var secondQuestionIs = driver.FindElement(By.CssSelector(".auth-secondquestion"));
            if (!string.IsNullOrEmpty(secondQuestionIs.Text) && secondQuestionIs.Text == "What was the name of your first pet?")
            {
                IWebElement secondQuestion = driver.FindElement(By.XPath("/html//div[@id='auth-splashpage']//form/label[2]/div/input"));
                secondQuestion.Click();
                secondQuestion.SendKeys(questionPet);
            }
            else if (!string.IsNullOrEmpty(secondQuestionIs.Text) && secondQuestionIs.Text == "What is your dream job?")
            {
                IWebElement secondQuestion = driver.FindElement(By.XPath("/html//div[@id='auth-splashpage']//form/label[2]/div/input"));
                secondQuestion.Click();
                secondQuestion.SendKeys(questionJob);
            }
            else if (!string.IsNullOrEmpty(secondQuestionIs.Text) && secondQuestionIs.Text == "What is your dream car?")
            {
                IWebElement secondQuestion = driver.FindElement(By.XPath("/html//div[@id='auth-splashpage']//form/label[2]/div/input"));
                secondQuestion.Click();
                secondQuestion.SendKeys(questionCar);
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

            //add new bank account button
            IWebElement addAccount = driver.FindElement(By.Id("ext-gen16"));
            addAccount.Click();
            Task.Delay(1000).Wait();

            //search for ANZ NZ account
            wait.Until(driver => driver.FindElement(By.Id("xui-searchfield-1018-inputEl")));
            IWebElement searchBank = driver.FindElement(By.Id("xui-searchfield-1018-inputEl"));
            searchBank.Click();
            searchBank.SendKeys(bankName);
            Task.Delay(1000).Wait();

            //show results from other countries
            IWebElement otherCountries = driver.FindElement(By.LinkText("Show 1 result from other countries..."));
            otherCountries.Click();
            Task.Delay(1000).Wait();

            //select ANZ NZ bank
            wait.Until(driver => driver.FindElement(By.XPath("//div[@id='view']//section/div[3]/ul/li[.='ANZ (NZ)']")));
            IWebElement selectANZ_NZ = driver.FindElement(By.XPath("//div[@id='view']//section/div[3]/ul/li[.='ANZ (NZ)']"));
            selectANZ_NZ.Click();
            Task.Delay(1000).Wait();

            //insert account name
            wait.Until(driver => driver.FindElement(By.Id("accountname-1037-inputEl")));
            IWebElement accountName = driver.FindElement(By.Id("accountname-1037-inputEl"));
            accountName.Click();
            accountName.SendKeys(testAccount);
            Task.Delay(1000).Wait();

            //open up account type drop down box
            IWebElement accountType = driver.FindElement(By.Id("accounttype-1039-inputEl"));
            accountType.Click();
            Task.Delay(1000).Wait();

            //select deposits account type from drop down
            IWebElement typeTermDeposit = driver.FindElement(By.CssSelector(".ba-combo-list-item:nth-child(3)"));

            typeTermDeposit.Click();
            Task.Delay(1000).Wait();

            //insert account number
            IWebElement accountNumber = driver.FindElement(By.Id("accountnumber-1068-inputEl"));
            accountNumber.Click();
            accountNumber.SendKeys(testNumber);
            Task.Delay(1000).Wait();

            //submit new bank account
            IWebElement subBtn = driver.FindElement(By.Id("common-button-submit-1015"));
            subBtn.Click();
            Task.Delay(1000).Wait();

            //accounting drop down
            wait.Until(driver => driver.FindElement(By.CssSelector(".xrh-tab:nth-child(3)>.xrh-focusable")));
            IWebElement accounting2 = driver.FindElement(By.CssSelector(".xrh-tab:nth-child(3)>.xrh-focusable"));
            accounting2.Click();
            Task.Delay(1000).Wait();

            //select Chart of accounts
            IWebElement chartAccounts = driver.FindElement(By.LinkText("Chart of accounts"));
            chartAccounts.Click();
            Task.Delay(1000).Wait();

            //ensure new account exists and is clickable
            IWebElement valAccount = driver.FindElement(By.LinkText("TestAccount"));
            valAccount.Click();
            Task.Delay(1000).Wait();

            //close window
            IWebElement closeWindow = driver.FindElement(By.Id("popupCancel"));
            closeWindow.Click();
            Task.Delay(1000).Wait();

            //CLEANUP - select the account to be deleted
            IWebElement wilDelete = driver.FindElement(By.Id("WillDelete"));
            wilDelete.Click();
            Task.Delay(1000).Wait();

            //click delete button
            IWebElement delete = driver.FindElement(By.Id("ext-gen20"));
            delete.Click();
            Task.Delay(1000).Wait();

            //confirm deletion
            IWebElement closePopup = driver.FindElement(By.Id("popupOK"));
            closePopup.Click();
            Task.Delay(1000).Wait();

            //confirm delete success message shows
            IWebElement deleteSuccessful = driver.FindElement(By.Id("ext-gen15"));
            deleteSuccessful.Click();
        }

        [Test(Description = "Testing credit card account type for ANZ (NZ) BANK")]
        public void CCAccountType()
        {
            //set wait span to 15 seconds
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));

            //go to login page
            driver.Navigate().GoToUrl(homeURL);
            Task.Delay(1000).Wait();

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

            //choose alt authentication method
            wait.Until(driver => driver.FindElement(By.CssSelector(".xui-button:nth-child(4)")));
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
                firstQuestion.SendKeys(questionPet);
            }
            else if (!string.IsNullOrEmpty(firstQuestionIs.Text) && firstQuestionIs.Text == "What is your dream job?")
            {
                IWebElement firstQuestion = driver.FindElement(By.XPath("//input[@class='xui-textinput--input'][1]"));
                firstQuestion.Click();
                firstQuestion.SendKeys(questionJob);
            }
            else if (!string.IsNullOrEmpty(firstQuestionIs.Text) && firstQuestionIs.Text == "What is your dream car?")
            {
                IWebElement firstQuestion = driver.FindElement(By.XPath("//input[@class='xui-textinput--input'][1]"));
                firstQuestion.Click();
                firstQuestion.SendKeys(questionCar);
            }

            //second security question
            var secondQuestionIs = driver.FindElement(By.CssSelector(".auth-secondquestion"));
            if (!string.IsNullOrEmpty(secondQuestionIs.Text) && secondQuestionIs.Text == "What was the name of your first pet?")
            {
                IWebElement secondQuestion = driver.FindElement(By.XPath("/html//div[@id='auth-splashpage']//form/label[2]/div/input"));
                secondQuestion.Click();
                secondQuestion.SendKeys(questionPet);
            }
            else if (!string.IsNullOrEmpty(secondQuestionIs.Text) && secondQuestionIs.Text == "What is your dream job?")
            {
                IWebElement secondQuestion = driver.FindElement(By.XPath("/html//div[@id='auth-splashpage']//form/label[2]/div/input"));
                secondQuestion.Click();
                secondQuestion.SendKeys(questionJob);
            }
            else if (!string.IsNullOrEmpty(secondQuestionIs.Text) && secondQuestionIs.Text == "What is your dream car?")
            {
                IWebElement secondQuestion = driver.FindElement(By.XPath("/html//div[@id='auth-splashpage']//form/label[2]/div/input"));
                secondQuestion.Click();
                secondQuestion.SendKeys(questionCar);
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

            //add new bank account button
            IWebElement addAccount = driver.FindElement(By.Id("ext-gen16"));
            addAccount.Click();
            Task.Delay(1000).Wait();

            //search for ANZ NZ account
            wait.Until(driver => driver.FindElement(By.Id("xui-searchfield-1018-inputEl")));
            IWebElement searchBank = driver.FindElement(By.Id("xui-searchfield-1018-inputEl"));
            searchBank.Click();
            searchBank.SendKeys(bankName);
            Task.Delay(1000).Wait();

            //show results from other countries
            IWebElement otherCountries = driver.FindElement(By.LinkText("Show 1 result from other countries..."));
            otherCountries.Click();
            Task.Delay(1000).Wait();

            //select ANZ NZ bank
            wait.Until(driver => driver.FindElement(By.XPath("//div[@id='view']//section/div[3]/ul/li[.='ANZ (NZ)']")));
            IWebElement selectANZ_NZ = driver.FindElement(By.XPath("//div[@id='view']//section/div[3]/ul/li[.='ANZ (NZ)']"));
            selectANZ_NZ.Click();
            Task.Delay(1000).Wait();

            //insert account name
            wait.Until(driver => driver.FindElement(By.Id("accountname-1037-inputEl")));
            IWebElement accountName = driver.FindElement(By.Id("accountname-1037-inputEl"));
            accountName.Click();
            accountName.SendKeys(testAccount);
            Task.Delay(1000).Wait();

            //open up account type drop down box
            IWebElement accountType = driver.FindElement(By.Id("accounttype-1039-inputEl"));
            accountType.Click();
            Task.Delay(1000).Wait();

            //select CC account type from drop down
            IWebElement typeCC = driver.FindElement(By.CssSelector(".ba-combo-list-item:nth-child(4)"));
            typeCC.Click();
            Task.Delay(1000).Wait();

            //insert last 4 CC digits number
            IWebElement accountNumber = driver.FindElement(By.Id("accountnumber-1063-inputEl"));
            accountNumber.Click();
            accountNumber.SendKeys(ccDigits);
            Task.Delay(1000).Wait();

            //submit new bank account
            IWebElement subBtn = driver.FindElement(By.Id("common-button-submit-1015"));
            subBtn.Click();
            Task.Delay(1000).Wait();

            //accounting drop down
            wait.Until(driver => driver.FindElement(By.CssSelector(".xrh-tab:nth-child(3)>.xrh-focusable")));
            IWebElement accounting2 = driver.FindElement(By.CssSelector(".xrh-tab:nth-child(3)>.xrh-focusable"));
            accounting2.Click();
            Task.Delay(1000).Wait();

            //select Chart of accounts
            IWebElement chartAccounts = driver.FindElement(By.LinkText("Chart of accounts"));
            chartAccounts.Click();
            Task.Delay(1000).Wait();

            //ensure new account exists and is clickable
            IWebElement valAccount = driver.FindElement(By.LinkText("TestAccount"));
            valAccount.Click();
            Task.Delay(1000).Wait();

            //close window
            IWebElement closeWindow = driver.FindElement(By.Id("popupCancel"));
            closeWindow.Click();
            Task.Delay(1000).Wait();

            //CLEANUP - select the account to be deleted
            IWebElement wilDelete = driver.FindElement(By.Id("WillDelete"));
            wilDelete.Click();
            Task.Delay(1000).Wait();

            //click delete button
            IWebElement delete = driver.FindElement(By.Id("ext-gen20"));
            delete.Click();
            Task.Delay(1000).Wait();

            //confirm deletion
            IWebElement closePopup = driver.FindElement(By.Id("popupOK"));
            closePopup.Click();
            Task.Delay(1000).Wait();

            //confirm delete success message shows
            IWebElement deleteSuccessful = driver.FindElement(By.Id("ext-gen15"));
            deleteSuccessful.Click();
        }

        [Test(Description = "Testing other account type for ANZ (NZ) BANK")]
        public void OtherAccountType()
        {
            //set wait span to 15 seconds
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));

            //go to login page
            driver.Navigate().GoToUrl(homeURL);
            Task.Delay(1000).Wait();

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

            //choose alt authentication method
            wait.Until(driver => driver.FindElement(By.CssSelector(".xui-button:nth-child(4)")));
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
                firstQuestion.SendKeys(questionPet);
            }
            else if (!string.IsNullOrEmpty(firstQuestionIs.Text) && firstQuestionIs.Text == "What is your dream job?")
            {
                IWebElement firstQuestion = driver.FindElement(By.XPath("//input[@class='xui-textinput--input'][1]"));
                firstQuestion.Click();
                firstQuestion.SendKeys(questionJob);
            }
            else if (!string.IsNullOrEmpty(firstQuestionIs.Text) && firstQuestionIs.Text == "What is your dream car?")
            {
                IWebElement firstQuestion = driver.FindElement(By.XPath("//input[@class='xui-textinput--input'][1]"));
                firstQuestion.Click();
                firstQuestion.SendKeys(questionCar);
            }

            //second security question
            var secondQuestionIs = driver.FindElement(By.CssSelector(".auth-secondquestion"));
            if (!string.IsNullOrEmpty(secondQuestionIs.Text) && secondQuestionIs.Text == "What was the name of your first pet?")
            {
                IWebElement secondQuestion = driver.FindElement(By.XPath("/html//div[@id='auth-splashpage']//form/label[2]/div/input"));
                secondQuestion.Click();
                secondQuestion.SendKeys(questionPet);
            }
            else if (!string.IsNullOrEmpty(secondQuestionIs.Text) && secondQuestionIs.Text == "What is your dream job?")
            {
                IWebElement secondQuestion = driver.FindElement(By.XPath("/html//div[@id='auth-splashpage']//form/label[2]/div/input"));
                secondQuestion.Click();
                secondQuestion.SendKeys(questionJob);
            }
            else if (!string.IsNullOrEmpty(secondQuestionIs.Text) && secondQuestionIs.Text == "What is your dream car?")
            {
                IWebElement secondQuestion = driver.FindElement(By.XPath("/html//div[@id='auth-splashpage']//form/label[2]/div/input"));
                secondQuestion.Click();
                secondQuestion.SendKeys(questionCar);
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

            //add new bank account button
            IWebElement addAccount = driver.FindElement(By.Id("ext-gen16"));
            addAccount.Click();
            Task.Delay(1000).Wait();

            //search for ANZ NZ account
            wait.Until(driver => driver.FindElement(By.Id("xui-searchfield-1018-inputEl")));
            IWebElement searchBank = driver.FindElement(By.Id("xui-searchfield-1018-inputEl"));
            searchBank.Click();
            searchBank.SendKeys(bankName);
            Task.Delay(1000).Wait();

            //show results from other countries
            IWebElement otherCountries = driver.FindElement(By.LinkText("Show 1 result from other countries..."));
            otherCountries.Click();
            Task.Delay(1000).Wait();

            //select ANZ NZ bank
            wait.Until(driver => driver.FindElement(By.XPath("//div[@id='view']//section/div[3]/ul/li[.='ANZ (NZ)']")));
            IWebElement selectANZ_NZ = driver.FindElement(By.XPath("//div[@id='view']//section/div[3]/ul/li[.='ANZ (NZ)']"));
            selectANZ_NZ.Click();
            Task.Delay(1000).Wait();

            //insert account name
            wait.Until(driver => driver.FindElement(By.Id("accountname-1037-inputEl")));
            IWebElement accountName = driver.FindElement(By.Id("accountname-1037-inputEl"));
            accountName.Click();
            accountName.SendKeys(testAccount);
            Task.Delay(1000).Wait();

            //open up account type drop down box
            IWebElement accountType = driver.FindElement(By.Id("accounttype-1039-inputEl"));
            accountType.Click();
            Task.Delay(1000).Wait();

            //select Other account type from drop down
            IWebElement typeOther = driver.FindElement(By.CssSelector(".ba-combo-list-item:nth-child(5)"));
            typeOther.Click();
            Task.Delay(1000).Wait();

            //insert account number
            IWebElement accountNumber = driver.FindElement(By.Id("accountnumber-1068-inputEl"));
            accountNumber.Click();
            accountNumber.SendKeys(testNumber);
            Task.Delay(1000).Wait();

            //submit new bank account
            IWebElement subBtn = driver.FindElement(By.Id("common-button-submit-1015"));
            subBtn.Click();
            Task.Delay(1000).Wait();

            //accounting drop down
            wait.Until(driver => driver.FindElement(By.CssSelector(".xrh-tab:nth-child(3)>.xrh-focusable")));
            IWebElement accounting2 = driver.FindElement(By.CssSelector(".xrh-tab:nth-child(3)>.xrh-focusable"));
            accounting2.Click();
            Task.Delay(1000).Wait();

            //select Chart of accounts
            IWebElement chartAccounts = driver.FindElement(By.LinkText("Chart of accounts"));
            chartAccounts.Click();
            Task.Delay(1000).Wait();

            //ensure new account exists and is clickable
            IWebElement valAccount = driver.FindElement(By.LinkText("TestAccount"));
            valAccount.Click();
            Task.Delay(1000).Wait();

            //close window
            IWebElement closeWindow = driver.FindElement(By.Id("popupCancel"));
            closeWindow.Click();
            Task.Delay(1000).Wait();

            //CLEANUP - select the account to be deleted
            IWebElement wilDelete = driver.FindElement(By.Id("WillDelete"));
            wilDelete.Click();
            Task.Delay(1000).Wait();

            //click delete button
            IWebElement delete = driver.FindElement(By.Id("ext-gen20"));
            delete.Click();
            Task.Delay(1000).Wait();

            //confirm deletion
            IWebElement closePopup = driver.FindElement(By.Id("popupOK"));
            closePopup.Click();
            Task.Delay(1000).Wait();

            //confirm delete success message shows
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
            userName = "bknipler@gmail.com";
            userPassword = "XeroTest123";
            questionCar = "Test";
            questionJob = "Test2";
            questionPet = "Test3";
            bankName = "ANZ (NZ)";
            testAccount = "TestAccount";
            testNumber = "111111";
            ccDigits = "1234";
        }
    }
}