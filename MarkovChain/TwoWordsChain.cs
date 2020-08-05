using System;
using System.Collections.Generic;
using System.Text;

namespace MarkovChain
{
    class TwoWordsChain : IMarkovChain
    {
        private Dictionary<(string, string), List<string>> dict = 
            new Dictionary<(string, string), List<string>>();
        private string sentence = "";
        public string Sentence { get { return sentence; } }

        public void ReadText(string text)
        {
            text = text.Replace(".", " END");
            var sentences = text.Split("END", StringSplitOptions.RemoveEmptyEntries);

            foreach (var s in sentences)
            {
                var temp = "START " + s;
                temp += "END";
                var words = temp.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (var i = 1; i < words.Length - 1; ++i)
                {
                    if (!dict.ContainsKey((words[i - 1], words[i])))
                    {
                        dict.Add((words[i - 1], words[i]), new List<string>());
                    }
                    dict[(words[i - 1], words[i])].Add(words[i + 1]);
                }
            }
        }

        public void MakeChain()
        {
            Random rnd = new Random();
            var words = GetWords(dict, "START");
            sentence = words.Item2;
            do
            {
                var word = dict[words][rnd.Next(0, dict[words].Count)];
                words.Item1 = words.Item2;
                words.Item2 = word;
                sentence += " " + words.Item2;
            } while (words.Item2 != "END");
            sentence = sentence.Replace(" END", ".");
        }

        private (string, string) GetWords(Dictionary<(string, string), List<string>> dict,
           string startWord)
        {
            var starts = new SortedSet<(string, string)>();
            foreach (var s in dict.Keys)
            {
                if (s.Item1 == startWord)
                {
                    starts.Add(s);
                }
            }

            Random rnd = new Random();
            var i = 0;
            var end = rnd.Next(0, starts.Count);
            var start = ("", "");
            foreach (var s in starts)
            {
                start = s;
                if (i == end)
                    break;
                ++i;
            }
            return start;
        }
    }
}
