using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Less5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            if (File.Exists("tasks.json") == false)
            {
                //создаем задачи
                string[] newTitle = { "Сделать зарядку", "Сходить в магазин", "Заказать подушку", "Купить торт", "Сходить на пляж", "Разбить посуду", "Поменять лампочку", "Посмотреть фильм", "Помолиться", "Поехать на дачу к бабушке" };
                string[] isDone = { "0", "1", "0", "0", "0", "0", "0", "1", "0", "0" };
                ToDo myList = new ToDo(); //создаем экземпляр класса

                myList.Title = newTitle;
                myList.IsDone = isDone;

                string json = JsonConvert.SerializeObject(myList); //заносим через Json в файл
                File.WriteAllText("tasks.json", json);
                //Console.WriteLine(json);
            }


            string loadJson = File.ReadAllText("tasks.json");
            ToDo myList2 = JsonConvert.DeserializeObject<ToDo>(loadJson); //Загружаем в объект




            //ставить "галочки"
            string numZadach = "";
            do
            {
                //вывод на экран
                Console.WriteLine("Текущие задачи: " + Environment.NewLine);

                int maxTitle = 0;
                for (int i = 0; i < myList2.Title.Length; i++)
                {
                    if (myList2.Title[i].Length > maxTitle)
                    {
                        maxTitle = myList2.Title[i].Length;
                    }
                }
                maxTitle += 2;

                for (int i = 0; i < myList2.Title.Length; i++) //отрисовка
                {
                    Console.WriteLine(i + 1 + @". """ + myList2.Title[i] + @"""   " + (myList2.IsDone[i] == "1" ? getProbel(maxTitle - myList2.Title[i].Length - (i >= 9 ? 1 : 0)) + "[x]" : getProbel(maxTitle - myList2.Title[i].Length - (i >= 9 ? 1 : 0)) + "[]"));
                }

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Выделите номер задачи, которая выполнена. Для отмены введите 0:" + Environment.NewLine);
                numZadach = Console.ReadLine();

                try
                {
                    if (numZadach != "0")
                    {
                        myList2.IsDone[Convert.ToInt32(numZadach) - 1] = "1";
                    }
                }
                catch (System.IndexOutOfRangeException)
                {
                    Console.WriteLine(@"Значение " + numZadach + @" выходит за диапазон допустимых значений. Введите другое значение");
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Введено не числовое значение " + numZadach + @". Введите другое значение");
                }
                
            } while (numZadach != "0");

            string json2 = JsonConvert.SerializeObject(myList2); //заносим через Json в файл
            File.WriteAllText("tasks.json", json2);

            Console.ReadKey();



        }
        static string getProbel(int numSymbol) //делаем "галочки" равно в колонку
        {
            string probel = "";

            for (int i = 1; i < numSymbol; i++)
            {
                probel += " ";
            }

            return probel;
        }

    }
}
