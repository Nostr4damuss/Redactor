using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace redac
{
    internal class Program
    {
        public static List<Geometry> geometries = new List<Geometry>() {
         new Geometry("Прямоугольник","60","90")
        };
        static void Main()
        {
            Console.WriteLine("Введите, что хотите открыть (.txt, .json, .xml)");
            Console.WriteLine("--------------------------------------------------------");
            string savafile = Console.ReadLine();
            ToFile(savafile);
        }
        public static void ToFile(string Line)
        {
            Soc.YUR = Line;
            if (File.Exists(Soc.YUR))
            {
                Console.Clear();
                Soc.Opened();
            }
            else
            {
                if (Soc.Create())
                {
                    Console.WriteLine("Создание файла");
                }
                else
                {
                    Console.WriteLine("Произошла ошибка");
                    Exit();
                }
            }
        }
        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}