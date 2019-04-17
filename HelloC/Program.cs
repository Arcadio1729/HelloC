using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szkolenie
{
    namespace HelloC
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("This is console app");
                //ZmienneITypy();
                Converting();
                Console.ReadLine();
            }

            static void ZmienneITypy()
            {
                int var_int32 = 10;
                long var_int64 = 100000000;
                decimal var_dec = 17.29M;
                string var_str = "Sample text";

                System.Int32 a = 5;
                System.Int64 b = 34;
                System.Decimal c = var_dec;

                var_int64 = 13021993 / 13;

                //operatory porównania ==,!=,<,>,>=,<=
                bool isittrue = var_dec > var_int32;

                //operator logiczny: &&, ||, !

                //

                //typy wartościowe i referencyjne
          
      //stos i sterta
                //stos - kopiowanie
                //sterta - wskaźniki

                string sample_text = "A" + "B";

                //Operator terarny. Warunkowy: ?:

                string info = (var_int32 <= 124) ? "This is info" : "No info";

            }

            static void Converting()
            {
                // Niejawna - w górę
                int a = 10;
                long b = a;

                //Jawna - w dół i pomiędzy niezgodnymi typami
                //operator rzutowania
                int c = (int)b;          
                checked
                {
                    //b = (long)(int.MaxValue) + 1;
                    //c = (int)b;
                }
                //checked też jako operator

                //klasa convert
                int d = 34;
                decimal e = Convert.ToDecimal(d);

                string sampleText = "3,1415";
                decimal pi = Convert.ToDecimal(sampleText)+1;

                Console.WriteLine("pi={0}", pi);
                //Console.WriteLine(c);

                //Użycie metody Parse
                pi = decimal.Parse(sampleText);
                Console.WriteLine("pi={0}", pi);

                //TryParse - zwraca bool
                if (decimal.TryParse("123,22", out e))
                {
                    Console.WriteLine("Wrong input");
                }
            }


        }
    }
}

