using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Proxy.Customizers.HtmlCustomizer
{
    public class RemoveTagHtml : ICustomizeHtmlResponse
    {
        private readonly string[] tags;

        public RemoveTagHtml(string[] tags)
        {
            this.tags = tags;
        }
        public MemoryStream CustomizeHtml(string html)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            List<string> xpaths = new List<string>();

            foreach (HtmlNode node in htmlDoc.DocumentNode.DescendantNodes())
            {
                foreach (var tag in tags)
                {
                    if (node.Name.ToLower() == tag)
                    {
                        xpaths.Add(node.XPath);
                    }

                }
            }

            foreach (string xpath in xpaths.Reverse<string>())
            {
                var node = htmlDoc.DocumentNode.SelectSingleNode(xpath);
                if (node != null)
                    node.Remove();
            }

            html = htmlDoc.DocumentNode.InnerHtml;


            byte[] byteArray = Encoding.Default.GetBytes(html);
            var stream = new MemoryStream(byteArray);
            return stream;
        }
    }
}
