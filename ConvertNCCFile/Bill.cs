using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertNCCFile
{
    public class Bill
    {

        public Bill()
        {
        }

        public Bill(string subscriber, string total)
        {
            Subscriber = subscriber.Substring(subscriber.Length - 10, 10);
            Total = Convert.ToDecimal(total.Split(' ').First().Trim(' '));
        }

        public string Subscriber { get; set; }
        public decimal Total { get; set; }
    }
}
