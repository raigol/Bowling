using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("BowlingTest")]

namespace Bowling
{
    internal class ScoreCalculator
    {        
        List<int> Rolls = new List<int>();
        int FrameIndex = 0;

        public ResultSummary CalculateScore(List<int> bowlingRolls)
        {
            int score = 0;
            Rolls = bowlingRolls;
            List<string> frameTitle = new List<string>();
            List<string> frameResult = new List<string>();

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike())
                {
                    const int strikeSum = 10;
                    score += strikeSum + StrikeBonus();
                    frameResult.Add("X   ");
                    FrameIndex++;
                }
                else if (IsSpare())
                {
                    const int spareSum = 10;
                    score += spareSum + SpareBonus();
                    Tuple<int, int> ballsInFrame = BallsInFrame();

                    frameResult.Add($"{RollScoreDisplay(ballsInFrame.Item1)}, /");

                    FrameIndex += 2;
                }
                else
                {
                    Tuple<int, int> ballsInFrame = BallsInFrame();
                    score += ballsInFrame.Item1 + ballsInFrame.Item2;
                    
                    frameResult.Add($"{RollScoreDisplay(ballsInFrame.Item1)}, {RollScoreDisplay(ballsInFrame.Item2)}");

                    FrameIndex += 2;
                }

                frameTitle.Add($" f{frame + 1} ");
            }

            string titleLine = string.Join("|", frameTitle);
            string resultLine = string.Join("|", frameResult);
            string result = $"|{titleLine}| " + Environment.NewLine + 
                            $"|{resultLine}| " + Environment.NewLine +
                            $"score: {score}";

            ResultSummary resultSummary = new ResultSummary
            {
                Score = score,
                ResultDisplay = result
            };

            return resultSummary;
        }


        private string RollScoreDisplay(int value)
        {
            if (value == 0)
            {
                return "-";
            } else
            {
                return value.ToString();
            }            
        }

        private Tuple<int, int> BallsInFrame()
        {          
            return new Tuple<int, int>(Rolls[FrameIndex], Rolls[FrameIndex + 1]);             
        }


        private int SpareBonus()
        {
            return Rolls[FrameIndex + 2];
        }

        private int StrikeBonus()
        {
            return Rolls[FrameIndex + 1] + Rolls[FrameIndex + 2];
        }

        private bool IsStrike()
        {
            return Rolls[FrameIndex] == 10;
        }

        private bool IsSpare()
        {
            return Rolls[FrameIndex] + Rolls[FrameIndex + 1] == 10;
        }

    }

    
}
