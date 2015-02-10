using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertNCCFile
{
    public class Bills
    {
        private readonly ICollection<Bill> _bills;

        public Bills()
        {
            _bills = new List<Bill>();
        } 

        public Bills(ICollection<Bill> bills)
        {
            _bills = bills ?? new LinkedList<Bill>();
        }

        public void Add(Bill bill)
        {
            _bills.Add(bill);
        }

    }
}
