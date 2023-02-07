using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnutMorrisPratt
{
    internal class KMP
    {
        public int SearchSlow(string substring, string text)
        {
            int[] pi = new int[substring.Length + 1];
            for (int q = 0; q <= substring.Length; q++)
            {
                string line = substring.Left(q);
                for (int len = 0; len < q; len++)
                    if (line.Left(len) == line.Right(len))
                        pi[q] = len;
            }

            return Search(substring, text, pi);
        }

        public int SearchFast(string substring, string text)
        {
            int[] pi = new int[substring.Length + 1];
            pi[1] = 0;
            for (int q = 1; q < substring.Length; q++)
            {
                int len = pi[q];

                while (len > 0 && substring[len] != substring[q])
                    len = pi[len];

                if (substring[len] == substring[q])
                    len++;
                pi[q + 1] = len;
            }

            return Search(substring, text, pi);
        }

        int Search(string substring, string text, int[] pi)
        {
            int j = 0;
            for (int i = 0; i < text.Length; i++)
            {
                while (j > 0 && text[i] != substring[j])
                    j = pi[j - 1];

                if (text[i] == substring[j])
                    j++;

                if (j == substring.Length)
                    return i - substring.Length + 1;
            }
            return -1;
        }
    }
}
