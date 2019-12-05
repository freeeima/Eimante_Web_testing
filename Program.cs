using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
namespace Selenium
{
    class Demos
    {
        IWebDriver driver;

        static void Main(string[] args)
        { }

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver("C:\\Users\\Mano\\Pictures\\wetransfer-96a12b\\FB\\Afterparty\\chromedriver_win32");
        }

        string CorrectUsername = "e.uselyte@gmail.com";
        string CorrectPassword = "zalgiris";
         
        public void Login(string username, string password)
        {
            driver.FindElement(By.XPath("//*[@id='email']")).SendKeys(username);
            driver.FindElement(By.XPath("//*[@id='passwd']")).SendKeys(password);
        }

       [Test]
        public void LoginButton()
        {
            driver.Url = "http://automationpractice.com/";
            driver.FindElement(By.XPath("//*[@id='header']/div[2]/div/div/nav/div[1]/a")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Login(CorrectUsername, CorrectPassword);
            driver.FindElement(By.XPath("//*[@id='SubmitLogin']/span")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [Test]
        public void VisibleAccount()
        {
            //Ar pavyksta log in ir matome my account
            LoginButton();
            var element = driver.FindElement(By.XPath("//*[@id='center_column']/h1"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Assert.IsTrue(element.Displayed);
            Assert.AreEqual(element.Text.ToLower(), "my account".ToLower());
        }
        
        [Test]
        public void FoundBlouse()
        {
            // serach mygtukas, particular daikto paieška
            LoginButton();
            driver.FindElement(By.XPath("//*[@id='search_query_top']")).SendKeys("Blouse");
            driver.FindElement(By.XPath("//*[@id='searchbox']/button")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            var element = driver.FindElement(By.XPath("//*[@id='center_column']/ul/li/div/div[2]/h5/a"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            Assert.IsTrue(element.Displayed);
            Assert.AreEqual(element.Text.ToLower(), "Blouse".ToLower());
        }

        [Test]
        public void SuccesfullPurchase()
        {
            //adding to cart
            LoginButton();
            driver.FindElement(By.XPath("//*[@id='search_query_top']")).SendKeys("Blouse");
            driver.FindElement(By.XPath("//*[@id='searchbox']/button")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
           // driver.SwitchTo().Frame(driver.FindElement(By.XPath("//frame[@id='layer_cart']")));
            
            driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div[2]/ul/li/div/div[1]/div/a[1]/img")).Click();
            driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div/div[4]/form/div/div[3]/div[1]/p/button/span")).Click();
            //var element = driver.FindElement(By.Id("layer_cart"));
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //var element = driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[4]/div[1]/div[1]/h2/text()"));

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            //By container = By.CssSelector("layer_cart_product col-xs-12 col-md-6");
            //TimeSpan Wait20 = new TimeSpan(20);
            //WebDriverWait Pause = new WebDriverWait(driver, Wait20);
            //Pause.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("layer_cart")));
            //var element = driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[4]/div[1]/div[1]/h2/text()"));
            //var element = driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[1]/h2"));
            //var element = driver.FindElement(By.Id("layer_cart"));
            //Console.WriteLine(element.Text);
            //Assert.IsTrue(element.Displayed);
            //Assert.AreEqual("product successfully added to your shopping cart", element.Text.ToLower());

            driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[4]/div[1]/div[2]/div[4]/a/span/i")).Click();
            driver.FindElement(By.XPath("//html/body/div/div[2]/div/div[3]/div/p[2]/a[1]/span")).Click();
            driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/form/p/button/span")).Click();
            driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/div/p[2]/div/span/input")).Click();
            driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/p/button/span")).Click();
            driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div[3]/div[2]/div/p/a")).Click();
            driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/form/p/button/span")).Click();





        }


        /*
        element = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div[2]/p"));

        if (element != null)
        {
            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Text.ToLower().Contains("Blouse"));
        }
    */

        /*
        Assert.AreEqual(element.Text.ToLower(), "no results".ToLower());

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        */

        [TearDown]

        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}








