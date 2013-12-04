using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Bounce.View
{
    class Camera
    {
        //Variabler för skärmbredd och höjd 
        private int screenWidth;
        private int screenHeight;

        //Variabler för skala (X och Y) för omräkning av
        //logiska kordinater till skärmkordinater
        private float scaleX;
        private float scaleY;

        //Variabler för visuella kordinater för ram och boll
        private float visualBorderSizeX;
        private float visualBorderSizeY;
        private float visualBallSize;

        //Konstruktor som anropar reziseBoard som i sin tur omvandlar logiska 
        //kordinater till skärmkordinater
        internal Camera(Viewport viewPort)
        {
            reziseBoard(viewPort.Width, viewPort.Height);
        }

        //Funktion som returnerar visuella kordinater för de logiska 
        //kordinater som tas som argument
        internal Vector2 getVisualCoordinates(float modelX, float modelY)
        {
            Vector2 view = new Vector2(modelX * scaleX, modelY * scaleY);

            return view;
        }

        //Funktion som omräknar logiska kordinater till visuella kordinater
        internal void reziseBoard(int widthX, int heightY)
        {
            this.screenWidth = widthX;
            this.screenHeight = heightY;

            this.scaleX = (float)screenWidth / XNAController.boardLogicWidth;
            this.scaleY = (float)screenHeight / XNAController.boardLogicHeight;

            this.visualBallSize = (float)screenHeight / (XNAController.boardLogicHeight / XNAController.ballLogicDimention);
            this.visualBorderSizeX = (float)screenWidth / (XNAController.boardLogicWidth / XNAController.boardLogicBorder);
            this.visualBorderSizeY = (float)screenHeight / (XNAController.boardLogicHeight / XNAController.boardLogicBorder);
        }

        //Funktion som skapar en rektangel som är fönsterstorleken minus ramstorleken
        //och adderar drawBorderThiknes till bredd och höd
        internal Rectangle getBackgroundCoordinates(int drawBorderThiknes)
        {
            return new Rectangle(
                                    (int)visualBorderSizeX - drawBorderThiknes,
                                    (int)visualBorderSizeY - drawBorderThiknes,
                                    (int)(screenWidth - (visualBorderSizeX * 2)) + drawBorderThiknes * 2,
                                    (int)(screenHeight - (visualBorderSizeY * 2)) + drawBorderThiknes * 2
                                );
        }

        //Funktion som returnerar X-skalan
        internal int GetScaleX()
        {
            return (int)scaleX;
        }

        //Funktion som returnerar Y-skalan
        internal int GetScaleY()
        {
            return (int)scaleY;
        }
    }
}
