using MarkovChain.Words;
using System;

namespace MarkovChain
{
    class Program
    {
        static void Main(string[] args)
        {
            var pipeline = new PipeLine(new TwoWordsChain(), new FileReader(), new ProbabilisticWord());
            pipeline.ReadText(@"", true);

            do
            {
                for (var i = 0; i < 10; ++i)
                {
                    Console.WriteLine("///");
                    pipeline.MakeChain();
                    Console.WriteLine(pipeline.GetResult());
                }
            } while (Console.ReadLine() != "stop");

        }
    }
}
