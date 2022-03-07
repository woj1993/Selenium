using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Helpers
{
    internal class Waits
    {
        private readonly WebDriverWait wait;
        private readonly IWebDriver driver;

        public Waits(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10)); //thanks https://alexsiminiuc.medium.com/c-expected-conditions-are-deprecated-so-what-b451365adc24 for information about waitings.
        }

        public void ElementClickable(String XPath)
        {
            wait.Until(c =>
            {
                return c.FindElement(By.XPath(XPath)).Displayed;
            });
        }
    }
}
