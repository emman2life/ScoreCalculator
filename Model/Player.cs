using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingCalculatorAPI.Model
{
    public static class Player
    {
        private const int MAX_SCORE = 10;
        public static Frame ThrowBall(Frame frame, Pins pins)
        {

            switch (pins)
            {
                case Pins.zero:

                    return UpdateScore(frame, Pins.zero);
                case Pins.one:

                    return UpdateScore(frame, Pins.one);

                case Pins.two:
                    return UpdateScore(frame, Pins.two);

                case Pins.three:
                    return UpdateScore(frame, Pins.three);

                case Pins.four:
                    return UpdateScore(frame, Pins.four);

                case Pins.five:
                    return UpdateScore(frame, Pins.five);

                case Pins.six:
                    return UpdateScore(frame, Pins.six);

                case Pins.seven:
                    return UpdateScore(frame, Pins.seven);

                case Pins.eight:
                    return UpdateScore(frame, Pins.eight);

                case Pins.nine:
                    return UpdateScore(frame, Pins.nine);


                case Pins.ten:
                    if (!frame.TenthFrame)
                    {


                        if (frame.Shots <= 0)
                        {
                            frame.Status = FrameStatus.Skrike;
                            //frame.FrameScore = (int)Pins.ten;
                            // frame.FrameScore += MAX_SCORE;
                            
                            frame.FirstShotScore = MAX_SCORE;
                            frame.FrameResult = MAX_SCORE;
                            
                        }
                        else
                        {
                            frame.Status = FrameStatus.Spare;

                            //frame.FrameScore += MAX_SCORE;
                            frame.SecondShotScore = MAX_SCORE;
                            frame.FrameResult = MAX_SCORE;

                        }


                    }
                    else
                    {
                        switch (frame.Shots)
                        {
                            case 0:
                                frame.Status = FrameStatus.Skrike;

                                frame.FirstShotScore = MAX_SCORE;
                                frame.FrameResult += MAX_SCORE;
                                frame.Shots++;
                                break;
                            case 1:
                                if(frame.Status== FrameStatus.Skrike)
                                {
                                    frame.Status = FrameStatus.Skrike;
                                    frame.SecondShotScore = MAX_SCORE;
                                    frame.FrameResult += MAX_SCORE;
                                    frame.Shots++;
                                }else
                                {
                                    frame.Status = FrameStatus.Spare;
                                }
                                break;
                            case 2:
                                if (frame.Status == FrameStatus.Skrike)
                                {
                                    frame.Status = FrameStatus.Skrike;
                                    frame.ThirdShotScore = MAX_SCORE;
                                    frame.FrameResult += MAX_SCORE;
                                    
                                }
                                break;

                        }
                       

                    }

                    break;

            }
            return frame;

        }
        private static Frame UpdateScore(Frame frame, Pins pins)
        {
            if (!frame.TenthFrame)
            {
                if (frame.Shots <= 0)
                {
                    //for first shot
                    frame.FirstShotScore = (int)pins;
                    frame.DisplayPins = MAX_SCORE - (int)pins;
                    frame.Shots++;
                }
                else if (frame.FirstShotScore + (int)pins == MAX_SCORE)
                {
                    //for spare
                    frame.Status = FrameStatus.Spare;
                    //frame.FrameScore += MAX_SCORE;
                    frame.SecondShotScore = (int)pins;
                    frame.FrameResult = MAX_SCORE;
                    frame.Shots++;

                }
                else
                {
                    frame.Status = FrameStatus.Open;
                    frame.SecondShotScore = (int)pins;
                    //frame.FrameScore += frame.SecondShotScore + frame.FirstShotScore;
                    frame.FrameResult = frame.SecondShotScore + frame.FirstShotScore;
                    frame.Shots++;
                }
            }else
            {
                switch (frame.Shots)
                {
                    case -1:
                        frame.SecondShotScore = (int)pins;
                        frame.DisplayPins = MAX_SCORE - (int)pins;
                        frame.FrameResult += (int)pins;
                        frame.Shots = -1;
                        break;
                    case 0:
                        frame.FirstShotScore = (int)pins;
                        frame.DisplayPins = MAX_SCORE - (int)pins;
                        frame.FrameResult += (int)pins;
                        frame.Shots=-1;
                        break;
                    case 1:
                        if (frame.FirstShotScore + (int)pins == MAX_SCORE)
                        {

                            frame.Status = FrameStatus.Spare;
                            frame.SecondShotScore = (int)pins;
                            frame.FrameResult = MAX_SCORE;
                            frame.Shots++;

                        }
                        else
                        {
                            frame.Status = FrameStatus.Open;
                            frame.SecondShotScore = (int)pins;
                            //frame.FrameScore += frame.SecondShotScore + frame.FirstShotScore;
                            frame.FrameResult = frame.SecondShotScore + frame.FirstShotScore;
                            frame.Shots++;
                        }
                        break;
                    case 2:
                        if (frame.SecondShotScore + (int)pins == MAX_SCORE)
                        {

                            frame.Status = FrameStatus.Spare;
                            frame.ThirdShotScore = (int)pins;
                            frame.FrameResult = MAX_SCORE;
                            frame.Shots++;

                        }
                        else
                        {
                            frame.Status = FrameStatus.Open;
                            frame.ThirdShotScore = (int)pins;
                            //frame.FrameScore += frame.SecondShotScore + frame.FirstShotScore;
                            frame.FrameResult = frame.ThirdShotScore + frame.FirstShotScore + frame.SecondShotScore;
                            frame.Shots++;
                        }
                        break;
                }
               
              
            }
            return frame;
        }
    }
}
