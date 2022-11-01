using System;
using System.Collections.Generic;
using System.Text;

namespace DN3 {
    public class Space {
        
        static void Main(string[] args) {
            Vector omegaEarth,omegaSun, omegaGalaxy;
            Vector rEarth, rSun, rGalaxy;
            
            InitOmegaVectors(out omegaEarth,out omegaSun, out omegaGalaxy);
            InitRVectors(out rEarth, out rSun, out rGalaxy);
            double speed = CalcSpeed(omegaEarth,omegaSun, omegaGalaxy,rEarth, rSun, rGalaxy);
            Console.WriteLine("Speed is "+speed+" km/s");
            Console.ReadLine();
        }
        
        public static void InitOmegaVectors(out Vector omegaEarth, out Vector omegaSun, out Vector omegaGalaxy) {
            Vector unitVector = new Vector(0, 1, 0);
            omegaEarth = new Vector(0, 2 * Math.PI / 1, 0); //tage
            omegaSun = new Vector(0, 2 * Math.PI / 365.25, 0);
            omegaGalaxy = new Vector(0, 2 * Math.PI / (225e6 * 365.25), 0);
        }
        
        public static void InitRVectors(out Vector rEarth, out Vector rSun, out Vector rGalaxy) {
            Vector unitVector = new Vector(1, 0, 0);
            rEarth = new Vector(6370,0,0);
            rSun = new Vector(149.6e6,0,0);
            rGalaxy = new Vector(9.46e12, 0, 0);  
        }

        public static double CalcSpeed(Vector omegaEarth,Vector omegaSun, Vector omegaGalaxy,Vector rEarth, Vector rSun, Vector rGalaxy) {
            // TODO Implement     
            Console.WriteLine(omegaEarth * rEarth + omegaSun * rSun + omegaGalaxy * rGalaxy);
            return 1.0; 
        }
    }
}
