using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donkey_Kong_rip_Off
{
    internal class Barrel
    {
        public Rectangle rectangle;
        public int speed = -3;
        public int size = 25;
        public int spriteNumber = 0;

        public Image currentSprite;

        public bool ladder;
        public bool touchingLadder = false;
        public Barrel()
        {
            rectangle = new Rectangle(267, 123, size, size);
            
        }

        public void Roll()
        {
            rectangle.X += speed;

            if (rectangle.X < 0 || rectangle.X > GameScreen.width - size)
            {
                if (rectangle.Y < 552)
                {
                    speed *= -1;
                }
            }

            currentSprite = Form1.rolling[spriteNumber];

            if (speed > 0)
            {
                spriteNumber++;
            }
            else
            {
                spriteNumber--;
            }

            if (spriteNumber < 0) 
            {
                spriteNumber = 15;
            }

            if (spriteNumber > 15)
            {
                spriteNumber = 0;
            }

        }

        public void Ladder()
        {
            
            foreach (Rectangle r in GameScreen.ladderList)
            {
                if (rectangle.IntersectsWith(r))
                {
                    rectangle.Y += 3;
                    rectangle.X = r.X + 3;

                    if (rectangle.Y + 25 > r.Y + r.Height)
                    {
                        ladder = false;
                        speed *= -1;
                    }
                }
            }

            currentSprite = Form1.rollingLadder[spriteNumber];

            spriteNumber++;

            if (spriteNumber > 6)
            {
                spriteNumber = 0;
            }
        }

        public void Gravity()
        {
            

            foreach (Rectangle r in GameScreen.floorList)
            {
                GameScreen.onGroundB.Clear();

                if (r.IntersectsWith(rectangle))
                {
                    GameScreen.onGroundB.Add(true);
                    rectangle.Y = r.Y - size;
                }
                else
                {
                    GameScreen.onGroundB.Add(false);
                }

            }

            if (GameScreen.onGroundB.Contains<bool>(true) == false)
            {
                rectangle.Y += 5;
            }

        }

    }
}
