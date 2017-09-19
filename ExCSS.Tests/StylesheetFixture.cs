using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExCSS.Tests
{
    [TestClass]
    public class StylesheetFixture
    {
        [TestMethod]
        public void Empty_stylesheet_does_not_throw_on_ToString()
        {
            var parser = new Parser();
            var styleSheet = parser.Parse(string.Empty);
            styleSheet.ToString();
        }
    }
}
