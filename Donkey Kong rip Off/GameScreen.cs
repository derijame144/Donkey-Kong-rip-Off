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

        public static int playerTimer;
        public static int barrelTimer = 35;
        public static int width;
        public static int height;

        int nextFloorX;
        int nextFloorY;

        public static string dirrection;

        public static bool aKey, dKey, wKey, sKey, spaceKey;

        public static bool climb, jump = false;

        bool spawnBarrel = false;

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
        Animation climbing1;
        Animation climbing2;
        Animation dkIdle;
        Animation Throw;


        Brush redBrush = new SolidBrush(Color.Red);
        Brush blueBrush = new SolidBrush(Color.Blue);
        Brush whiteBrush = new SolidBrush(Color.White);

        Rectangle dk = new Rectangle(339, 83, 70, 70);
        Rectangle barrelStack = new Rectangle(409, 83, 40, 70);

        public GameScreen()
        {
            InitializeComponent();

            hero = new Player(10, this.Height - 44);
            rWalk = new Animation(Form1.rWalkSprites);
            lWalk = new Animation(Form1.lWalkSprites);
            climbing1 = new Animation(Form1.climb1Sprites);
            climbing2 = new Animation(Form1.climb2Sprites);
            dkIdle = new Animation(Form1.dkIdle);
            Throw = new Animation(Form1.barrelThrow);

            width = this.Width;
            height = this.Height;

            //ladderHitBox.Add(new Rectangle(360, 470, 10, 36));
            //ladderHitBox.Add(new Rectangle(220, 334, 10, 30));
            //ladderHitBox.Add(new Rectangle(220, 334, 10, 30));
            ladderList.Add(new Rectangle(350, 500, 30, 66));
            ladderList.Add(new Rectangle(82, 395, 30, 66));
            ladderList.Add(new Rectangle(224, 380, 30, 110));
            ladderList.Add(new Rectangle(351, 294, 30, 66));
            ladderList.Add(new Rectangle(267, 275, 30, 90));
            ladderList.Add(new Rectangle(83, 185, 30, 66));

            foreach (Rectangle r in ladderList)
            {
                ladderHitBox.Add(new Rectangle(r.X + 7, r.Y - 35, 10, 30));
            }

            floorList.Add(new Rectangle(0, this.Height - 15, 220, 15));


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
                if (hero.Collision(r) && climb == false)
                {
                    hero.Y = r.Y - 29;
                    jump = false;
                }
            }

            foreach (Rectangle r in ladderList)
            {
                if (hero.Collision(r) && wKey == true && jump == false)
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
                    if (hero.Collision(r))
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

            dkIdle.Play();
            dkSprite = dkIdle.currentsprite;

            #region spawn barrel
            if (barrelTimer == 50 || spawnBarrel)
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

                #region barrel goes down ladder
                foreach (Rectangle r in ladderHitBox)
                {


                    if (b.rectangle.IntersectsWith(r) && rng.Next(1, 5) == 1 && b.touchingLadder == false)
                    {
                        b.ladder = true;
                        b.rectangle.Y += 15;
                        b.spriteNumber = 0;
                    }
                    else if (b.rectangle.IntersectsWith(r))
                    {
                        b.touchingLadder = true;
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

            barrelTimer++;


            Refresh();
        }

        public void gravity()
        {
            onGround.Clear();

            foreach (Rectangle r in floorList)
            {
                if (hero.Collision(r) == true)
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

            //foreach (Rectangle r in ladderHitBox)
            //{
            //    e.Graphics.FillRectangle(whiteBrush, r);
            //}

            foreach (Barrel b in barrels)
            {
                e.Graphics.DrawImage(b.currentSprite, b.rectangle);
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
