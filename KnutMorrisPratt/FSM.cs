using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnutMorrisPratt
{
    internal class FSM
    {
        char[] alphabet;
        public FSM()
        {
            alphabet = new char[UInt16.MaxValue];
            for (UInt16 c = 0; c < alphabet.Length; c++)
                alphabet[c] = (char)c;
        }
        int[,] CreateDelta(string substring)
        {
            int[,] delta = new int[substring.Length, alphabet.Length];

            for (UInt16 q = 0; q < substring.Length; q++)
            {
                foreach (char c in alphabet)
                {
                    string line = substring.Left(q) + c;
                    int k = q + 1;
                    while(substring.Left(k) != line.Right(k))
                        k--;
                    delta[q, c] = k;
                }
            }
            return delta;
        }
        public int Search(string substring, string text)
        {
            var delta = CreateDelta(substring);
            int q = 0;
            for(int i = 0; i < text.Length; i++)
            {
                q = delta[q, text[i]];
                if (q == substring.Length)
                    return i - substring.Length + 1;
            }
            return -1;
        }
    }
}
