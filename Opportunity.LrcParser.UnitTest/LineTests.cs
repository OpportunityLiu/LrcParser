using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Opportunity.LrcParser.UnitTest
{
    [TestClass]
    public class LineTests
    {
        [DataRow("", "")]
        [DataRow(default(string), "")]
        [DataRow("  \r\n", "")]
        [DataRow("s", "s")]
        [DataRow("s  ", "s")]
        [DataRow("  s \n ", "s")]
        [DataTestMethod]
        public void Create(string content, string expected)
        {
            var ts = new DateTime(DateTime.Now.Ticks);
            var line = new Line(ts, content);
            Assert.AreEqual(expected, line.Content);
            Assert.AreEqual(ts.TimeOfDay.Ticks, line.Timestamp.Ticks);
        }

        [DataRow("", "", "", "", "")]
        [DataRow("", "", "  s ", "s", "s")]
        [DataRow("  s ", "s", "", "", "s: ")]
        [DataRow(" sa ", "sa", " s ", "s", "sa: s")]
        [DataRow(null, "", "", "", "")]
        [DataRow(null, "", default(string), "", "")]
        [DataRow(null, "", "  \r\n", "", "")]
        [DataRow(null, "", "s", "s", "s")]
        [DataRow(null, "", "s  ", "s", "s")]
        [DataRow(null, "", "  s \n ", "s", "s")]
        [DataTestMethod]
        public void CreateWithSpeaker(string speaker, string expectedSpeaker, string lyrics, string expectedLyrics, string expected)
        {
            var ts = new DateTime(DateTime.Now.Ticks);
            var line = new LineWithSpeaker(ts, speaker, lyrics);
            Assert.AreEqual(expectedSpeaker, line.Speaker);
            Assert.AreEqual(expectedLyrics, line.Lyrics);
            Assert.AreEqual(ts.TimeOfDay.Ticks, line.Timestamp.Ticks);
            Assert.AreEqual(new Line(ts, expected).ToString(), line.ToString());
        }
    }
}
