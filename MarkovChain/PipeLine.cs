using System;
using System.Collections.Generic;
using System.Text;

namespace MarkovChain
{
    class PipeLine
    {
        private string text = "";
        public IMarkovChain MarkovChain { get; set; }
        public IReader Reader { get; set; }

        public PipeLine(IMarkovChain markovChain, IReader reader)
        {
            MarkovChain = markovChain;
            Reader = reader;
        }

        public void ReadText(string text, bool isLower = false)
        {
            text = Reader.ReadText(text, isLower);
            MarkovChain.ReadText(text);
        }

        public void MakeChain()
        {
            MarkovChain.MakeChain();
        }

        public string GetResult()
        {
            return MarkovChain.Sentence;
        }
    }
}
