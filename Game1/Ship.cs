using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Ship
    {
        // get and set boundries for position
        private int MaxX { get; set; }
        private int MaxY { get; set; }

        // get and set current position
        public int PosX { get; set; }
        public int PosY { get; set; }

        public Vector2 Position { get; private set; }
         
        public Texture2D Texture { get; set; }
        internal string PathToSkin { get; private set; }

        public Ship(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
            ReCentreCraft();
            PathToSkin = "Content/spaceShip.png";
        }

        private void ReCentreCraft()
        {
            // won't be quite right but close enough 
            PosX = (MaxX / 2);
            PosY = (MaxY / 2);
            Position = new Vector2(PosX, PosY);
        }

        public void TrackMouse(MouseState mouseState)
        {
            
            int mouseX = mouseState.X;
            int PosDiff = (mouseX - PosX);
            // if it is close move toward it slow

            //if it is far away move towards it quicker
            if (mouseState.X > PosX)
            {
                if (PosDiff > 1000)
                    PosX += 4;
                if (PosDiff >= 500 && PosDiff < 1000)
                    PosX += 3;
                if (PosDiff >= 100 && PosDiff < 500)
                    PosX += 2;
                if (PosDiff >= 1 && PosDiff < 100)
                    PosX += 1;
            }

            if (mouseState.X < PosX)
            {
                if (PosDiff < 0 && PosDiff < -100)
                    PosX -= 1;
                if (PosDiff <= -100 && PosDiff < -500)
                    PosX -= 2;
                if (PosDiff <= -500 && PosDiff < -1000)
                    PosX -= 3;
                if (PosDiff < -1000)
                    PosX -= 4;                
            }          
           
            Position = new Vector2(PosX, PosY);
        }
    }
}
