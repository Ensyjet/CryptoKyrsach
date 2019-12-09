using System;
using System.Numerics;
using DopLib;

namespace Signature
{
    class Program
    {
        static void Main()
        {
            string inputText = "ШМОНИН";
            int p = 13;
            int q = 19;
            BigInteger n = p * q;
            int fi = (p - 1) * (q - 1);
            int d =115;
            int H0 = 13;
            BigInteger hash = Reform.NumberLetters(inputText, n, H0);
            //Console.WriteLine("Хеш-образ:" + hash);
            //Console.WriteLine("Простое число:" + n);
            int e = Reform.FindE(fi, d);
           //Console.WriteLine("Открытый ключ:" + e);
            BigInteger signature =  BigInteger.ModPow(hash,d,n);
            Console.WriteLine("ЭЦП:" + signature);
            Control(e,n,hash,signature);            
            Console.ReadKey();
        }
        public static void Control(int e,BigInteger n,BigInteger hash,BigInteger signature)
        {
            BigInteger checkSignature =  BigInteger.ModPow(signature,e,n);
            Console.WriteLine("Проверка ЭЦП:" + checkSignature);
            if (checkSignature == hash)
            {
                Console.WriteLine("Проверка пройдена");
            }
            else
            {
                Console.WriteLine("Проверка не пройдена");
            }
        }
    }
}
