using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bounce.Model;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Bounce.View
{
    class BallView
    {
        //Variabler för referens till ballSimulation (Model), Camera (Som skapas i XNAController och GraphicsDevice
        internal BallSimulation m_ballSimulation;
        internal Camera camera;
        internal GraphicsDevice graphDevice;

        //Variabler för utritning av ramen
        private Texture2D borderBarierInner;
        private Texture2D borderBarier;
        private Rectangle borderLineInner;
        private Rectangle borderLine;

        //Variabler för den yttre panelern och den inre panelen som 
        //tillsammans blir ramen (En lite större svart ram och en lite mindre
        //vit inre ram). drawBorderWidth och drawBorderMargin extra bredd på 
        //de båda panelerna
        private int drawBorderWidth = 6;
        private int drawBorderMargin = 2;

        //Variabel för boll-texturen
        internal Texture2D ballTexture;

        //Konstruktor som tar en referens till GraphicsDevice, ballSimulation, ContentManager och Camera.
        internal BallView(GraphicsDevice graphDevice, BallSimulation ballSimulation, ContentManager contentManager, Camera camera)
        {
            this.m_ballSimulation = ballSimulation;
            this.camera = camera;
            this.graphDevice = graphDevice;
            LoadContent(contentManager);
        }

        //Laddar bolltexturen
        internal void LoadContent(ContentManager contentManager)
        {
            ballTexture = contentManager.Load<Texture2D>("ball3");
            fillBorder();
        }

        //Skapar de båda panelerna som bildar ramen (Behövs bara göras en gång, men eftersom 
        //jag skapat möjlighet att ändra storlek på spelplanen med ctrl + f (för helskärm)
        //eller ctrl + c (för mindre spelplan) så anropas denna funktion från XNAController'n, 
        //vilket kanske borde göras via Camera-klassen istället
        internal void fillBorder()
        {
            borderBarier = new Texture2D(graphDevice, 1, 1, false, SurfaceFormat.Color);
            borderBarier.SetData(new[] { Color.White });

            borderBarierInner = new Texture2D(graphDevice, 1, 1, false, SurfaceFormat.Color);
            borderBarierInner.SetData(new[] { Color.White });

            borderLine = camera.getBackgroundCoordinates(drawBorderWidth);
            borderLineInner = camera.getBackgroundCoordinates(drawBorderMargin);
        }

        //Metod som ritar ut ramen och bollen
        internal void Draw(float elapsedGameTime, SpriteBatch spriteBatch)
        {
            graphDevice.Clear(Color.White);

            Vector2 ballViewCenter = camera.getVisualCoordinates(m_ballSimulation.Ball.ballPosition.X, m_ballSimulation.Ball.ballPosition.Y);

            int ballViewX = (int)(m_ballSimulation.Ball.BallDimention * camera.GetScaleX());
            int ballViewY = (int)(m_ballSimulation.Ball.BallDimention * camera.GetScaleY());

            Rectangle ballDestinationRectangle = new Rectangle((int)ballViewCenter.X, (int)ballViewCenter.Y, ballViewX, ballViewY);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            spriteBatch.Draw(ballTexture, ballDestinationRectangle, Color.White);
            spriteBatch.Draw(borderBarierInner, borderLineInner, Color.White);
            spriteBatch.Draw(borderBarier, borderLine, Color.Black);

            spriteBatch.End();
        }
    }
}
