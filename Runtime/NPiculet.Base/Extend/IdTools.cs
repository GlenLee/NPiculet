using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPiculet.Library.Extend
{
    public class IdTools
    {
        public static string get32Guid()
        {
            return System.Guid.NewGuid().ToString().Replace("-", "");
        }
        static void main(string[] args)
        {
            Trace.Write(get32Guid());

        }
    }
}
