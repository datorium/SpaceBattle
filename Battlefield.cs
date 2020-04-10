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
        Spaceship spaceship;
        
        public Battlefield()
        {
            InitializeComponent();
            InitializeBattlefield();
        }

        private void InitializeBattlefield()
        {
            spaceship = new Spaceship();
            spaceship.Left = 100;
            spaceship.Top = 200;
            this.Controls.Add(spaceship);
        }
    }
}
