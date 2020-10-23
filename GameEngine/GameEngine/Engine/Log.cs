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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] [LOG] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DebugWarning(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[{DateTime.Now.ToString("HH: mm:ss")}] [WARNING] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DebugError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{DateTime.Now.ToString("HH: mm:ss")}] [ERROR] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
