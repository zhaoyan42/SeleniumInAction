using System.Linq;
using System.Threading;
using Machine.Specifications;
using OpenQA.Selenium;

namespace SeleniumWebTest.UserStory.我想管理班级.我想管理学生
{
    public class 当添加学生时 : SeleniumWebTestBase
    {
        private Establish that =
            () =>
            {
                //访问班级列表
                driver.Navigate().GoToUrl(base_url + "/Class");
                //点击创建按钮
                driver.FindElement(By.CssSelector("a[href='/Class/Create']")).Click();
                //填入班级名称
                driver.FindElement(By.Name("Name")).SendKeys("班级1");
                //点击提交
                driver.FindElement(By.CssSelector("input[type='submit']")).Click();

                //------------成功后自动跳转到班级列表

                //TODO:去掉显示延时
                Thread.Sleep(2000);

                //点击班级详情按钮
                driver.FindElement(By.CssSelector("a[href='/Class/Details/1']")).Click();
                //点击创建学生按钮
                driver.FindElement(By.CssSelector("a[href='/Student/Create/1']")).Click();
                //填入学生名称
                driver.FindElement(By.Name("Name")).SendKeys("学生1");
                //填入学生学号
                driver.FindElement(By.Name("Number")).SendKeys("0001");
                //点击提交
                driver.FindElement(By.CssSelector("input[type='submit']")).Click();
            };

        private It 应该在列表页面显示所添加的班级 =
            () =>
            {
                //访问班级详情
                driver.Navigate().GoToUrl(base_url + "/Class/Details/1");

                //TODO:去掉显示延时
                Thread.Sleep(2000);

                //验证添加的学生在列表中
                driver.FindElements(By.TagName("p")).Any(x => x.Text.Contains("学生1")).ShouldBeTrue();
            };
    }
}