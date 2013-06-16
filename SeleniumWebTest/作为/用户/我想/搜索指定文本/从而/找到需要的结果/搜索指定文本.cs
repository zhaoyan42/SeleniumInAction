using Machine.Specifications;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumWebTest.作为.用户.我想.搜索指定文本.从而.找到需要的结果
{
    [Subject("搜索指定文本")]
    public class 搜索指定文本
    {
        private static IWebDriver driver;
        private static string base_url;

        private Establish 在搜索主页面输入指定文本 =
            () =>
            {
                driver = new FirefoxDriver();
                base_url = "http://www.baidu.com";

                driver.Navigate().GoToUrl(base_url + "/");
                driver.FindElement(By.Id("kw")).Clear();
                driver.FindElement(By.Id("kw")).SendKeys(keyword);
            };

        private Because 点击搜索按钮 =
            () => driver.FindElement(By.Id("su")).Click();

        private It 应该在得到的第一条搜索结果中包含搜索的关键字 =
            () => driver.FindElements(By.CssSelector("#content_left table.result"))[0].Text.ShouldContain(keyword);

        private Cleanup after_each =
            () => driver.Quit();

        private static string keyword = "暴走漫画";
    }
}