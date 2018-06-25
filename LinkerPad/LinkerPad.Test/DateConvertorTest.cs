using LinkerPad.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkerPad.Test
{
    [TestClass]
    public class DateConvertorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var miladiDate = DateConvertor.MiladiDate("1395/10/07-10:22:30");
        }
    }
}
