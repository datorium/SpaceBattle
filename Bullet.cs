using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceBattle
{
    class Bullet : PictureBox
    {
        private Timer timerBulletMove;
        
        public Bullet()
        {
            InitializeBullet();
        }

        private void InitializeTimerBulletMove()
        {
            timerBulletMove = new Timer();
            timerBulletMove.Interval = 20;
            timerBulletMove.Tick += new EventHandler(TimerBulletMove_Tick);
            timerBulletMove.Start();
        }

        private void TimerBulletMove_Tick(object sender, EventArgs e)
        {

        }

        private void InitializeBullet()
        {
            this.BackColor = Color.Red;
            this.Height = 10;
            this.Width = 10;
        }
    }
}
