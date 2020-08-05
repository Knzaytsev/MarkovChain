using System;
using System.Collections.Generic;
using System.Text;

namespace MarkovChain
{
    class OneWordChain : IMarkovChain
    {
        private Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
        private string sentence = "";

        public string Sentence { get { return sentence; } }

        public OneWordChain()
        {
            dict.Add("START", new List<string>());
        }

        public void ReadText(string text)
        {
            text = text.Replace(".", " END");
            var sentences = text.Split("END", StringSplitOptions.RemoveEmptyEntries);

            foreach (var s in sentences)
            {
                var temp = s;
                temp += " END";
                var words = temp.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                dict["START"].Add(words[0]);
                for (var i = 1; i < words.Length; ++i)
                {
                    if (!dict.ContainsKey(words[i - 1]))
                    {
                        dict.Add(words[i - 1], new List<string>());
                    };
                    dict[words[i - 1]].Add(words[i]);
                }
            }
        }

        public void MakeChain()
        {
            sentence = "";
            Random rnd = new Random();
            var word = "START";
            do
            {
                var list = dict[word];
                word = list[rnd.Next(0, list.Count)];
                sentence += " " + word;
            } while (word != "END");
            sentence = sentence.Replace(" END", ".");
        }
    }
}
