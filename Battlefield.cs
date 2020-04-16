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
        bool moveLeft = false;
        bool moveRight = false;
        bool gameOver = false;
        bool bulletFired = false;

        Random rand = new Random();
        Spaceship spaceship = null;
        Bullet bullet = null;
        Enemy enemy = null;
        Timer mainTimer = null;
        Timer enemyTimer = null;

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
            spaceship.Top = ClientRectangle.Height - (spaceship.Height + 20);
            this.Controls.Add(spaceship);
        }

        private void InitializeMainTimer()
        {
            mainTimer = new Timer();
            mainTimer.Tick += new EventHandler(MainTimer_Tick);
            mainTimer.Interval = 10;
            mainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if (moveLeft && spaceship.Left > 0)
            {
                spaceship.Left -= 2;
            }
            if (moveRight && spaceship.Left + spaceship.Width < ClientRectangle.Width)
            {
                spaceship.Left += 2;
            }
        }

        private  void InitializeEnemyTimer()
        {
            enemyTimer = new Timer();
            enemyTimer.Tick += new EventHandler(EnemyTimer_Tick);
            enemyTimer.Interval = 2000;
            enemyTimer.Start();
        }

        private void EnemyTimer_Tick(object sender, EventArgs e)
        {
            enemy = new Enemy(rand.Next(1, 6), this);
            enemy.Tag = "enemy";
            enemy.Left = rand.Next(0, ClientRectangle.Width - enemy.Width);
            enemy.Top = 0;
            this.Controls.Add(enemy);
        }


        private void Battlefield_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && !bulletFired)
            {
                spaceship.Fire(this);
                bulletFired = true;
            }
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                moveRight = true;
            }
            else if (e.KeyCode == Keys.O)
            {
                if(spaceship.EngineStatus == "off")
                {
                    spaceship.EngineOn();
                }
                else if (spaceship.EngineStatus == "on")
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
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
        }

        private void EnemyBulletCollision()
        {
            foreach(Control c in this.Controls)
            {
                if(c.Tag == "enemy")
                {

                }
            }
        }
    }
}
