using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace ChromeBrowser
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }

        [TestMethod]
        public void ChromeTest()
        {
            //Store the rows that should be shown on the website
            List<String> elements = new List<String>(new String[]{
                "Paint Name Quantity",
                "Red 3", "Turquoise 17", "Grey 5","Indigo 6"
            });

            //Initialize Google Chrome Browser and goes to our website
            IWebDriver driver = new ChromeDriver(@"C:\Database System\Assignment1\PaintWebSite\ChromeBrowser\bin\Debug");
            driver.Navigate().GoToUrl("http://localhost/PaintWebSite/PaintStore.aspx");

            //Retrieve all the data in the shown table
            IWebElement table = driver.FindElement(By.TagName("table"));
            IList<IWebElement> tableRows = table.FindElements(By.TagName("tr"));

            Assert.AreEqual(elements.Count, tableRows.Count);  //Verifies whether the size of the shown table matches the expected table.

            //Iterate each row of the retrieved data verifying whether the data is correct or not
            foreach(IWebElement row in tableRows)
            {
                Assert.IsTrue(elements.Contains(row.Text), "Row " + row.Text + " incorrect");
            }

            //Close the browser
            driver.Close();
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
