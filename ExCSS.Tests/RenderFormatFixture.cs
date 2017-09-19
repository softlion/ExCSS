
using System.Text;
using ExCSS.Tests.Stylesheets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExCSS.Tests
{
    [TestClass]
    public class RenderFormatFixture
    {
        [TestMethod]
        public void Stylesheet_Renders_Inline()
        {
            var parser = new Parser();
       
            var css = parser.Parse(Resources.Css3);

            Assert.AreEqual(Resources.Css3Min, css.ToString());
        }

        [TestMethod]
        public void Stylesheet_Renders_Friendly_Format()
        {
            var parser = new Parser();
            var css = parser.Parse(Resources.Css3);

            Assert.AreEqual(Resources.Css3Friendly, css.ToString(new StringBuilder(), true).ToString());
        }
    }
}
