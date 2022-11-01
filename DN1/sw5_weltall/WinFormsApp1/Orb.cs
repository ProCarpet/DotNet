using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Properties;

public abstract class Orb
{
    protected const double G = 30; //6.673e-11

    protected Vector posNew, pos;
    protected Vector v0;
    protected string name;
    protected double mass;
    protected Bitmap bitmap;

    public Vector Pos
    {
        get { return pos; }
    }

    public Vector Velocity
    {
        get { return v0; }
    }

    public double Mass
    {
        get { return mass; }
    }

    public abstract void Draw(Graphics g);

    public void Move()
    {
        pos = posNew;
    }

    public Orb(string name, double x, double y, double vx, double vy, double m)
    {
        pos = new Vector(x, y, 0);
        v0 = new Vector(vx, vy, 0);
        mass = m;
        this.name = name;
        bitmap = (Bitmap)Resources.ResourceManager.GetObject(name);
    }

    public virtual void CalcPosNew(IList<Orb> space)
    {
        Vector a = new Vector(0, 0, 0);
        foreach (Orb orb in space) {
            if (orb == this)
            {
                continue;
            }
            Vector r = orb.pos - this.pos;
            double distance = (double)r;
            double F = (G * (this.Mass * orb.Mass)) / (distance * distance);
            double aScalar = F / this.Mass; 
            a += Math.Abs(aScalar)*(r/((double)r));

        }
        double t = 3;
        posNew = pos + v0 * t + (t * t) * a;
        v0 = v0 + t * a;
    }

    public override string ToString()
    {
        return name;
    }
}