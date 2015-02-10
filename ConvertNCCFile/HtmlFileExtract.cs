using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ConvertNCCFile
{
    public class HtmlFileExtract : IExtractBehavior
    {
        public ICollection<Bill> GetBills(string htmlFilePath)
        {
            var doc = new HtmlDocument();
            doc.Load(htmlFilePath, Encoding.UTF8);

            var subscriberNodes = doc.DocumentNode.Descendants("td").Where(d => d.InnerText.StartsWith("Абонент ")).ToList();
            var totalNodes = doc.DocumentNode.Descendants("td").Where(d => d.InnerText.StartsWith("Итого начислений за период ")).ToList(); 

            var list = new List<Bill>();
            foreach (var node in subscriberNodes)
            {
                var subscriber = node.InnerText;
                var total = totalNodes.First(t => t.Line >= node.Line).NextSibling.InnerText;

                list.Add(new Bill(subscriber, total));
            }

            return list;
        }
    }
}
