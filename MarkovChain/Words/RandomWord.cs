using System;
using System.Collections.Generic;
using System.Text;

namespace MarkovChain.Words
{
    class RandomWord : IRandomWord
    {
        private Random rnd = new Random();

        public string GetWord(List<string> words)
        {
            return words[rnd.Next(0, words.Count)];
        }
    }
}
