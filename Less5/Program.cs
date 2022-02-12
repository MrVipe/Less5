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
            File.AppendAllText("startup.txt", Convert.ToString(DateTime.Now) + Environment.NewLine);
            Console.WriteLine(File.ReadAllText("startup.txt"));
            Console.ReadKey();
        }
    }
}
