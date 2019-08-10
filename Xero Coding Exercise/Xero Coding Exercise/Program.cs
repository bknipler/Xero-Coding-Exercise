using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Xero_Coding_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a driver instance for chromedriver
            IWebDriver driver = new ChromeDriver();

            //Navigate to xero page
            driver.Navigate().GoToUrl("https://www.xero.com/");
        }
    }
}
