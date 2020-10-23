using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public class Log
    {
        public static void DebugLog(string msg)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[{DateTime.Now.TimeOfDay}] [LOG] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DebugWarning(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[{DateTime.Now.TimeOfDay}] [WARNING] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DebugError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{DateTime.Now.TimeOfDay}] [ERROR] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
