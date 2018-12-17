using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombinator.Traceability
{
    public static class MyLogger
    {
        public static bool Enabled = false;

        public static void Log(string text)
        {
            if(Enabled) Console.WriteLine(text);
        }
    }
}
