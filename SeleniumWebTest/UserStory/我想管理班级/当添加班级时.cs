using System.Linq;
using Machine.Specifications;
using OpenQA.Selenium;

namespace SeleniumWebTest.UserStory.我想管理班级
{
    public class 当添加班级时 : SeleniumWebTestBase
    {
        private Establish that =
            () =>
            {
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
                driver.FindElements(By.TagName("p")).Any(x => x.Text.Contains("班级1")).ShouldBeTrue();
            };
    }
}