using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Page_Objects
{
    public class AngularBusyPage
    {
        public IWebElement  DemoButton(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//button[.='Demo']"));
        }

        public IWebElement MinDurationTextBox(IWebDriver driver)
        {
            return driver.FindElement(By.Id("durationInput"));
        }

        public IWebElement MessageTextBox(IWebDriver driver)
        {
            return driver.FindElement(By.Id("message"));
        }

        public IWebElement WaitingText(IWebDriver driver)
        {
            return driver.FindElement(By.CssSelector(".cg-busy-default-text"));
            
        }

        public SelectElement TemplateSelect(IWebDriver driver)
        {
            return new SelectElement(driver.FindElement(By.Id("template")));
        }

        public IWebElement FantasyWizard(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/div[2]/div/div/div[2]"));
        }
    }
}
