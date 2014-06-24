using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var k = new HtmlAgilityPack.HtmlDocument();
            k.LoadHtml(File.ReadAllText(@"c:\temp\google.html")); ;
            var styles = k.DocumentNode.Descendants().Where(x => x.Name == "style");
            foreach (var style in styles.Take(1))
            {

                var p = new ExCSS.Parser();
                var d = p.Parse(style.InnerText).ToString();
                if (d.Contains(":px") || d.Contains(": px")) Debugger.Break();
            }
        }
    }
}
