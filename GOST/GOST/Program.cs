using System;

namespace GOST
{
    class Program
    {
        static void Main()
        {
            string inputText = "ШМОНИН А";
            string key = "КРОВ";
            int[,] BlockSubstitution = {{4,14,5,7,6,4,13,1},
                                         {10,11,8,13,12,11,11,15},
                                         {9,4,1,10,7,10,4,13},
                                         {2,12,13,1,1,0,1,0},
                                         {13,6, 10,0,5,7,3,5},
                                         {8,13,3,8,15,2,15,7},
                                         {0,15,4,9,13,1,5,10},
                                         {14,10,2,15,8,13,9,4},
                                         {6,2,14,14,4,3,0,9},
                                         {11,3,15,4,10,6,10,2},
                                         {1,8,12,6,9,8,14,3},
                                         {12,1,7,12,14,5,7,14},
                                         {7,0,6,11,0,9,6,6},
                                         {15,7,0,2,3,12,8,11},
                                         {5,5,9,5,11,15,2,8},
                                         {3,9,11,3,2,14,12,12}};
            string BitInputText = Bit(inputText);
            string X0 = Bit(key);
            string L0 = BitInputText.Substring(0, 32);
            string R0 = BitInputText.Substring(32, 32);
            string R0X0 = SumModulThirdTwo(R0, X0);
            string Swap = BlockSwap(R0X0, BlockSubstitution);
            string Shift = Swap.Substring(11, 21) + Swap.Substring(0, 11);
            string ShiftL0 = SumModulTwo(Shift, L0);
            Console.WriteLine("Входной тескт битов:"+BitInputText);
            Console.WriteLine("Входной ключ битов:"+X0);
            Console.WriteLine("Сложение 2 в 32:"+R0X0);
            Console.WriteLine("Перемещение битов:"+Swap);
            Console.WriteLine("Сдвиг:"+Shift);
            Console.WriteLine("Cложене по модулю 2:"+ShiftL0);
            Console.ReadKey();
        }
            private static string Bit(string Text)
            {
                char[] mas = Text.ToCharArray();
                string result = "";
                string tmp = "";
                byte[] masnumber = new byte[Text.Length];
                for (int i = 0; i < mas.Length; i++)
                {
                    int number = (int)mas[i];
                    if (number >= 1040 && number <= 1103)
                    {
                        int newnumber = number - 848;
                        masnumber[i] = (byte)newnumber;
                    }
                    else
                    {
                        masnumber[i] = (byte)number;

                    }
                    tmp = Convert.ToString(masnumber[i], 2);
                    if (tmp.Length < 8)
                    {
                        for (; tmp.Length < 8;)
                        {
                            tmp = "0" + tmp;
                        }
                    }
                    result += tmp;
                }
                return result;
            }
            private static string SumModulTwo(string a,string b)
        {
            string result = "";
            for(int i=0;i<32;i++)
            {
                long a1 = Convert.ToInt64(a[i]);
                long b1 = Convert.ToInt64(b[i]);
                long mod = (a1 + b1) % 2;
                result+= mod;
            }
            return result;
        }
        private static string SumModulThirdTwo(string a,string b)
        {
            string result = "";
            int bitlength = 32;
            long a1=Convert.ToInt64(a,2);
            long b1 = Convert.ToInt64(b, 2);
            long sum = a1 + b1;
            result = Convert.ToString(sum, 2);
            string finish = result.Substring(result.Length - bitlength, bitlength);
            return finish;
        }
        private static string BlockSwap(string R0X0,int[,] BlockSubstitution)
        {
            string result = "";
            int length = 0;
            for(int j = 7; j >= 0; j--)
            {
                int i = Convert.ToInt32(R0X0.Substring(length, 4), 2);
                var dop = Convert.ToString(BlockSubstitution[i, j], 2);
                for (; dop.Length < 4;)
                {
                    dop = "0" + dop;
                }
                result += dop;
                length += 4;
            }
            return result;
        }
    }
}
