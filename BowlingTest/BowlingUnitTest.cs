using Bowling;
using System.Collections.Generic;
using Xunit;

namespace BowlingTest
{
    public class BowlingUnitTest
    {
        readonly ScoreCalculator scoreCalculator = new ScoreCalculator();

        [Fact]
        public void CalculateCorrectScore()
        {

            var input = new List<int>();

            for (int i = 0; i < 20; i++)
            {
                input.Add(1);
            }

            var result = scoreCalculator.CalculateScore(input);

            Assert.Equal(20, result.Score);

        }


        [Fact]
        public void OutputStrikeCorrectly()
        {

            var input = new List<int>();

            input.Add(10);

            for (int i = 0; i < 20; i++)
            {
                input.Add(1);
            }

            var result = scoreCalculator.CalculateScore(input);

            Assert.Contains("X", result.ResultDisplay);
            Assert.Equal(30, result.Score);

        }


        [Fact]
        public void OutputSpareCorrectly()
        {

            var input = new List<int>();

            input.Add(5);
            input.Add(5);

            for (int i = 0; i < 18; i++)
            {
                input.Add(1);
            }

            var result = scoreCalculator.CalculateScore(input);

            Assert.Contains("/", result.ResultDisplay);
            Assert.Equal(29, result.Score);

        }

        [Fact]
        public void OutputZeroCorrectly()
        {

            var input = new List<int>();

            input.Add(0);
            
            for (int i = 0; i < 19; i++)
            {
                input.Add(1);
            }

            var result = scoreCalculator.CalculateScore(input);

            Assert.Contains("-", result.ResultDisplay);
            Assert.Equal(19, result.Score);

        }


    }
}
