using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DuelingGame
{
    class Player
    {
        public int x, y, width, height;

        public Image playerImage;

        public Image[] attackingLeftAnimations = new Image[3] { Properties.Resources.stick_man_attack_stance_1,
                                                                Properties.Resources.stick_man_attack_stance_2,
                                                                Properties.Resources.stick_man_attack_stance_3};

        public Rectangle playerRec;

        public int playerSpeed = 2;

        public Player(int position_x, int position_y)
        {
            x = position_x;// 10;
            y = position_y;// 380;
            width = 48;
            height = 48;
            playerImage = Properties.Resources.stick_man_action_stance;
            playerRec = new Rectangle(x, y, width, height);
        }

        public void DrawPlayer(Graphics g)
        {
            g.DrawImage(playerImage, playerRec);
        }

        public void MovePlayer(bool Left)
        {
            if (Left)
            {
                x -= playerSpeed;
            }
            else
            {
                x += playerSpeed;
            }
            playerRec.Location = new Point(x, y);
        }

        public void updateAnimation()
        {

        }

    }
}
