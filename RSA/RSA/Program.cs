using System;
using System.Numerics;

namespace RSA
{
    class Program
    {
        static void Main()
        {
            string inputText = "ШАА";
            int p = 5;
            int q = 19;
            int n = p * q;
            int fi = (p - 1) * (q - 1);
            int d = 25;
            //int d = MutualPrime(fi);
            int e = FindE(fi, d);
            BigInteger[] ResultCrypto = Crypto(inputText, e, n);
            BigInteger[] ResultDeCrypto = Decrypto(ResultCrypto, d, n);
            Console.WriteLine("n="+n);
            Console.WriteLine("Функция Эйлера:"+fi);
            Console.WriteLine("Закрытый ключ:"+d);
            Console.WriteLine("Открытый ключ:"+e);
            vivod(ResultCrypto);
            vivodDeCrypto(ResultDeCrypto);
            Console.ReadKey(true);
        }

        private static BigInteger[] Crypto(string inputText, int e, int n)
        {
            BigInteger[] Sh = new BigInteger[inputText.Length];
            char[] mas = inputText.ToCharArray();
            for (int i = 0; i < mas.Length; i++)
            {
                int pr = (int)mas[i] - 848;
                Sh[i] = BigInteger.ModPow(pr, e, n);
            }
            return Sh;
        }
        private static BigInteger[] Decrypto(BigInteger[] ResultCrypto, int d, int n)
        {
            BigInteger[] Sh = new BigInteger[ResultCrypto.Length];
            for (int i = 0; i < ResultCrypto.Length; i++)
            { 
                Sh[i] = BigInteger.ModPow(ResultCrypto[i],d, n);
            }
            return Sh;
        }
        private static void vivod (BigInteger[] text)
            {
            for(int i=0; i<text.Length; i++)
            {
                Console.WriteLine(text[i]);
            }
            }
        private static void vivodDeCrypto(BigInteger[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.WriteLine(text[i]);
                int a = (int)text[i]+848;
                Console.WriteLine((char) a);
            }
        }
        private static int MutualPrime(int fi)
        {
            int d = 0;
            Random random = new Random();
            for (int i = 0; i < fi; i++)
            {
                d = random.Next(fi);
                if (Evklid(fi, d) == 1)
                    break;
            }
            return d;
        }
        private static int Evklid(int a,int b)
        {
            int c;
            while (b < 0)
            {
                c = a % b;
                a = b;
                b = c;
            }
            return Math.Abs(a);
        }
        public static int FindE(int fi,int d)
        {
            int e = 0;
            for (int i = 0; i < d; i++)
            { 
                if ((fi * i + 1) % d == 0)
                {
                    e += (fi * i + 1) / d;
                    break;
                }
            }
            return e;
        }           
    }
}