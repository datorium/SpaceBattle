using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceBattle
{
    public partial class Battlefield : Form
    {
        private bool moveLeft = false;
        private bool moveRight = false;
        private bool bulletFired = false;

        private Spaceship spaceship = null;
        //private Bullet bullet = null;
        private Timer mainTimer = null;
        private Timer enemyTimer = null;
        private Random rand = new Random();
        
        public Battlefield()
        {
            InitializeComponent();
            InitializeBattlefield();
            InitializeMainTimer();
            InitializeEnemyTimer();
        }

        private void InitializeBattlefield()
        {
            this.BackColor = Color.Black;
            spaceship = new Spaceship();
            spaceship.Left = ClientRectangle.Width - (ClientRectangle.Width / 2 + spaceship.Width / 2);
            spaceship.Top = ClientRectangle.Height - spaceship.Height;
            this.Controls.Add(spaceship);
        }

        private void InitializeMainTimer()
        {
            mainTimer = new Timer();
            mainTimer.Tick += new EventHandler(MainTimer_Tick);
            mainTimer.Interval = 20;
            mainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if (moveLeft)
            {
                spaceship.Left -= 2;
            }
            if (moveRight)
            {
                spaceship.Left += 2;
            }
        }

        private void InitializeEnemyTimer()
        {
            enemyTimer = new Timer();
            enemyTimer.Tick += new EventHandler(EnemyTimer_Tick);
            enemyTimer.Interval = 2000;
            enemyTimer.Start();
        }

        private void EnemyTimer_Tick(object sender, EventArgs e)
        {
            Enemy enemy = new Enemy(rand.Next(1,6), this);
            this.Controls.Add(enemy);
        }

        //private void FireBullet()
        //{
        //    bullet = new Bullet();
        //    bullet.Top = spaceship.Top;
        //    bullet.Left = spaceship.Left + (spaceship.Width / 2 - bullet.Width / 2);
        //    this.Controls.Add(bullet);
        //    bullet.BringToFront();
        //}

        private void Battlefield_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space && !bulletFired)
            {
                spaceship.Fire(this);
                bulletFired = true;
            }
            else if(e.KeyCode == Keys.A)
            {
                moveLeft = true;
            }
            else if(e.KeyCode == Keys.D)
            {
                moveRight = true;
            }
            else if (e.KeyCode == Keys.E)
            {
                if(spaceship.EngineState == "off")
                {
                    spaceship.EngineOn();
                }
                else if(spaceship.EngineState == "on")
                {
                    spaceship.EngineOff();
                }                
            }
        }

        private void Battlefield_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                spaceship.Fire(this);
            }
        }

        private void Battlefield_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                bulletFired = false;
            }
            else if(e.KeyCode == Keys.A)
            {
                moveLeft = false;
            }
            else if(e.KeyCode == Keys.D)
            {
                moveRight = false;
            }
        }
    }
}
