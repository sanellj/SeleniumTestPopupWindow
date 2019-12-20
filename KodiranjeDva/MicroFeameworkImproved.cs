using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace KodiranjeDva
{
    class MicroFeameworkImproved
    {
        [Test]
        public void TestRightClickContextMenu()
        {
            this.NavigateTo("https://www.cssscript.com/demo/lightweight-context-menu-library-class2context-js/");
            var action = new Actions(this.Driver);
            IWebElement div = this.FindElement(By.XPath("//div[contains(@class, 'class1')]"));
            action.ContextClick(div).Perform();
            DoWait(1);
            IWebElement a1 = this.FindElement(By.XPath("//a[contains(., 'A1')]"));
            a1.Click();
            DoWait(2);
            try
            {
                var alert = this.Driver.SwitchTo().Alert();
                alert.Accept();
            }
            catch (NoAlertPresentException e)
            {
                // Do something
            }
            DoWait(2);
        }

        [Test]
        public void TestScrollTo()
        {
            // Works in Chrome, doesn't work in Firefox
            this.NavigateTo("https://www.toolsqa.com/automation-practice-form/");
            DoWait(2);
            IWebElement continents = this.FindElement(By.Id("continents"));
            var action = new Actions(this.Driver);
            action.MoveToElement(continents).Perform();
            DoWait(2);
        }

        [Test]
        public void TestDragAndDrop()
        {
            this.NavigateTo("https://formy-project.herokuapp.com/dragdrop");
            IWebElement target = this.FindElement(By.Id("box"));
            IWebElement drop1 = this.FindElement(By.Id("image"));
            var action = new Actions(this.Driver);
            action.DragAndDrop(drop1, target).Perform();
            /*
            action.ClickAndHold(drop1);
            action.MoveToElement(target);
            action.Release();
            action.Build();
            action.Perform();
            */
            DoWait(2);
        }

        [Test]
        public void TestWindows()
        {
            this.NavigateTo("https://www.seleniumeasy.com/test/window-popup-modal-demo.html");
            IWebElement twitter = this.FindElement(By.XPath("//a[contains(@class, 'followeasy') and contains(., 'Twitter')]"));
            twitter.Click();
            DoWait(1);
            var popup = this.Driver.WindowHandles[1];
            this.Driver.SwitchTo().Window(popup);
            // Executes in popup window
            DoWait(1);
            IWebElement username = this.FindElement(By.Id("username_or_email"));
            username.SendKeys("nekimail@negde.com");
            DoWait(1);
            IWebElement password = this.FindElement(By.Id("password"));
            password.SendKeys("nekasifra");
            DoWait(3);
            this.Driver.Close(); // Closes popup window

            DoWait(2);
            this.Driver.SwitchTo().Window(this.Driver.WindowHandles[0]);
        }

        [Test]
        [Test, Category("Anotacija")] //Promjer NUnit anotacija
        [MaxTime(9999)]
        [Ignore("Ignore")]
        public void TestWaitForElement()
        {
            this.NavigateTo("http://test.qa.rs");
            var findBy = By.XPath("//a[@href = '/new']");
            var wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(20));
            wait.Until(drv => drv.FindElement(findBy));
            IWebElement link = this.FindElement(findBy);
            link.Click();
            DoWait(2);
        }

       
        [SetUp]
        public void SetUpTests()
        {
            this.Driver = new FirefoxDriver();
            //this.Driver = new ChromeDriver();
            this.Driver.Manage().Cookies.DeleteAllCookies();
            this.Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDownTests()
        {
            this.Close();
        }
    }
}
