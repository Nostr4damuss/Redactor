
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Text.Json;
using redac;

namespace redac
{
    internal class Soc
    {
        public static string YUR;
        public static void Opened()
        {
            Console.WriteLine("Сохранить файл в одном из трёх фрагментов (txt, json, xml) - F1.  Escape - Закрыть программу");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            string extension = Path.GetExtension(YUR);
            if (extension == ".txt")
            {
                string[] list = File.ReadAllLines(YUR);
                foreach (var item in list) Console.WriteLine(item);
            }
            else if (extension == ".json")
            {
                string text = File.ReadAllText(YUR);
                List<Geometry> geometries = JsonConvert.DeserializeObject<List<Geometry>>(text);
            }
            else if (extension == ".xml")
            {
                XmlSerializer xml = new XmlSerializer(Program.geometries.GetType());
                using (FileStream fs = new FileStream(YUR, FileMode.OpenOrCreate))
                {
                    List<Geometry> list = (List<Geometry>)xml.Deserialize(fs);
                    foreach (Geometry item in list)
                    {
                        Console.WriteLine(item.Figure);
                        Console.WriteLine(item.Linelength.ToString());
                        Console.WriteLine(item.Width.ToString());
                    }
                }
            }
            Button();
        }
        public static bool Create()
        {
            string extension = Path.GetExtension(YUR);
            if (extension == ".txt")
            {
                using StreamWriter sw = new StreamWriter(YUR);
                for (int i = 0; i < Program.geometries.Count; i++)
                {
                    sw.WriteLine(Program.geometries[i].Figure);
                    sw.WriteLine(Program.geometries[i].Linelength.ToString());
                    sw.WriteLine(Program.geometries[i].Width.ToString());
                }
            }
            else if (extension == ".json")
            {
                using StreamWriter sw = File.CreateText(YUR);
                for (int i = 0; i < Program.geometries.Count; i++)
                {
                    sw.WriteLine(Program.geometries[i].Figure);
                    sw.WriteLine(Program.geometries[i].Linelength.ToString());
                    sw.WriteLine(Program.geometries[i].Width.ToString());
                }
                sw.WriteLine(JsonConvert.SerializeObject(Program.geometries));
            }
            else if (extension == ".xml")
            {
                XmlSerializer xml = new XmlSerializer(Program.geometries.GetType());
                using FileStream fs = new FileStream(YUR, FileMode.OpenOrCreate);
                xml.Serialize(fs, Program.geometries);
            }
            else return false;
            return true;
        }
        private static void Save()
        {
            Console.Clear();
            Console.WriteLine("Введите путь файла, для успешного сохранения ");
            Console.WriteLine("------------------------------------------------");
            string readLine = Console.ReadLine();
            Soc.YUR = readLine;
            if (Soc.Create())
            {
                Console.WriteLine("Успешно сохранено! ");
            }
            else Console.WriteLine("Произошла ошибка!");
            Program.Exit();
        }
        private static void Button()
        {
            ConsoleKeyInfo button = Console.ReadKey();
            if (button.Key == ConsoleKey.Escape)
                Program.Exit();
            else if
                (button.Key == ConsoleKey.F1) Soc.Save();
            else
            {
                Console.Clear();
                Program.ToFile(Soc.YUR);
            }
        }
    }
}