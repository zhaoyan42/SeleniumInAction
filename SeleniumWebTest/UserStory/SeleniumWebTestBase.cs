using System;
using System.Text;
using Machine.Specifications;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumWebTest.UserStory
{
    public class SeleniumWebTestBase
    {
        protected static IWebDriver driver;
        private static StringBuilder verification_errors;
        protected static string base_url;
        private static bool accept_next_alert = true;

        private Establish that =
            () =>
            {
                driver = new FirefoxDriver();
                base_url = "http://localhost:63928/";
                verification_errors = new StringBuilder();

                //清空数据库
                driver.Navigate().GoToUrl(base_url + "ClearDatabase");
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