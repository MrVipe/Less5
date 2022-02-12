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
            File.WriteAllText("recurDir.txt", ""); //чистим
            string path = @"C:\Users\lena\source\repos\test\test";

            GetNewPath(0, path);
            
            Console.WriteLine(File.ReadAllText("recurDir.txt"));
            Console.ReadKey();
        }

        static void GetNewPath(int lvl, string oldPath)
        {
            File.AppendAllText("recurDir.txt", oldPath + Environment.NewLine);// Записываем директорию
            string[] getDir = Directory.GetDirectories(oldPath); //получаем директорию
            string[] getFile =  Directory.GetFiles(oldPath).Select(Path.GetFileName).ToArray(); //получаем файлы в тек. директории
            File.AppendAllLines("recurDir.txt", getFile); //записываем файлы

            if (getDir.Length != 0)
            {
                foreach (string item in getDir) //проходы по директориям
                {
                    GetNewPath(lvl + 1, item);
                }
            }
        }

    }

}

