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
        public Bullet()
        {
            InitializeBullet();
        }

        private void InitializeBullet()
        {
            this.BackColor = Color.Red;
            this.Height = 10;
            this.Width = 10;
        }
    }
}
