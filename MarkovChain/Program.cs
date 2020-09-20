using System;

namespace MarkovChain
{
    class Program
    {
        static void Main(string[] args)
        {
            var pipeline = new PipeLine(new OneWordChain(), new FileReader());
            pipeline.ReadText(@"C:\Users\adugeen\Desktop\Для себя\Цепь Маркова\MarkovChain\124916.txt");
            pipeline.ReadText(@"C:\Users\adugeen\Desktop\Для себя\Цепь Маркова\MarkovChain\test.txt");
            pipeline.ReadText(@"C:\Users\adugeen\Desktop\Для себя\Цепь Маркова\MarkovChain\144733.txt");
            pipeline.ReadText(@"C:\Users\adugeen\Desktop\Для себя\Цепь Маркова\MarkovChain\58197757.txt");

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
