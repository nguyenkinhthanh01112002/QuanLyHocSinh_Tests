using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestServers
{
    public class TestLMSAutomatic
    {
        IWebDriver driver;
        [SetUp]
        public void startBrowser()
        {
            string userProfilePath = @"C:\Users\KINHTHANH\AppData\Local\Google\Chrome\User Data\Profile 7";

            ChromeOptions options = new ChromeOptions();
            // Thiết lập đường dẫn hồ sơ người dùng
            options.AddArgument("user-data-dir=" + userProfilePath);
            driver = new ChromeDriver(options);
          //  driver.Manage().Window.Maximize();
            // Mở một trang web
            
             driver.Manage().Window.Maximize();
              driver.Navigate().GoToUrl("https://lms.poly.edu.vn/");
            Thread.Sleep(1000000);
            driver.Quit();
        }
        [Test]
        public void Test_01()
        {
           

        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
    
}
