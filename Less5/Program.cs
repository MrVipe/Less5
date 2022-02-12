using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Less5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] stringByte;
            stringByte = Console.ReadLine().Split(' ').ToArray();
            byte[] massByte = new byte[stringByte.Length];

            for (int i = 0; i < stringByte.Length; i++)
            {
                massByte[i] = Convert.ToByte(stringByte[i]);
            }

            File.WriteAllBytes("cifr.bin", massByte);
            Console.ReadKey();

        }
    }
}
