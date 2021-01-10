using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebApiForProductList.Controllers;

namespace MVCUnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CRUDController cd = new CRUDController();
            
            ViewResult result = cd.Create() as ViewResult;

            Assert.IsNotNull(result);
                

        }
    }
}
