using System;
using System.IO;
using System.Linq;

namespace Bowling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bowling");

            bool pathValid = false;
            string inputFile = null;
            while (!pathValid)
            {
                Console.WriteLine("Enter input file location:");
                inputFile = Console.ReadLine();
                if (File.Exists(inputFile))
                {
                    pathValid = true;
                }
            }
            
            string inputText = File.ReadAllText(inputFile);

            ScoreCalculator scoreCalculator = new ScoreCalculator();

            var input = inputText.Split(',').Select(int.Parse).ToList();

            var result = scoreCalculator.CalculateScore(input);

            Console.WriteLine(result.ResultDisplay);
        }
    }
}
