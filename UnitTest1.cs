using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace Selenium
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver(@"C:\Users\woj_9\source\repos\Selenium\Driver\");
        }

        //incoming test were copypasted from internet as part of learning. Some of them were failing from the begginging and were fixed.

        [Test]
        public void Test1() //unknown source.
        {
            driver.Url = "https://toolsqa.com/";
            driver.FindElement(By.ClassName("category__icon--wrapper")).Click();
            driver.Navigate().Back();
            driver.Navigate().Forward();
            driver.Navigate().Refresh();
            Assert.Pass();
        }

        [Test]
        public void Test2() //code from https://toolsqa.com/selenium-webdriver/c-sharp/iwebdriver-browser-commands-in-c-sharp/
        {
            driver.Url = "https://demoqa.com/alertsWindows"; //corrected by me
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); //thanks https://alexsiminiuc.medium.com/c-expected-conditions-are-deprecated-so-what-b451365adc24 for information about waitings.
            wait.Until(c =>
            {
                return c.FindElement(By.XPath("//*[contains(@class,'show')]//li[@id='item-0']")).Displayed;
            });
            driver.FindElement(By.XPath("//*[contains(@class,'show')]//li[@id='item-0']")).Click();
            //driver.FindElement(By.XPath(".//*[@id='tabs-1']/div/p/a")).Click();
            wait.Until(c =>
            {
                return c.FindElement(By.XPath("//*[@id='windowButton']")).Displayed;
            });
            driver.FindElement(By.XPath("//*[@id='windowButton']")).Click(); //corrected by me
        }

        //incoming tests were writted by me and not copy pasted from internet

        [Test]
        public void FindAppleDishessStartingWithApple()
        {
            driver.Url = "https://en.wikipedia.org/wiki/List_of_apple_dishes";
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> webElements = driver.FindElements(By.XPath("//div[contains(@class,'hatnote')]/following-sibling::ul[1]//a[starts-with(@title,'Apple')]"));
            string text;
            foreach (IWebElement webElement in webElements)
            {
                text = webElement.Text.Trim();
                //Console.WriteLine(text); //normally not used allows to see what values were found for debugging purposes
                Assert.True(text.StartsWith("Apple"));
            }
        }

        [Test]
        public void FindAllSeeAlsoLinksEndingWithApple(){
            driver.Url = "https://en.wikipedia.org/wiki/List_of_apple_dishes";
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> webElements;
            try
            {
                webElements = driver.FindElements(By.XPath("//div[contains(@class,'div-col')]/ul/li/a[ends-with(@title,'apple')]")); //Xpath 2.0 not supported by most browsers. It should work when it will be supported.
                Console.WriteLine("X-Path 2.0 was used"); //inform us when this expression was used
            }
            catch (Exception)
            {
                //use XPath 1.0 when Xpath 2.0 is not supported
                webElements = driver.FindElements(By.XPath("//div[contains(@class,'div-col')]//a[substring(@title, string-length(@title) - string-length('apple') + 1) ='apple']"));
                Console.WriteLine("X-Path 1.0 was used"); //inform us when this expression was used
            }
            string text;
            foreach (IWebElement webElement in webElements)
            {
                text = webElement.Text.Trim();
                //Console.WriteLine(text); //normally not used allows to see what values were found for debugging purposes
                Assert.True(text.EndsWith("apple"));
            }
        }

        [TearDown]
        public void End()
        {
            driver.Quit();
        }
    }
}