using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuplicateDetectionAndDeletion
{
    public partial class Splash_Screen : Form
    {
        Timer tmr;
        public Splash_Screen()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
         
        }

        private void Splash_Screen_Shown(object sender, EventArgs e)
        {
            tmr = new Timer();

            //set time interval 3 sec

            tmr.Interval = 3000;

            //starts the timer

            tmr.Start();

            tmr.Tick += tmr_Tick;
        }

        void tmr_Tick(object sender, EventArgs e)

        {

            //after 3 sec stop the timer

            tmr.Stop();

            //display mainform

            MainForm mainForm = new MainForm();

            mainForm.Show();

            //hide this form

            this.Hide();

        }
    }
}
