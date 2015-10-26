using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PaintWebSite;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly Dictionary<string, string> dVerify = new Dictionary<string, string>
        {
            {"Grey", "5"},
            {"Indigo", "6"},
            {"Red", "3"},
            {"Turquoise", "17"}
        };
        /// <summary>
        /// Validate whether the retrieved data is correct or not
        /// </summary>
        [TestMethod]
        public void RetrieveDataTest()
        {
            List<String> retData = new List<string>();      //List which will receive the data from the database
            string verQnt;                                  //Auxilary variable that receives the value from the dictionary according to the entered key

            retData = PaintStore.RetrieveData();            //Calling the method which access the database and returns the data
            int test = dVerify.Count, test2 = retData.Count;
            Assert.AreEqual(dVerify.Count, retData.Count/2);    //Verifies whether the size of the shown table matches the expected table.

            for(int i = 0; i < retData.Count; i++)
            {
                if (dVerify.TryGetValue(retData[i].ToString(), out verQnt)) 
                    Assert.AreEqual(verQnt, retData[++i].ToString(), false, "Fail: quantity in stock not as expected.");
                else
                    Assert.Fail("Key not found on Dictionary");
            }
        }
    }
}
