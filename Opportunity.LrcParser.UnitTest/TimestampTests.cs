using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Opportunity.LrcParser.UnitTest
{
    [TestClass]
    public class TimestampTests
    {
        [TestMethod]
        public void Create()
        {
            Assert.AreEqual(new DateTime(1, 1, 1, 0, 0, 1, 100), Timestamp.Create(1, 100));
            Assert.AreEqual(new DateTime(1, 1, 1, 0, 0, 1, 100), Timestamp.Create(1100));
            Assert.AreEqual(new DateTime(1, 1, 1, 0, 1, 2, 100), Timestamp.Create(62, 100));
            Assert.AreEqual(new DateTime(1, 1, 1, 0, 1, 1, 100), Timestamp.Create(1, 1, 100));
        }
    }
}
