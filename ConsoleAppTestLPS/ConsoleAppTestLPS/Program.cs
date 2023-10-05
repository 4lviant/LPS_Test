using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppTestLPS
{

    class Program
    {
        static void Main()
        {
            SoalB();

            #region Soal C
            Console.Write("Input string: ");
            string inputstring = Console.ReadLine();

            Dictionary<char, int> Jmlchar = new Dictionary<char, int>();

            foreach (char Item in inputstring)
            {
                if (char.IsLetter(Item))
                {
                    char lower = char.ToLower(Item);
                    if (Jmlchar.ContainsKey(lower))
                    {
                        Jmlchar[lower]++;
                    }
                    else
                    {
                        Jmlchar[lower] = 1;
                    }
                }
            }

            foreach (var item in Jmlchar.OrderBy(i => i.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            Console.ReadLine();
            #endregion

            SoalD();

            #region Soal E
            Console.Write("Input Kata: ");
            string inputKata = Console.ReadLine();

            string formatjudul = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(inputKata);
            string Formatbiasa = CultureInfo.CurrentCulture.TextInfo.ToLower(inputKata);

            Console.WriteLine($"Format Judul: {formatjudul}");
            Console.WriteLine($"Format Biasa: {Formatbiasa}");
            #endregion
            Console.ReadKey();
        }        

        static void SoalB()
        {
            Console.Write("input angka: ");
            string Inputangka = Console.ReadLine();
            int number;
            if (int.TryParse(Inputangka.Replace(".", ""), out number))
            {
                string numberStr = number.ToString();

                for (int i = 0; i < numberStr.Length; i++)
                {
                    int digit = int.Parse(numberStr[i].ToString());
                    int factor = (int)Math.Pow(10, numberStr.Length - i - 1);
                    int result = digit * factor;
                    Console.WriteLine(result);
                }
            }
            else
            {
                Console.WriteLine("Data tidak valid.Silahkan Input Kembali");
                SoalB();
            }

            Console.ReadLine();
           
        }
        static void SoalD()
        {
            #region Soal D
            Console.Write("Input N (angka): ");
            string N = Console.ReadLine();
            int Number;
            if (!int.TryParse(N, out Number))
            {
                Console.WriteLine("Data tidak valid.silahkan input kembali");
                SoalD();
            }
            for (int i = 1; i <= Number; i++)
            {
                string output = "";

                if (i % 5 == 0 && i != 5)
                {
                    output += "IDIC";
                }

                if (i % 6 == 0 && i != 6)
                {
                    output += "LPS";
                }

                if (string.IsNullOrEmpty(output))
                {
                    output = i.ToString();
                }

                Console.Write(output + " ");
            }
            Console.ReadLine();
            #endregion
        }
    }
}

