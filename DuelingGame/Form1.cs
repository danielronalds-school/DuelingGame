using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

namespace DuelingGame
{
    public partial class Form1 : Form
    {
        Graphics g;

        Player player = new Player(10, 355, "blue");
        Player player2 = new Player(600, 355, "red");

        bool playerLeft, playerRight, playerFacingLeft;

        bool player2Left, player2Right, player2FacingLeft;

        string playerAction;

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, Canvas, new object[] { true });

        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            player.DrawPlayer(g, playerFacingLeft, playerAction);
            player2.DrawPlayer(g, playerFacingLeft, playerAction);
        }

        // Keyboard Hooks
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                // Player 1
                case Keys.A:
                    playerLeft = true;
                    break;

                case Keys.D:
                    playerRight = true;
                    break;

                case Keys.E:
                    playerAction = "Attacking";
                    break;

                case Keys.Q:
                    playerAction = "Blocking";
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // Player 1
                case Keys.A:
                    playerLeft = false;
                    break;

                case Keys.D:
                    playerRight = false;
                    break;

                case Keys.E:
                    playerAction = "Standing";
                    break;

                case Keys.Q:
                    playerAction = "Standing";
                    break;
            }
        }

        private void tmrPlayer_Tick(object sender, EventArgs e)
        {
            if (playerLeft)
            {
                player.MovePlayer(true);
                playerFacingLeft = true;
            }

            if (playerRight)
            {
                player.MovePlayer(false);
                playerFacingLeft = false;
            }

            Canvas.Invalidate();
        }
    }
}
