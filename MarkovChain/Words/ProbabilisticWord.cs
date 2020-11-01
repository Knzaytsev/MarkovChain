using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MarkovChain.Words
{
    class ProbabilisticWord : IRandomWord
    {
        private Random rnd = new Random();

        public string GetWord(List<string> words)
        {
            var wordProbabilities = SetWordCount(words);
            var normalizedDict = NormalizeWordCount(wordProbabilities, words.Count);
            return GetMostProbabilisticWord(normalizedDict);
        }

        private Dictionary<string, int> SetWordCount(List<string> words)
        {
            var wordProbabilities = new Dictionary<string, int>();
            foreach (var w in words)
            {
                if (!wordProbabilities.ContainsKey(w))
                {
                    wordProbabilities.Add(w, 1);
                }
                else
                {
                    wordProbabilities[w]++;
                }
            }
            return wordProbabilities;
        }

        private Dictionary<string, double> NormalizeWordCount(Dictionary<string, int> wordProbabilities, int cntWords)
        {
            var normalizedDict = new Dictionary<string, double>();

            foreach (var w in wordProbabilities)
            {
                normalizedDict.Add(w.Key, (double)w.Value / (double)cntWords);
            }

            return normalizedDict;
        }

        private string GetMostProbabilisticWord(Dictionary<string, double> normalizedWords, int cntMaxWords = 5)
        {
            var words = normalizedWords.OrderByDescending(x => x.Value).Take(cntMaxWords).Select(x => x.Key).ToList();
            return words[rnd.Next(0, words.Count)];
        }
    }
}
