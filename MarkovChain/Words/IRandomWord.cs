using System;
using System.Collections.Generic;
using System.Text;

namespace MarkovChain
{
    interface IRandomWord
    {
        public string GetWord(List<string> words);
    }
}
