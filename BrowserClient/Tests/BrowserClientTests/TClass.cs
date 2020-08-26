using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserClientTests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class TClass
    {
        [TestMethod]
        public void Test1()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void Test2()
        {
            Assert.IsTrue(false);
        }
    }
}
