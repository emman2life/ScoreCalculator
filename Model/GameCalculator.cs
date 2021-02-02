using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingCalculatorAPI.Model
{
    public class GameCalculator:IGameCalculator
    {
        private const int MAX_FRAME = 10;
        private const int PINS = 10;
        private int position;
        private Frame[] _frameList;

        public GameCalculator()
        {
            Initialize();


        }

        public void KnockedPins(int pins)
        {

            _frameList[position] = Player.ThrowBall(_frameList[position], (Pins)pins);
            int score = _frameList[position].FrameScore;
            if (_frameList[position].Status == FrameStatus.Skrike || _frameList[position].Status == FrameStatus.Open || _frameList[position].Status == FrameStatus.Spare)
            {
                _frameList[position].DisplayPins = -1;
              
                _frameList[position].FrameComputed = true;
                
             
                if (!_frameList[position].TenthFrame)
                position++;
               _frameList[position].FrameScore += score;
                _frameList[position].DisplayPins = PINS;
            }


        }



        public DisplayFrame CalculateGame()
        {
            int RunningTotal = 0;

            for (int i = 0; i < _frameList.Length; i++)
            {

                if(_frameList[i].Status == FrameStatus.Spare)
                {
                    _frameList[i].FrameScore = _frameList[i].FrameResult + GetSpareValueBonus(i);
                    _frameList[i].FrameComputed = true;
                }
                if (_frameList[i].Status == FrameStatus.Open)
                {
                    _frameList[i].FrameScore = _frameList[i].FrameResult;
                }
                if (_frameList[i].Status == FrameStatus.Skrike)
                {
                   
                    if (!_frameList[i].TenthFrame)
                    {
                        if (_frameList[i + 1].Status != FrameStatus.Skrike)
                        {
                            _frameList[i].FrameScore = _frameList[i].FrameResult + _frameList[i + 1].FrameResult;
                           
                        }
                        else
                        {
                            if (!_frameList[i + 1].TenthFrame)
                            {
                                _frameList[i].FrameScore = _frameList[i].FrameResult + _frameList[i + 1].FirstShotScore + _frameList[i + 2].FirstShotScore;
                               
                            }
                            else
                            {
                                _frameList[i].FrameScore = _frameList[i].FrameResult + _frameList[i + 1].FirstShotScore+ _frameList[i + 1].SecondShotScore;
                               
                            }
                            
                        }
                    }
                    else
                    {

                    }
                  

                    
                }
                if (i <= 0)
                {
                    _frameList[i].RunningTotal = _frameList[i].FrameResult;
                }
                else
                {
                    _frameList[i].RunningTotal = _frameList[i-1].RunningTotal + _frameList[i].FrameScore; 
                }
                
            }



            DisplayFrame displayFrame = new DisplayFrame()
            {
                FrameList = _frameList.ToList(),
                PinsLeft = _frameList[position].DisplayPins
            };
            
            return displayFrame;
        }

        public void Initialize()
        {
            position = 0;
            this._frameList = new Frame[MAX_FRAME];
            for (int i = 0; i < _frameList.Length; i++)
            {
                if (i != _frameList.Length - 1)
                {
                    _frameList[i] = new Frame()
                    {
                        Status = FrameStatus.Close,
                        FirstShotScore = -1,
                        SecondShotScore = -1,
                        FrameScore = 0,
                        Position = i + 1,
                        TenthFrame = false,
                        DisplayPins = -1,
                        RunningTotal=0,
                        FrameComputed = false

                    };

                }
                else
                {
                    _frameList[i] = new Frame()
                    {
                        Status = FrameStatus.Close,
                       FirstShotScore = -1,
                        SecondShotScore = -1,
                        ThirdShotScore = -1,
                        FrameScore = 0,
                        Position = i + 1,
                        TenthFrame = true,
                        DisplayPins = -1,
                        RunningTotal=0,
                        FrameComputed = false
                    };
                }
                _frameList[0].DisplayPins = PINS;
            }
        }
        private int GetSpareValueBonus(int framePos)
        {
            int spareBonus = 0;
            // Todo (handle possible exception from array later)
            if (_frameList[framePos + 1].FirstShotScore != -1)
            {
                spareBonus = _frameList[framePos + 1].FirstShotScore;
            }
            
            return spareBonus;
        }
    }
}
