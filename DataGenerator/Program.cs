using System;
using System.Collections.Generic;
using System.IO;

namespace DataGenerator
{
    internal class Program
    {
        private static Random rand = new Random();
        private static string[] nameMale;
        private static string[] nameFemale;
        private static string[] surname;


        static void Main(string[] args)
        {
            nameMale = File.ReadAllLines(@"Data\NameMale.txt", System.Text.Encoding.Unicode);
            nameFemale = File.ReadAllLines(@"Data\NameFemale.txt", System.Text.Encoding.Unicode);
            surname = File.ReadAllLines(@"Data\Surname.txt", System.Text.Encoding.Unicode);

            var resList = new List<string>();

            for (int i = 0; i < 10000; i++)
            {
                var name = string.Empty;

                var isMale = rand.Next(100) < 66;
                var nameFormat = rand.Next(100);

                if (nameFormat < 5) // Ім'я По-Батькові
                {
                    name = GetName(isMale) + ' ' + GetPatronimic(isMale);
                }
                else if (nameFormat < 20) // Прізвище Ім'я По-Батькові
                {
                    name = GetSurName(isMale) + ' ' + GetName(isMale) + ' ' + GetPatronimic(isMale);
                }
                else // Прізвище Ім'я
                    name = GetSurName(isMale) + ' ' + GetName(isMale);

                resList.Add(name);

                File.WriteAllLines("names.txt", resList);                
            }
        }

        private static string GetSurName(bool isMale)
        {
            var name = GetRndValue(surname);

            if (name.EndsWith("ький")) return isMale ? name : name.Substring(0, name.Length -4) + "ька";
            if (name.EndsWith("ька")) return !isMale ? name : name.Substring(0, name.Length - 3) + "ький";

            if (name.EndsWith("ов")) return isMale ? name : name.Substring(0, name.Length - 2) + "ова";

            if (name.EndsWith("овий")) return isMale ? name : name.Substring(0, name.Length - 2) + "ова";            
            if (name.EndsWith("ова")) return !isMale ? name : name.Substring(0, name.Length - 3) + "овий";

            if (name.EndsWith("ів")) return isMale ? name : name.Substring(0, name.Length - 2) + "івна";
            if (name.EndsWith("івна")) return !isMale ? name : name.Substring(0, name.Length - 4) + "ів";

            return name;


            //if (name.IndexOf('%') == -1)
            //    return name;

            ////% 1,((цька) | (цький))$
            ////% 2,((ова) | (ов))$
            ////% 3,((івна) | (ів))$
            ////% 4,((ська) | (ський))$

            //return name.Replace("%1", isMale ? "ький" : "ька")
            //    .Replace("%2", isMale ? "ов" : "ова")
            //    .Replace("%3", isMale ? "ів" : "івна")
            //    .Replace("%4", isMale ? "ський" : "ська");
        }

        private static string GetPatronimic(bool isMale)
        {
            // TODO Зробити правильні закінчення
            var name = GetRndValue(nameMale);

            if (isMale)
            {
                if (name.Equals("Лука")) return "Лукич";
                if (name.Equals("Сава")) return "Савич";
                if (name.Equals("Кузьма")) return "Кузьмич";
                if (name.Equals("Хома")) return "Хомич";
                if (name.Equals("Яків")) return "Якович";
                if (name.Equals("Ілля")) return "Ілліч";
                if (name.Equals("Григорій")) return "Григорович";
                if (name.Equals("Микола")) return "Миколайович";

                return name + "ович";
            }

            // Female
            if (name.Equals("Яків")) return "Яківна";
            if (name.Equals("Григорій")) return "Григорівна";
            if (name.Equals("Микола")) return "Миколаївна";

            if (name.EndsWith('й')) return name.Substring(0, name.Length - 1) + "ївна"; // Анатолій, Андрій

            if (name.EndsWith('о')) return name.Substring(0, name.Length - 1) + "івна"; // Данило, Михайло

            return name + "івна";
        }

        private static string GetName(bool isMale)
        {
            return isMale ? GetRndValue(nameMale) : GetRndValue(nameFemale);
        }

        private static string GetRndValue(string[] arr)
        {
            return arr[rand.Next(arr.Length)];
        }
    }
}