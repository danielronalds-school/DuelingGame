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

        Player player = new Player(10, 100, "blue");
        Player player2 = new Player(600, 100, "red");

        bool playerLeft, playerRight, playerFacingLeft;

        bool player2Left, player2Right, player2FacingLeft = true;


        PictureBox[] solidObjects = new PictureBox[2];

        Player[] playersArray = new Player[2];

        string playerAction;
        string player2Action;

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, Canvas, new object[] { true });
            configureSolidObjectsArray();
            configurePlayersArray();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            runGravity();
            g = e.Graphics;
            player.DrawPlayer(g, playerFacingLeft, playerAction);
            player2.DrawPlayer(g, player2FacingLeft, player2Action);
        }

        private void configureSolidObjectsArray()
        {
            solidObjects[0] = Floor;
            solidObjects[1] = platform1;
        }

        private void configurePlayersArray()
        {
            playersArray[0] = player;
            playersArray[1] = player2;
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

                // Player 2
                case Keys.Left:
                    player2Left = true;
                    break;

                case Keys.Right:
                    player2Right = true;
                    break;

                case Keys.M:
                    player2Action = "Attacking";
                    break;

                case Keys.N:
                    player2Action = "Blocking";
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

                // Player 2
                case Keys.Left:
                    player2Left = false;
                    break;

                case Keys.Right:
                    player2Right = false;
                    break;

                case Keys.M:
                    player2Action = "Standing";
                    break;

                case Keys.N:
                    player2Action = "Standing";
                    break;
            }
        }
        
        // Timers
        private void tmrPlayer_Tick(object sender, EventArgs e)
        {
            // Player 1
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

            // Player 2
            if (player2Left)
            {
                player2.MovePlayer(true);
                player2FacingLeft = true;
            }

            if (player2Right)
            {
                player2.MovePlayer(false);
                player2FacingLeft = false;
            }

            Canvas.Invalidate();
        }

        // Gravity
        public bool objectTouchingSolidObject(Rectangle Object)
        {
            foreach(PictureBox box in solidObjects)
            {
                if (Object.IntersectsWith(box.Bounds))
                {
                    return true;
                }
            }
            return false;
        }

        public void runGravity()
        {
            foreach(Player player in playersArray)
            {
                if(!objectTouchingSolidObject(player.playerRec))
                {
                    for (int i = 0; i < player.fallSpeed; i++)
                    {
                        if (!objectTouchingSolidObject(player.playerRec))
                        {
                            player.y++;
                        }
                    }
                }
            }
        }
    }
}
