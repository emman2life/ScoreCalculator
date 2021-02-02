using BowlingCalculatorAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingCalculatorAPI
{
    public interface IGameCalculator
    {
        public void KnockedPins(int pins);
        public DisplayFrame CalculateGame();
        public void Initialize();
    }
}
