using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_App
{
    public class Helpers
    {
        public static string Color(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor= ConsoleColor.White;
            return text;
        }

    }
}
