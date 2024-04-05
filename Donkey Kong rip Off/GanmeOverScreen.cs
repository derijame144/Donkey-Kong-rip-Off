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
    public partial class GanmeOverScreen : UserControl
    {
        bool play = true;

        public GanmeOverScreen()
        {
            InitializeComponent();
        }

        private void GanmeOverScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (play)
                    {
                        Form1.ChangeScreen(this, new GameScreen());
                    }
                    else
                    {
                        Application.Exit();
                    }
                    break;
                case Keys.W:
                    if (play)
                    {
                        play = false;
                        playLabel.BackColor = Color.Black;
                        exitLabel.BackColor = Color.White;
                    }
                    else
                    {
                        play = true;
                        playLabel.BackColor = Color.White;
                        exitLabel.BackColor = Color.Black;
                    }
                    Refresh();
                    break;
                case Keys.S:
                    if (play)
                    {
                        play = false;
                        playLabel.BackColor = Color.Black;
                        exitLabel.BackColor = Color.White;
                    }
                    else
                    {
                        play = true;
                        playLabel.BackColor = Color.White;
                        exitLabel.BackColor = Color.Black;
                    }
                    Refresh();
                    break;

            }
        }
    }
}
