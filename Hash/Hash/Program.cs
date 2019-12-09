using System;

namespace Hash
{
    class Program
    {
        static void Main()
        {
            string inputText = "ЛЕГКОВ";
            int p = 5;
            int q = 19;
            int n = p * q;
            int H0 = 8;
            int hash= NumberLetters(inputText,n,H0);
            Console.WriteLine("Хеш-образ:" + hash);
            Console.ReadKey();
        }
        private static int  NumberLetters(string inputText, int n, int H0)
        {
            var hash = H0;
            char[] TextMas = inputText.ToCharArray();
            for(int i=0; i < TextMas.Length; i++)
            {
                int DopTransformation = (int)TextMas[i]-848;
                hash =(int) (Math.Pow(hash + DopTransformation,2)) % n;
            }
            return hash;
        }
    }
}