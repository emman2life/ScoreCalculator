using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingCalculatorAPI.Model
{
    public class Frame
    {
        public int Position { get; set; }
        public int FirstShotScore { get; set; }
        public int SecondShotScore { get; set; }
        public int ThirdShotScore { get; set; }
        public int FrameResult { get; set; }
        public int FrameScore { get; set; }
        public int RunningTotal { get; set; }
        public bool TenthFrame { get; set; }
        public bool FrameComputed { get; set; }
        public int DisplayPins { get; set; }
        public int Shots { get; set; }
        public FrameStatus Status { get; set; }
    }
    public enum FrameStatus
    {
        Close, Open, Skrike, Spare

    }
    public enum Pins
    {
        zero = 0, one = 1, two = 2, three = 3, four = 4, five = 5, six = 6, seven = 7, eight = 8, nine = 9, ten = 10
    }
}
