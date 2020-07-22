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

        private Image playerBlockingImage = Properties.Resources.stick_man_guarding_stance;

        public Image[] attackingLeftAnimations = new Image[3] { Properties.Resources.stick_man_attack_stance_1,
                                                                Properties.Resources.stick_man_attack_stance_2,
                                                                Properties.Resources.stick_man_attack_stance_3};

        public Image StandingImage = Properties.Resources.stick_man_action_stance;

        public Rectangle playerRec;

        public int playerSpeed = 2;

        private int animationPhase = 0;
        private int animationDelay = 7;
        private int animationCurrentDelay = 0;

        public Player(int position_x, int position_y)
        {
            x = position_x;// 10;
            y = position_y;// 380;
            width = 48;
            height = 48;
            playerImage = Properties.Resources.stick_man_action_stance;
            playerRec = new Rectangle(x, y, width, height);
        }


        public void DrawPlayer(Graphics g, bool Left, string Action)
        {
            updateAnimation(Left, Action);
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

        public void updateAnimation(bool Left, string Action)
        {
            if (Left)   
            {
                if (animationPhase == 3)
                {
                    animationPhase = 0;
                }
                if (Action == "Attacking")
                {
                    playerImage = attackingLeftAnimations[animationPhase];
                }
                else if (Action == "Blocking")
                {
                    playerImage = Properties.Resources.stick_man_guarding_stance;
                }
                else if (Action == "Standing")
                {
                    playerImage = StandingImage;
                }
                playerRec.Width = 0 - width;
            } 
            else
            {
                if (animationPhase == 3)
                {
                    animationPhase = 0;
                }
                if (Action == "Attacking")
                {
                    playerImage = attackingLeftAnimations[animationPhase];
                }
                else if (Action == "Blocking")
                {
                    playerImage = playerBlockingImage;
                }
                else if (Action == "Standing")
                {
                    playerImage = StandingImage;
                }
                playerRec.Width = width;
            }

            if (animationCurrentDelay == animationDelay)
            {
                animationCurrentDelay = 0;
                animationPhase++;
            }
            else
            {
                animationCurrentDelay++;
            }
        }

    }
}
