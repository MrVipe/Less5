using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Less5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText("newtext.txt", Console.ReadLine());

            Console.WriteLine(File.ReadAllText("newtext.txt"));
            Console.ReadKey();
        }
    }
}
