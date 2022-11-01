using System;
using System.Diagnostics.CodeAnalysis;

namespace DN3 {
    public struct Vector {
        double x,y,z;

        //Konstruktor
        public Vector(double x, double y, double z){
            this.x=x;
            this.y=y;
            this.z=z;
        }
        
        public override string ToString(){
            return "["+x+" "+y+" "+z+"]";
        }

        public static Vector operator +(Vector a, Vector b) {
            return new Vector(a.x + b.x, a.y + b.y, a.z + b.z); 
        }

        public static Vector operator -(Vector a, Vector b) {
            return new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector operator *(Vector a, Vector b) {
            return new Vector(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
        }

        public static Vector operator *(Vector a, double b) {
            return new Vector(a.x * b, a.y * b, a.z * b);
        }

        public static Vector operator *(double a, Vector b)
        {
            return new Vector(b.x * a, b.y * a, b.z * a);
        }

        public static Vector operator /(Vector a, double b)
        {
            return new Vector(a.x / b, a.y / b, a.z / b);
        }

        public static Vector operator /(double a, Vector b)
        {
            return new Vector(b.x / a, b.y / a, b.z / a);
        }

        public static bool operator ==(Vector a, Vector b) {
            return a.x == b.x && a.y == b.y && a.z == b.z;
        }

        public static bool operator !=(Vector a, Vector b)
        {
            return !(a == b); 
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return base.Equals(obj);
        }


        public double this[int i]
        {
            get
            {
                if (i == 0) return this.x; 
                else if (i == 1) return this.y;
                else if (i == 2) return this.z; 
                else return 0; //TODO this ugly af

            }
            set
            {
                if (i == 0) this.x = value;
                else if (i == 1) this.y = value;
                else if (i == 2) this.z = value;
            }
        }


        // TODO Implement
    }

    internal class MainClass {
       public static void Test() {
          Vector a = new Vector(1,2,3);
          Vector b = new Vector(4,5,6);
          Vector c = a * b;
          Console.WriteLine(c);
        }

        public static void Main(string[] args) {
           Test();
        }
    }
}
