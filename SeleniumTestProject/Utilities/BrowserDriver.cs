using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.Utilities
{
    public class BrowserDriver
    {
        IWebDriver driver;

        public enum BrowserType
        {
            Chrome = 0,
            Edge = 1,
            Firefox = 2
        }

        public enum Location
        {
            Local = 0,
            Remote = 1
        }

        public IWebDriver createDriver()
        {

            driver = new FirefoxDriver();
            return driver;
        }

        public IWebDriver createDriver(BrowserType type)
        {
            switch(type)
            {
                case BrowserType.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments(@"--incognito");
                    driver = new ChromeDriver(options);
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
                default:
                    driver = new FirefoxDriver();
                    break;
            }
            return driver;
        }

        public IWebDriver getDriver()
        {
            if(driver != null)
            {
                return driver;
            }
            else
            {
                driver = new FirefoxDriver();
                return driver;
            }
            
        }
    }
}
