using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceBattle
{
    class Enemy : PictureBox
    {
        private Timer timerBulletMove;
        int verVelocity = 0;
        int horVelocity = 0;
        private int enemyStep;

        public Enemy(int speed)
        {
            enemyStep = speed;
            InitializeBullet();
            InitializeTimerBulletMove();
        }

        private void InitializeTimerBulletMove()
        {
            timerBulletMove = new Timer();
            timerBulletMove.Interval = 20;
            timerBulletMove.Tick += new EventHandler(TimerBulletMove_Tick);
            verVelocity = -enemyStep;
            timerBulletMove.Start();
        }

        private void TimerBulletMove_Tick(object sender, EventArgs e)
        {
            this.Top += verVelocity;
            this.Left += horVelocity;
            if (this.Top + this.Height < 0)
            {
                this.Dispose();
            }
        }

        private void InitializeBullet()
        {
            this.BackColor = Color.Red;
            this.Height = 10;
            this.Width = 2;
        }

    }
}
