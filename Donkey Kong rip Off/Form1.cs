using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Donkey_Kong_rip_Off
{
    public partial class Form1 : Form
    {

        public static List<Image> rWalkSprites = new List<Image>();
        public static List<Image> lWalkSprites = new List<Image>();
        public static List<Image> lhIDLE = new List<Image>();
        public static List<Image> rhIDLE = new List<Image>();
        public static List<Image> climb1Sprites = new List<Image>();
        public static List<Image> climb2Sprites = new List<Image>();
        public static List<Image> dkIdle = new List<Image>();
        public static List<Image> barrelThrow = new List<Image>();
        public static List<Image> rollingLadder = new List<Image>();
        public static List<Image> rolling = new List<Image>();
        public static List<Image> death = new List<Image>();
        public Form1()
        {
            InitializeComponent();
            #region rWalk Sprites
            rWalkSprites.Add(Properties.Resources.R_Idle);
            rWalkSprites.Add(Properties.Resources.R_Idle);
            rWalkSprites.Add(Properties.Resources.R_Walk1);
            rWalkSprites.Add(Properties.Resources.R_Walk1);
            rWalkSprites.Add(Properties.Resources.R_Idle);
            rWalkSprites.Add(Properties.Resources.R_Idle);
            rWalkSprites.Add(Properties.Resources.R_Walk2);
            rWalkSprites.Add(Properties.Resources.R_Walk2);
            #endregion

            #region lWalk Sprites
            lWalkSprites.Add(Properties.Resources.L_Idle);
            lWalkSprites.Add(Properties.Resources.L_Idle);
            lWalkSprites.Add(Properties.Resources.L_Walk1);
            lWalkSprites.Add(Properties.Resources.L_Walk1);
            lWalkSprites.Add(Properties.Resources.L_Idle);
            lWalkSprites.Add(Properties.Resources.L_Idle);
            lWalkSprites.Add(Properties.Resources.L_Walk2);
            lWalkSprites.Add(Properties.Resources.L_Walk2);
            #endregion

            #region climb spritres
            climb1Sprites.Add(Properties.Resources.Climb1);
            climb1Sprites.Add(Properties.Resources.Climb1);
            climb1Sprites.Add(Properties.Resources.Climb1);
            climb1Sprites.Add(Properties.Resources.Climb1);
            climb1Sprites.Add(Properties.Resources.Climb2);
            climb1Sprites.Add(Properties.Resources.Climb2);
            climb1Sprites.Add(Properties.Resources.Climb2);
            climb1Sprites.Add(Properties.Resources.Climb2);

            climb2Sprites.Add(Properties.Resources.Climb3);
            climb2Sprites.Add(Properties.Resources.Climb3);
            climb2Sprites.Add(Properties.Resources.Climb3);
            climb2Sprites.Add(Properties.Resources.Climb3);
            climb2Sprites.Add(Properties.Resources.Climb4);
            climb2Sprites.Add(Properties.Resources.Climb4);
            climb2Sprites.Add(Properties.Resources.Climb4);
            climb2Sprites.Add(Properties.Resources.Climb4);
            climb2Sprites.Add(Properties.Resources.Climb4);
            climb2Sprites.Add(Properties.Resources.Climb4);
            climb2Sprites.Add(Properties.Resources.Climb4);
            climb2Sprites.Add(Properties.Resources.Climb4);
            #endregion

            #region dkIdle Sprites
            dkIdle.Add(Properties.Resources.D_Idle1);
            dkIdle.Add(Properties.Resources.D_Idle1);
            dkIdle.Add(Properties.Resources.D_Idle1);
            dkIdle.Add(Properties.Resources.D_Idle1);
            dkIdle.Add(Properties.Resources.D_Idle1);
            dkIdle.Add(Properties.Resources.D_Idle1);
            dkIdle.Add(Properties.Resources.D_Idle1);
            dkIdle.Add(Properties.Resources.D_Idle1);
            dkIdle.Add(Properties.Resources.D_Idle1);
            dkIdle.Add(Properties.Resources.D_Idle1);
            dkIdle.Add(Properties.Resources.D_Idle2);
            dkIdle.Add(Properties.Resources.D_Idle2);
            dkIdle.Add(Properties.Resources.D_Idle2);
            dkIdle.Add(Properties.Resources.D_Idle2);
            dkIdle.Add(Properties.Resources.D_Idle2);
            dkIdle.Add(Properties.Resources.D_Idle2);
            dkIdle.Add(Properties.Resources.D_Idle2);
            dkIdle.Add(Properties.Resources.D_Idle2);
            dkIdle.Add(Properties.Resources.D_Idle2);
            dkIdle.Add(Properties.Resources.D_Idle2);
            #endregion

            #region throw barrel sprites
            barrelThrow.Add(Properties.Resources.Grab3);
            barrelThrow.Add(Properties.Resources.Grab3);
            barrelThrow.Add(Properties.Resources.Grab3);
            barrelThrow.Add(Properties.Resources.Grab3);
            barrelThrow.Add(Properties.Resources.Grab3);
            barrelThrow.Add(Properties.Resources.Grab3);
            barrelThrow.Add(Properties.Resources.Grab3);
            barrelThrow.Add(Properties.Resources.Grab3);
            barrelThrow.Add(Properties.Resources.Grab3);
            barrelThrow.Add(Properties.Resources.Grab3);
            barrelThrow.Add(Properties.Resources.Grab3);
            barrelThrow.Add(Properties.Resources.Grab3);
            barrelThrow.Add(Properties.Resources.Grab2);
            barrelThrow.Add(Properties.Resources.Grab2);
            barrelThrow.Add(Properties.Resources.Grab2);
            barrelThrow.Add(Properties.Resources.Grab2);
            barrelThrow.Add(Properties.Resources.Grab2);
            barrelThrow.Add(Properties.Resources.Grab2);
            barrelThrow.Add(Properties.Resources.Grab2);
            barrelThrow.Add(Properties.Resources.Grab2);
            barrelThrow.Add(Properties.Resources.Grab2);
            barrelThrow.Add(Properties.Resources.Grab2);
            barrelThrow.Add(Properties.Resources.Grab2);
            barrelThrow.Add(Properties.Resources.Grab2);
            barrelThrow.Add(Properties.Resources.Grab1);
            barrelThrow.Add(Properties.Resources.Grab1);
            barrelThrow.Add(Properties.Resources.Grab1);
            barrelThrow.Add(Properties.Resources.Grab1);
            barrelThrow.Add(Properties.Resources.Grab1);
            barrelThrow.Add(Properties.Resources.Grab1);
            barrelThrow.Add(Properties.Resources.Grab1);
            barrelThrow.Add(Properties.Resources.Grab1);
            barrelThrow.Add(Properties.Resources.Grab1);
            barrelThrow.Add(Properties.Resources.Grab1);
            barrelThrow.Add(Properties.Resources.Grab1);
            barrelThrow.Add(Properties.Resources.Grab1);
            #endregion

            #region rollingR sprites 
            rolling.Add(Properties.Resources.B1);
            rolling.Add(Properties.Resources.B1);
            rolling.Add(Properties.Resources.B1);
            rolling.Add(Properties.Resources.B1);
            rolling.Add(Properties.Resources.B2);
            rolling.Add(Properties.Resources.B2);
            rolling.Add(Properties.Resources.B2);
            rolling.Add(Properties.Resources.B2);
            rolling.Add(Properties.Resources.B3);
            rolling.Add(Properties.Resources.B3);
            rolling.Add(Properties.Resources.B3);
            rolling.Add(Properties.Resources.B3);
            rolling.Add(Properties.Resources.B4);
            rolling.Add(Properties.Resources.B4);
            rolling.Add(Properties.Resources.B4);
            rolling.Add(Properties.Resources.B4);
            #endregion

            #region ladder rolling
            rollingLadder.Add(Properties.Resources.BL1);
            rollingLadder.Add(Properties.Resources.BL1);
            rollingLadder.Add(Properties.Resources.BL1);
            rollingLadder.Add(Properties.Resources.BL1);
            rollingLadder.Add(Properties.Resources.BL2);
            rollingLadder.Add(Properties.Resources.BL2);
            rollingLadder.Add(Properties.Resources.BL2);
            rollingLadder.Add(Properties.Resources.BL2);
            #endregion

            #region dying sprites 
            death.Add(Properties.Resources.Death1);
            death.Add(Properties.Resources.Death1);
            death.Add(Properties.Resources.Death1);
            death.Add(Properties.Resources.Death2);
            death.Add(Properties.Resources.Death2);
            death.Add(Properties.Resources.Death2);
            death.Add(Properties.Resources.Death3);
            death.Add(Properties.Resources.Death3);
            death.Add(Properties.Resources.Death3);
            death.Add(Properties.Resources.Death4);
            death.Add(Properties.Resources.Death4);
            death.Add(Properties.Resources.Death4);
            #endregion

            #region L hammer Idle
            lhIDLE.Add(Properties.Resources.L_IdleH1);
            lhIDLE.Add(Properties.Resources.L_IdleH1);
            lhIDLE.Add(Properties.Resources.L_IdleH1);
            lhIDLE.Add(Properties.Resources.L_IdleH1);
            lhIDLE.Add(Properties.Resources.L_IdleH1);
            lhIDLE.Add(Properties.Resources.L_IdleH1);
            lhIDLE.Add(Properties.Resources.L_IdleH2);
            lhIDLE.Add(Properties.Resources.L_IdleH2);
            lhIDLE.Add(Properties.Resources.L_IdleH2);
            lhIDLE.Add(Properties.Resources.L_IdleH2);
            lhIDLE.Add(Properties.Resources.L_IdleH2);
            lhIDLE.Add(Properties.Resources.L_IdleH2);
            #endregion

            #region R hammer Idle
            rhIDLE.Add(Properties.Resources.R_IdleH1);
            rhIDLE.Add(Properties.Resources.R_IdleH1);
            rhIDLE.Add(Properties.Resources.R_IdleH1);
            rhIDLE.Add(Properties.Resources.R_IdleH1);
            rhIDLE.Add(Properties.Resources.R_IdleH1);
            rhIDLE.Add(Properties.Resources.R_IdleH1);
            rhIDLE.Add(Properties.Resources.R_IdleH2);
            rhIDLE.Add(Properties.Resources.R_IdleH2);
            rhIDLE.Add(Properties.Resources.R_IdleH2);
            rhIDLE.Add(Properties.Resources.R_IdleH2);
            rhIDLE.Add(Properties.Resources.R_IdleH2);
            rhIDLE.Add(Properties.Resources.R_IdleH2);
            #endregion
        }

        public static void ChangeScreen(object sender, UserControl next)
        {
            Form f;

            if (sender is Form)
            {
                f = (Form)sender;
            }
            else
            {
                UserControl current = (UserControl)sender;
                f = current.FindForm();
                f.Controls.Remove(current);
            }

            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,
                (f.ClientSize.Height - next.Height) / 2);
            f.Controls.Add(next);
            next.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChangeScreen(this, new MenuScreen());
        }
    }
}
