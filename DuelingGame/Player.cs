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

        bool alreadyLeft;

        private int animationPhase = 0;
        private int animationDelay = 7;
        private int animationCurrentDelay = 0;

        public bool Blocking, Attacking;

        public Player(int position_x, int position_y, string bladeColour)
        {
            if (bladeColour == "red")
            {

                attackingLeftAnimations[0] = Properties.Resources.stick_man_red_attack_stance_1;
                attackingLeftAnimations[1] = Properties.Resources.stick_man_red_attack_stance_2;
                attackingLeftAnimations[2] = Properties.Resources.stick_man_red_attack_stance_3;
                StandingImage = Properties.Resources.stick_man_red_action_stance;
                playerBlockingImage = Properties.Resources.stick_man_red_guarding_stance;
            }

            playerImage = StandingImage;
            x = position_x;// 10;
            y = position_y;// 380;
            width = 48;
            height = 48;
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
                    Attacking = true;
                    Blocking = false;
                }
                else if (Action == "Blocking")
                {
                    playerImage = Properties.Resources.stick_man_guarding_stance;
                    Attacking = false;
                    Blocking = true;
                }
                else if (Action == "Standing")
                {
                    playerImage = StandingImage;
                    Attacking = false;
                    Blocking = false;
                }
                faceLeft();
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
                    Attacking = true;
                    Blocking = false;
                }
                else if (Action == "Blocking")
                {
                    playerImage = playerBlockingImage;
                    Attacking = false;
                    Blocking = true;
                }
                else if (Action == "Standing")
                {
                    playerImage = StandingImage;
                    Attacking = false;
                    Blocking = false;
                }
                faceRight();
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

        private void faceLeft()
        {
            if (!alreadyLeft)
            {
                playerRec.Width = 0 - width;
                x = x + (width / 2);
                playerRec.Location = new Point(x, y);
                alreadyLeft = true;
            }
        }

        private void faceRight()
        {
            if (alreadyLeft)
            {
                playerRec.Width = width;
                x = x - (width / 2);
                playerRec.Location = new Point(x, y);
            }
            alreadyLeft = false;
        }
    }
}
