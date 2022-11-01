using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Properties;

namespace WinFormsApp1
{
    internal class Planet : Orb
    {
        public Planet(string name, double x, double y, double vx, double vy, double m) : base(name, x, y, vx, vy, m)
        {

        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(bitmap, (int)pos[0], (int)pos[1], bitmap.Width / 2, bitmap.Height / 2);
        }
    }
}
