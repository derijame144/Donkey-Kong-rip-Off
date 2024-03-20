using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Donkey_Kong_rip_Off
{
    internal class Player
    {
        public int X, Y;
        public int speed = 2;
        public int size = 30;

        public Player(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public void Move(string dirrection)
        {
            Rectangle player = new Rectangle(X, Y + 5, size, 25);

            switch (dirrection)
            {
                case "right":
                    if (X + 35 < GameScreen.width)
                    {
                        X += speed;
                    }
                    else
                    {
                        X = GameScreen.width - 35;
                    }
                    break;
                case "left":
                    if (X > 5)
                    {
                        X -= speed;
                    }
                    else
                    {
                        X = 5;
                    }
                    break;
                case "up":
                    Y -= 1;
                    break;
                case "jump":
                    if (GameScreen.jump == false)
                    {

                        if (GameScreen.aKey)
                        {
                            GameScreen.dirrection = "left";
                            GameScreen.heroSprite = Properties.Resources.L_Jump;
                        }
                        else if (GameScreen.dKey)
                        {
                            GameScreen.dirrection = "right";
                            GameScreen.heroSprite = Properties.Resources.R_Jump;
                        }
                        else
                        {
                            GameScreen.dirrection = "";

                            if (Form1.rWalkSprites.Contains<Image>(GameScreen.heroSprite))
                            {
                                GameScreen.heroSprite = Properties.Resources.R_Jump;
                            }
                            else
                            {
                                GameScreen.heroSprite = Properties.Resources.L_Jump;
                            }
                        }

                        Y -= 3;
                        GameScreen.playerTimer = 0;
                        GameScreen.jump = true;
                    }
                    break;
                case "down":
                    Y += 1;

                    foreach (Rectangle r in GameScreen.floorList)
                    {
                        if (player.IntersectsWith(r))
                        {
                            Y = r.Y - size;
                            GameScreen.heroSprite = Properties.Resources.Climb5;
                            GameScreen.climb = false;
                        }
                    }
                    break;
            }
        }

        public bool Collision(Rectangle r)
        {
            Rectangle player = new Rectangle(X, Y + 29, size, 1);

            if (player.IntersectsWith(r))
            {
                return true;
            }

            return false;


        }
    }
}
