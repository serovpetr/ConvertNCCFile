using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConvertNCCFile
{
    public interface IExportBehavior
    {
        void Export(string filePath, ICollection<Bill> bills);
    }
}
