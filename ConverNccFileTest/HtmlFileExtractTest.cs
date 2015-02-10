using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertNCCFile;
using NUnit.Framework;

namespace ConverNccFileTest
{
    [TestFixture]
    public class HtmlFileExtractTest
    {
        private IExtractBehavior _extract;

        [SetUp]
        public void Setup()
        {
            _extract = new HtmlFileExtract();
        }

        [Test]
        public void GetBillsTest1()
        {
            var bills = _extract.GetBills("test1.html");
            Assert.AreEqual(2, bills.Count);
        }

        [Test]
        public void GetBillsTest2()
        {
            var bills = _extract.GetBills("test2.html");
            Assert.AreEqual(88, bills.Count);
        }
    }
}
