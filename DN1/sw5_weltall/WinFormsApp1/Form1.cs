using System.Collections;
using WinFormsApp1.Properties;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private List<Orb> space = new List<Orb>(); 

        public Form1()
        {
            InitializeComponent();
            /**
            space.Add(new Planet("jupiter", 600, 400, -0.038, 0, 100));
            space.Add(new Planet("mars", 600, 600, 3.8, 0, 1));
            */
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            
            
            space.Add(new Spaceship("enterprise",600, 230, 3, 0, 1));
            space.Add(new Planet("jupiter", 600, 400, -0.099, 0, 100));
            space.Add(new Planet("mars", 300, 400, 0, 1.5, 4));
            space.Add(new Planet("merkur", 200, 200, 0, -1.5, 4));
            

        }

        private void timer1_Tick(object? sender, EventArgs e)
        {
            foreach (Orb orb in space) {
                orb.CalcPosNew(space);
            }

            foreach (Orb orb in space) {
                orb.Move();
            }
            Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            foreach (Orb orb in space) {
                orb.Draw(e.Graphics);
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
        }
    }
}