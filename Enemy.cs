﻿using System;
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
        private Timer timerEnemyMove;
        int verVelocity = 0;
        int horVelocity = 0;
        private int enemyStep;
        Battlefield battlefield;

        public Enemy(int speed, Battlefield bf)
        {
            enemyStep = speed;
            battlefield = bf;
            InitializeEnemy();
            InitializeTimerEnemyMove();
        }

        private void InitializeTimerEnemyMove()
        {
            timerEnemyMove = new Timer();
            timerEnemyMove.Interval = 20;
            timerEnemyMove.Tick += new EventHandler(TimerEnemyMove_Tick);
            verVelocity = enemyStep;
            timerEnemyMove.Start();
        }

        private void TimerEnemyMove_Tick(object sender, EventArgs e)
        {
            this.Top += verVelocity;
            this.Left += horVelocity;
            if (this.Top > battlefield.ClientRectangle.Height)
            {
                this.Dispose();
            }
        }

        private void InitializeEnemy()
        {
            this.BackColor = Color.Pink;
            this.Height = 20;
            this.Width = 20;
        }

    }
}
