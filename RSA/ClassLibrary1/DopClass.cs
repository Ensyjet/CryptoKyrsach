using System;
using System.Numerics;

namespace DopLib
{
    public class Reform
    {
        public static int NumberLetters(string inputText, BigInteger n, int H0)
        {
            var hash = H0;
            char[] TextMas = inputText.ToCharArray();
            for (int i = 0; i < TextMas.Length; i++)
            {
                int DopTransformation = (int)TextMas[i] - 848;
                hash =(int) BigInteger.ModPow(hash + DopTransformation, 2, n);
            }
            return hash;
        }
        public static int FindE(int fi, int d)
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
