using System;
using System.Linq;
using System.Text;
using Machine.Specifications;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumWebTest.UserStory
{
    public class 当添加班级时
    {
        private static IWebDriver driver;
        private static StringBuilder verification_errors;
        private static string base_url;
        private static bool accept_next_alert = true;

        private Establish that =
            () =>
            {
                driver = new FirefoxDriver();
                base_url = "http://localhost:63928/";
                verification_errors = new StringBuilder();

                //清空数据库
                driver.Navigate().GoToUrl(base_url + "ClearDatabase");

                //访问班级列表
                driver.Navigate().GoToUrl(base_url + "Class");
                //点击创建按钮
                driver.FindElement(By.CssSelector("a[href='/Class/Create']")).Click();
                //填入班级名称
                driver.FindElement(By.Name("Name")).SendKeys("班级1");
                //点击提交
                driver.FindElement(By.CssSelector("input[type='submit']")).Click();
            };

        private It 应该在列表页面显示所添加的班级 =
            () =>
            {
                //访问班级列表
                driver.Navigate().GoToUrl(base_url + "Class");
                //点击添加按钮
                driver.FindElements(By.TagName("p")).Any(x=>x.Text.Contains("班级1")).ShouldBeTrue();
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