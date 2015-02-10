using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConvertNCCFile
{
    public interface IExtractBehavior
    {
        ICollection<Bill> GetBills(string htmlFilePath);
    }
}
