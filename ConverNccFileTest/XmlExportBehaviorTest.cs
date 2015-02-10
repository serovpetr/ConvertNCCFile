using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using ConvertNCCFile;
using NUnit.Framework;

namespace ConverNccFileTest
{
    [TestFixture]
    public class XmlExportBehaviorTest
    {
        private IExportBehavior _xmlExportBehavior;

        [SetUp]
        public void Setup()
        {
            _xmlExportBehavior = new XmlExportBehavior();    
        }

        [Test]
        public void Test1()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "test.xls");

            if(File.Exists(path))
                File.Delete(path);

            var bills = new List<Bill>() {new Bill("79601668887", "100")};
            _xmlExportBehavior.Export(path, bills);

            Assert.AreEqual(File.Exists(path), true);
        }

    }
}
