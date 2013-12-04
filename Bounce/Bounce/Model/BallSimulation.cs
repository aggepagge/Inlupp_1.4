using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bounce.Model
{
    class BallSimulation
    {
        //Hämtar värden för konstanterna för bredd, höjd och ramen (logiska)
        internal float border = XNAController.boardLogicBorder;
        internal float boardLogicWidth = XNAController.boardLogicWidth;
        internal float boardLogicHeight = XNAController.boardLogicHeight;

        //Prop för bollen som modellen hanterar
        internal Ball Ball { get; set; }
         
        //Konstruktor som initsierar bollen med konstanter från XNAController
        internal BallSimulation()
        {
            Ball = new Ball(XNAController.ballLogicSpeedX, XNAController.ballLogicSpeedY, XNAController.ballLogicDimention);
        }

        //Ändrar bollens riktning om den är vid eller passerat ramen
        internal void UpdateBoard(float elapsedGameTime)
        {
            if (Ball.ballPosition.X + Ball.BallDimention >= boardLogicWidth - border)
                Ball.ballSpeed.X = -Ball.ballSpeed.X;

            if (Ball.ballPosition.Y + Ball.BallDimention >= boardLogicHeight - border)
                Ball.ballSpeed.Y = -Ball.ballSpeed.Y;

            if (Ball.ballPosition.X <= border)
                Ball.ballSpeed.X = -Ball.ballSpeed.X;

            if (Ball.ballPosition.Y <= border)
                Ball.ballSpeed.Y = -Ball.ballSpeed.Y;

            Ball.ballPosition.X += elapsedGameTime * Ball.ballSpeed.X;
            Ball.ballPosition.Y += elapsedGameTime * Ball.ballSpeed.Y;
        }
    }
}

//if (Ball.ballPosition.X + Ball.BallDimention >= boardLogicWidth - border)
//{
//    Ball.ballSpeed.X = -Ball.ballSpeed.X;
//    //Ball.ballPosition.X = (boardLogicWidth - border) - Ball.BallDimention;
//}

//if (Ball.ballPosition.Y + Ball.BallDimention >= boardLogicHeight - border)
//{
//    Ball.ballSpeed.Y = -Ball.ballSpeed.Y;
//    //Ball.ballPosition.Y = (boardLogicHeight - border) - Ball.BallDimention;
//}

//if (Ball.ballPosition.X <= border)
//{
//    Ball.ballSpeed.X = -Ball.ballSpeed.X;
//    //Ball.ballPosition.X = border;
//}

//if (Ball.ballPosition.Y <= border)
//{
//    Ball.ballSpeed.Y = -Ball.ballSpeed.Y;
//    //Ball.ballPosition.Y = border;
//}
