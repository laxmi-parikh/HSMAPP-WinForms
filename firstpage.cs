using System;
using System.Windows.Forms;

namespace HSMAPP
{
    public partial class firstpage : Form
    {
        public firstpage()
        {
            InitializeComponent();
         
        }
       int startpoint = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;

            Myprogressbar.Value = startpoint;
            if (Myprogressbar.Value == 100)
            {
                Myprogressbar.Value = 0;
                timer1.Stop();
                this.Hide();
                // this.Dispose();
                LogIn log = new LogIn();
                log.Show();
               // PPParent pat = new HSMAPPParent();
                //pat.Show();

           }
        }

        private void firstpage_Load(object sender, EventArgs e)
        {
           timer1.Start();

        }

        
    }
}

