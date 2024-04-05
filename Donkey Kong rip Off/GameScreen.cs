using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Donkey_Kong_rip_Off
{
    public partial class GameScreen : UserControl
    {

        Random rng = new Random();

        public static Rectangle end = new Rectangle(-10, 552, 50, 30);

        Rectangle winHitBox = new Rectangle(159, 56, 30, 30);

        public static int playerTimer;
        public static int barrelTimer = 35;
        public static int width;
        public static int height;

        int nextFloorX;
        int nextFloorY;
        int hammerTimer = 0;

        public static string dirrection;

        public static bool aKey, dKey, wKey, sKey, spaceKey;
        public static bool facerRight = true;
        public static bool climb, jump = false;

        bool spawnBarrel = false;
        bool died = false;
        bool hammer = false;
        bool hammerTaken = false;


        public static List<Rectangle> floorList = new List<Rectangle>();
        public static List<Rectangle> ladderList = new List<Rectangle>();
        public static List<Rectangle> ladderHitBox = new List<Rectangle>();
        public static List<bool> onGround = new List<bool>();
        public static List<bool> onGroundB = new List<bool>();
        List<Barrel> barrels = new List<Barrel>();


        public static Image heroSprite = Properties.Resources.R_Idle;
        public static Image dkSprite = Properties.Resources.D_Idle1;

        Player hero;

        Animation rWalk;
        Animation lWalk;
        Animation lhIdle;
        Animation rhIdle;
        Animation climbing1;
        Animation climbing2;
        Animation dkIdle;
        Animation Throw;
        Animation death;


        Brush redBrush = new SolidBrush(Color.Red);
        Brush blueBrush = new SolidBrush(Color.Blue);
        Brush whiteBrush = new SolidBrush(Color.White);

        Rectangle dk = new Rectangle(339, 83, 70, 70);
        Rectangle barrelStack = new Rectangle(409, 83, 40, 70);
        Rectangle hammerRec = new Rectangle(58, 320, 15, 35);

        public GameScreen()
        {
            InitializeComponent();

            gameTimer.Start();

            barrels.Clear();
            ladderList.Clear();
            floorList.Clear();

            died = false;

            heroSprite = Properties.Resources.R_Idle;

            hero = new Player(10, this.Height - 44);
            rWalk = new Animation(Form1.rWalkSprites);
            lWalk = new Animation(Form1.lWalkSprites);
            climbing1 = new Animation(Form1.climb1Sprites);
            climbing2 = new Animation(Form1.climb2Sprites);
            dkIdle = new Animation(Form1.dkIdle);
            Throw = new Animation(Form1.barrelThrow);
            death = new Animation(Form1.death);
            lhIdle = new Animation(Form1.lhIDLE);
            rhIdle = new Animation(Form1.rhIDLE);

            width = this.Width;
            height = this.Height;


            ladderList.Add(new Rectangle(350, 500, 30, 66));
            ladderList.Add(new Rectangle(82, 395, 30, 66));
            ladderList.Add(new Rectangle(224, 380, 30, 110));
            ladderList.Add(new Rectangle(351, 294, 30, 66));
            ladderList.Add(new Rectangle(267, 275, 30, 90));
            ladderList.Add(new Rectangle(83, 185, 30, 66));
            ladderList.Add(new Rectangle(159, 100, 30, 66));

            foreach (Rectangle r in ladderList)
            {
                ladderHitBox.Add(new Rectangle(r.X + 7, r.Y - 35, 10, 30));
            }

            floorList.Add(new Rectangle(0, this.Height - 15, 220, 15));
            floorList.Add(new Rectangle(129, 85, 175, 15));

            nextFloorX = 220;
            nextFloorY = height - 20;

            buildFloor("right", 6);

            nextFloorX = 360;
            nextFloorY = 495;

            buildFloor("left", 10);

            nextFloorX = 60;
            nextFloorY -= 56;

            buildFloor("right", 10);

            nextFloorX = width - 100;
            nextFloorY -= 56;

            buildFloor("left", 10);

            nextFloorX = 60;
            nextFloorY -= 56;

            buildFloor("right", 5);

            floorList.Add(new Rectangle(nextFloorX, nextFloorY, 220, 15));


        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (died == false)
            {
                #region movement 

                if (spaceKey && onGround.Contains<bool>(true) && climb == false)
                {
                    hero.Move("jump");
                }

                if (jump == false && climb == false)
                {
                    if (aKey)
                    {
                        hero.Move("left");
                        lWalk.Play();
                        heroSprite = lWalk.currentsprite;
                    }

                    if (dKey)
                    {
                        hero.Move("right");
                        rWalk.Play();
                        heroSprite = rWalk.currentsprite;
                    }
                }


                if (sKey && climb)
                {
                    hero.Move("down");
                    climbing1.Play();
                    heroSprite = climbing1.currentsprite;
                }
                #endregion

                #region floor and ladder code
                foreach (Rectangle r in floorList)
                {
                    if (hero.Collision(r, "f") && climb == false)
                    {
                        hero.Y = r.Y - 29;
                        jump = false;
                    }
                }

                foreach (Rectangle r in ladderList)
                {
                    if (hero.Collision(r, "l") && wKey == true && jump == false && hammer == false)
                    {
                        if (climb == false)
                        {
                            hero.Y -= 5;
                            hero.X = r.X;
                        }

                        climb = true;
                    }

                    if (hero.X == r.X && hero.Y + hero.size <= r.Y && climb)
                    {
                        climb = false;
                        GameScreen.heroSprite = Properties.Resources.Climb5;

                    }
                }

                if (wKey && jump == false && climb)
                {
                    hero.Move("up");

                    foreach (Rectangle r in ladderList)
                    {
                        if (hero.Collision(r, "l"))
                        {
                            if (hero.Y < r.Y - 20)
                            {
                                climbing2.Play();
                                heroSprite = climbing2.currentsprite;
                            }
                            else
                            {
                                climbing1.Play();
                                heroSprite = climbing1.currentsprite;
                            }
                        }
                    }
                }
                #endregion

                #region Jump code
                if (jump == true)
                {
                    playerTimer++;

                    if (playerTimer < 20)
                    {
                        hero.Y -= 2;
                    }
                    else
                    {
                        gravity();
                    }

                    if (dirrection == "right")
                    {
                        hero.X += hero.speed;

                        if (hero.X + 35 > width)
                        {
                            hero.X = width - 35;
                        }
                    }
                    else if (dirrection == "left")
                    {
                        hero.X -= hero.speed;

                        if (hero.X < 5)
                        {
                            hero.X = 5;
                        }
                    }

                }
                #endregion

                if (jump == false && climb == false)
                {
                    gravity();
                }

                #region hammer code
                if (hero.Collision(hammerRec, "h") && hammerTaken == false)
                {
                    hammer = true;
                    hammerTaken = true;
                    hammerTimer = 0;
                }

                if (hammer)
                {
                    if (facerRight)
                    {
                        rhIdle.Play();
                        heroSprite = rhIdle.currentsprite;
                    }
                    else
                    {
                        lhIdle.Play();
                        heroSprite = lhIdle.currentsprite;
                    }
                }

                if (hammerTimer == 400)
                {
                    hammer = false;
                    hammerTimer = 0;
                    
                    if (facerRight)
                    {
                        heroSprite = Properties.Resources.R_Idle;
                    }
                    else
                    {
                        heroSprite = Properties.Resources.L_Idle;
                    }
                }

                #endregion

                dkIdle.Play();
                dkSprite = dkIdle.currentsprite;

                #region barrel code

                #region spawn barrel
                if (barrelTimer == 75 || spawnBarrel)
                {
                    if (spawnBarrel == false)
                    {
                        barrelTimer = 0;
                    }

                    spawnBarrel = true;
                    Throw.Play();
                    dkSprite = Throw.currentsprite;

                    if (barrelTimer == 27 && spawnBarrel)
                    {
                        Throw.spriteNumber = 0;
                        spawnBarrel = false;
                        barrels.Add(new Barrel());
                        barrelTimer = 0;
                    }
                }
                #endregion

                foreach (Barrel b in barrels)
                {
                    if (hero.Collision(b.rectangle, "b") && hammer == false)
                    {
                        died = true;
                        barrelTimer = 0;
                    }
                    else if (hero.Collision(b.rectangle, "b"))
                    {
                        barrels.Remove(b);
                        break;
                    }

                    #region barrel goes down ladder
                    foreach (Rectangle r in ladderHitBox)
                    {


                        if (b.rectangle.IntersectsWith(r) && rng.Next(1, 9) == 1 && b.touchingLadder == false)
                        {
                            b.ladder = true;
                            b.rectangle.Y += 15;
                            b.spriteNumber = 0;
                        }


                    }

                    foreach (Rectangle r in ladderHitBox)
                    {
                        if (b.rectangle.IntersectsWith(r))
                        {
                            b.touchingLadder = true;
                            break;
                        }
                        else
                        {
                            b.touchingLadder = false;
                        }
                    }
                    #endregion

                    if (b.ladder)
                    {
                        b.Ladder();
                    }
                    else
                    {
                        b.Roll();
                        b.Gravity();
                    }

                }

                #endregion
            }

            if (died)
            {
                if (barrelTimer < 27)
                {
                    death.Play();
                    heroSprite = death.currentsprite;
                }
                else if (barrelTimer < 37)
                {
                    heroSprite = Properties.Resources.Death5;
                }
                else
                {
                    gameTimer.Stop();
                    Form1.ChangeScreen(this, new GanmeOverScreen());
                }
            }


            barrelTimer++;

            if (hammer)
            {
                hammerTimer++;
            }

            Refresh();
        }

        public void gravity()
        {
            onGround.Clear();

            foreach (Rectangle r in floorList)
            {
                if (hero.Collision(r, "r") == true)
                {
                    onGround.Add(true);

                }
                else
                {
                    onGround.Add(false);
                }
            }

            if (onGround.Contains<bool>(true) == false)
            {
                hero.Y += 2;

            }



        }

        private void GameScreen_KeyUp_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    spaceKey = false;
                    break;
                case Keys.W:
                    wKey = false;
                    break;
                case Keys.S:
                    sKey = false;
                    break;
                case Keys.D:
                    dKey = false;
                    break;
                case Keys.A:
                    aKey = false;
                    break;
            }
        }

        private void GameScreen_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    spaceKey = true;
                    break;
                case Keys.W:
                    wKey = true;
                    break;
                case Keys.S:
                    sKey = true;
                    break;
                case Keys.D:
                    dKey = true;
                    break;
                case Keys.A:
                    aKey = true;
                    break;
            }
        }

        private void buildFloor(string way, int length)
        {

            for (int i = 0; i < length; i++)
            {
                floorList.Add(new Rectangle(nextFloorX, nextFloorY, 40, 15));
                if (way == "left")
                {
                    nextFloorX -= 40;
                }
                else
                {
                    nextFloorX += 40;
                }
                nextFloorY -= 5;
            }
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {

            testLabel.Text = $"X: {hero.X}\nY: {hero.Y} \nClimb: {climb}\nJump: {jump}\nTimer: {barrelTimer} \nSpawnBarrel: {spawnBarrel}";

            foreach (Rectangle r in ladderList)
            {
                e.Graphics.FillRectangle(blueBrush, r);
            }


            if (hammerTaken == false)
            {
                e.Graphics.DrawImage(Properties.Resources.Hammer, hammerRec);

            }


            foreach (Barrel b in barrels)
            {
                e.Graphics.DrawImage(b.currentSprite, b.rectangle.X, b.rectangle.Y - 5, b.size + 5, b.size + 5);
                e.Graphics.DrawRectangle(new Pen(Color.White), b.rectangle);
            }

            foreach (Rectangle r in floorList)
            {
                e.Graphics.FillRectangle(redBrush, r);
            }

            e.Graphics.DrawImage(Properties.Resources.barrelStack, barrelStack);

            e.Graphics.DrawImage(dkSprite, dk);

            e.Graphics.DrawImage(heroSprite, hero.X, hero.Y, hero.size, hero.size);
        }
    }
}
