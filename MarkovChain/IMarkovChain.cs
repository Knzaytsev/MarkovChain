using System;
using System.Collections.Generic;
using System.Text;

namespace MarkovChain
{
    interface IMarkovChain
    {
        void MakeChain();

        void ReadText(string text);

        string Sentence { get;}
    }
}
