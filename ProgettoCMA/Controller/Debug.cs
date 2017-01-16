using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA.Controller
{
    static class Debug
    {
        public static void ConsoleWrite(dynamic str)
        {
            if (isDebugPhase())
            {
                Console.Write(str);
            }
        }
        public static void ConsoleWriteLine(dynamic str)
        {
            if (isDebugPhase())
            {
                Console.WriteLine(str);
            }
        }
        public static bool isDebugPhase()
        {
            return Shared.isDebugPhase;
        }
    }
}
