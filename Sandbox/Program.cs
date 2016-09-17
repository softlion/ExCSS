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

            var css = Directory
                .EnumerateFiles(@"c:\temp\-testcss", "*.css")
                .Select(x => Tuple.Create(x, File.ReadAllText(x)))
                .OrderByDescending(x=>x.Item1.Contains("_bQcAgSz63h"))
                .ToArray();
            while (true)
            {
                foreach (var file in css)
                {
                    var p = new ExCSS.Parser();
                    var q = p.Parse(file.Item2);

                    var a = new StringBuilder();
                    q.ToString(a, true);
                    /*File.WriteAllText(@"c:\temp\-testcss\optimized\" + Path.GetFileNameWithoutExtension(file.Item1) + ".formatted.css", a.ToString(), Encoding.UTF8);


                    var b = new StringBuilder();
                    q.ToString(b, false);
                    File.WriteAllText(@"c:\temp\-testcss\optimized\" + Path.GetFileNameWithoutExtension(file.Item1) + ".compact.css", b.ToString(), Encoding.UTF8);
                    */

                }
                //return;
            }

            /*var k = new HtmlAgilityPack.HtmlDocument();
            k.LoadHtml(File.ReadAllText(@"c:\temp\google.html")); ;
            var styles = k.DocumentNode.Descendants().Where(x => x.Name == "style");
            foreach (var style in styles.Take(1))
            {

                var p = new ExCSS.Parser();
                var d = p.Parse(style.InnerText).ToString();
                if (d.Contains(":px") || d.Contains(": px")) Debugger.Break();
            }*/
        }
    }
}
