using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace CheckTime
{
    public class Test
    {
        [Test]
        public void CheckLocalTime()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions edgeOptions = new ChromeOptions();
            edgeOptions.AddArguments("--headless", "--disable-extensions", "--disable-gpu");
            IWebDriver driver = new ChromeDriver(edgeOptions);
            driver.Navigate().GoToUrl("http://google.ru");
            WebElement googleSearch = (WebElement)driver.FindElement(By.Name("q"));
            googleSearch.SendKeys("время");
            googleSearch.Submit();
            var googleTime = driver.FindElement(By.XPath("//div[@id='res']//div[@role='heading']")).Text;
            var localTime = DateTime.Now.ToString("HH:mm");
            driver.Quit();
            Assert.That(localTime, Is.EqualTo(googleTime), "Your local time incorrect");
        }
    }
}