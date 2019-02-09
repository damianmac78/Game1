using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Dot
    {
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        private int MaxX { get; set; }
        private int MaxY { get; set; }

        public int PosX { get; set; }
        public int PosY { get; set; }

        public Vector2 Position { get; set; }

        public Texture2D Texture { get; set; }        
        internal string PathToSkin { get; private set; }
        
        public Dot(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
            InitializeRandomPosition();
            InitializeRandomTexture();
        }

        private void InitializeRandomTexture()
        {

            int i = GetRandomNumber(0, 3);
            switch (i)
            {
                case 0:
                    PathToSkin = "Content/blue.png";
                    break;
                case 1:
                    PathToSkin = "Content/green.png";
                    break;
                case 2:
                    PathToSkin = "Content/red.png";
                    break;
                default:
                    PathToSkin = "Content/red.png";
                    break;
            }            
        }

        private void InitializeRandomPosition()
        {
            
            PosX = GetRandomNumber(0, MaxX);
            PosY = GetRandomNumber(0, MaxY);
            Position = new Vector2(PosX, PosY);
        }
        
        public void TrackMouse(MouseState mouseState)
        {
            
            if(mouseState.X > PosX)            
                PosX += 1;            

            if(mouseState.X < PosX)            
                PosX -= 1;            

            if(mouseState.Y > PosY)            
                PosY += 1;

            if (mouseState.Y < PosY)
                PosY -= 1;

            Position = new Vector2(PosX, PosY);
        }

        public void Move(int xPos, int yPos)
        {
            PosX = xPos;
            PosY = yPos;

            if(xPos < 0 || xPos > MaxX)
            {               
                PosX = GetRandomNumber(0, MaxX);
            }
            
            if(yPos < 0 || yPos > MaxY)
            {
               
                PosY = GetRandomNumber(0, MaxY);
            }

            Position = new Vector2(PosX, PosY);
        }

        
    }
}
