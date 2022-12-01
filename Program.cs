using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti un sir de caractere");
            string str = Console.ReadLine();
            str = str.ToUpper();

            Console.WriteLine("Baza initiala=");
            int b1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Baza finala=");
            int b2 = int.Parse(Console.ReadLine());

            for (int i = 0; i < str.Length; i++)//verificam daca secventa data e in baza b1
            {
                int valoare = charValue(str[i]);
                if (valoare >= b1)
                {
                    Console.WriteLine("Nr. nu e in baza b1.");
                    return;
                }
            }
            if (b1 < 2 || b2 > 16)
                Console.WriteLine("Nr. introdus nu este in baza corecta.");

            int PozitieVirgula = str.IndexOf(",");  //cauta pozitia virgulei in sir
            int cifreDupaVirgula;
            int nrZecimale;

            if (PozitieVirgula > 0)
            {
                Console.WriteLine("Virgula e la pozitia={0}", PozitieVirgula);
                cifreDupaVirgula = str.Length - PozitieVirgula - 1;  //calculeaza nr de cifre dupa virgula

                Console.WriteLine("Introduceti nr. de zecimale dorite=");
                nrZecimale = int.Parse(Console.ReadLine());
            }
            else
            {
                cifreDupaVirgula = 0;
                nrZecimale = 0;
            }
            string str2 = str.Replace(",", "");  // elimina virgula rezultand partea intreaga si partea fractionara concatenate

            int nr1 = ConvertTo10(str2, b1); // converteste string-ul in int

            float nr2 = nr1 / (float)Math.Pow(b1, cifreDupaVirgula); // transforma nr la precizia initiala

            nr2 = nr2 * (float)Math.Pow(b2, nrZecimale);   // punem toate cifrele dorite in partea intreaga 

            int nr3 = (int)Math.Round(nr2);
            string str3 = ConvertTob2(nr3, b2);   //converteste nr in baza b2

            if (nrZecimale > 0)
            {
                str3 = str3.Insert(str3.Length - nrZecimale, ",");  // pune virgula la locul potrivit (cel initial)
            }
            Console.WriteLine($"Numarul final in baza b2={str3}");
        }
        static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        static int pow(int baza, int exp)//functia putere
        {
            int nr = 1;
            for (int i = 0; i < exp; i++)
            {
                nr = nr * baza;
            }
            return nr;
        }
        static int charValue(char x)  // transforma fiecare caracter al secventei date in cifra corespunzatoare in baza 10
        {
            if (Char.IsDigit(x))
                return x - '0'; //x-'0'=x-48
            else
                return x - 'A' + 10;
        }
        static char charOutput(int x)
        {
            char c;
            if (x < 10)
               c = (char)('0' + x);
            else
                c = (char)('A' + (x - 10));
            return c;
        }
        static int ConvertTo10(string str, int b1)
        {
            int nr = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int valoare = charValue(str[i]);
                nr += valoare * pow(b1, (str.Length - i - 1)); //nr = nr* b1+ valoare;
            }
            return nr;
        }
        static string ConvertTob2(int nr, int b2)
        {
            int r;
            char c;
            StringBuilder sb = new StringBuilder();
            while (nr != 0)
            {
                r = nr % b2;
                nr = nr / b2;
                c = charOutput(r);
                sb.Append(c);
            }
            return Reverse(sb.ToString());
        }
    }
}
