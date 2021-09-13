using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTestProject.Page_Objects;
using SeleniumTestProject.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTestProject.Tests
{
    [TestFixture]
    public class WaitingMessageTest
    {
        BrowserDriver browser;
        IWebDriver driver;

        //PageObject Instantiation
        AngularBusyPage AngularPage = new AngularBusyPage();

        [Test, Order(1) ]
        public void NavigateToSite()
        {
            browser = new BrowserDriver();
            driver = browser.createDriver();

            driver.Navigate().GoToUrl("http://cgross.github.io/angular-busy/demo/");

            Thread.Sleep(3000);
        }

        [Test, Order(2)]
        public void ClickDemoWithPleaseWait()
        {
            AngularPage.DemoButton(driver).Click();
            Thread.Sleep(1000);
            String displayedText = AngularPage.WaitingText(driver).GetAttribute("innerText");
            Console.WriteLine("Expected String: \"Please Wait...\" Found String: " + displayedText);

            Assert.AreEqual(displayedText, "Please Wait...", "Displayed Text Does not Match Expected \"Please Wait...\"");
            
        }

        [Test, Order(3)]
        public void ClickDemoWithWaiting()
        {
            AngularPage.MessageTextBox(driver).Clear();
            AngularPage.MessageTextBox(driver).SendKeys("Waiting");
            AngularPage.DemoButton(driver).Click();
            Thread.Sleep(1000);
            String displayedText = AngularPage.WaitingText(driver).GetAttribute("innerText");
            Console.WriteLine("Expected String: \"Waiting\" Found String: " + displayedText);

            Assert.AreEqual(displayedText, "Waiting", "Displayed Text Does not Match Expected \"Waiting\"");

        }

        [Test, Order(4)]
        public void ClickDemoWithMinDuration()
        {
            AngularPage.MinDurationTextBox(driver).Clear();
            AngularPage.MinDurationTextBox(driver).SendKeys("1000");
            AngularPage.DemoButton(driver).Click();
            Thread.Sleep(1000);
            String displayedText = AngularPage.WaitingText(driver).GetAttribute("innerText");
            Console.WriteLine("Expected String: \"Waiting\" Found String: " + displayedText);

            Assert.AreEqual(displayedText, "Waiting", "Displayed Text Does not Match Expected \"Waiting\"");
        }

        [Test, Order(5)]
        public void DancingWizardTest()
        {
            AngularPage.MinDurationTextBox(driver).Clear();
            AngularPage.MinDurationTextBox(driver).SendKeys("10000");

            SelectElement templateSelect = AngularPage.TemplateSelect(driver);
            templateSelect.SelectByText("custom-template.html");
            AngularPage.DemoButton(driver).Click();
            Thread.Sleep(500);
            Console.WriteLine("Wizard: " + AngularPage.FantasyWizard(driver).Displayed);
            Assert.IsTrue(AngularPage.FantasyWizard(driver).Displayed, "Fantasy Wizard Was not Found");

        }
    }
}
