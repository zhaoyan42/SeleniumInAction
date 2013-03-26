using System;
using System.Text;
using Machine.Specifications;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumWebTest
{
    public class 测试百度
    {
        private static IWebDriver driver;
        private static StringBuilder verification_errors;
        private static string base_url;
        private static bool accept_next_alert = true;

        private Establish that =
            () =>
            {
                driver = new FirefoxDriver();
                base_url = "http://www.baidu.com";
                verification_errors = new StringBuilder();

                driver.Navigate().GoToUrl(base_url + "/");
                driver.FindElement(By.Id("kw")).Clear();
                driver.FindElement(By.Id("kw")).SendKeys("暴走漫画");
                driver.FindElement(By.Id("su")).Click();
            };

        private Cleanup after_each =
            () =>
            {
                try
                {
                    driver.Quit();
                }
                catch (Exception)
                {
                    // Ignore errors if unable to close the browser
                }
                verification_errors.ToString().ShouldEqual("");
            };

        private It should_do_something =
            () =>
            {
                
            };

        private static bool is_element_present(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private static string close_alert_and_get_its_text()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                if (accept_next_alert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alert.Text;
            }
            finally
            {
                accept_next_alert = true;
            }
        }
    }
}