using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;

namespace Selenium.Pages
{
    internal class WikipediaPage
    {

        private readonly IWebDriver driver;
        public WikipediaPage(IWebDriver driver) => this.driver = driver ?? throw new ArgumentNullException(nameof(driver));

        private System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> appleDishesList => driver.FindElements(By.XPath("//div[contains(@class,'hatnote')]/following-sibling::ul[1]//a[starts-with(@title,'Apple')]"));

        public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> AppleDishesList()
        {
            return appleDishesList;
        }
        private System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> seeAllEndingsWithApple
        {
            get
            {
                try
                {
                    return driver.FindElements(By.XPath("//div[contains(@class,'div-col')]/ul/li/a[ends-with(@title,'apple')]")); //Xpath 2.0 not supported by most browsers. It should work when it will be supported.

                }
                catch (Exception)
                {
                    return driver.FindElements(By.XPath("//div[contains(@class,'div-col')]//a[substring(@title, string-length(@title) - string-length('apple') + 1) ='apple']"));
                }
            }
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> SeeAllEndingsWithApple()
        {
            return seeAllEndingsWithApple;
        }
    }
}
