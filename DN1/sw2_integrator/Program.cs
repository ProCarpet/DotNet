using System;

namespace DN2 {
  class MainClass {
    const int STEPS = 100;
    const double EPS = 1E-5;
    
    public static void Main(string[] args) {
      Console.WriteLine("Linear fixed [0..10]: "+Integrator.Integrate(x => x,  0,10,STEPS)+" steps: "+Integrator.Steps);
      Console.WriteLine("Linear fixed [5..15]: "+Integrator.Integrate(x => x,  5,15,STEPS)+" steps: "+Integrator.Steps);
      Console.WriteLine("Linear adapt [0..10]: "+Integrator.Integrate(x => x,   0,10,EPS)+" steps: "+Integrator.Steps);
      Console.WriteLine("Square fixed [0..10]: "+Integrator.Integrate(x => x*x, 0,10,STEPS)+" steps: "+Integrator.Steps);
      Console.WriteLine("Square adapt [0..10]: "+Integrator.Integrate(x => x*x, 0,10,EPS)+" steps: "+Integrator.Steps);
      Console.ReadLine();
    }
  }
  
  public class Integrator {
      public static int Steps;

      public static double Integrate(Func<double, double> f, double start, double end, int steps) {
          Steps = steps;
          double Step_width = (end - start) / steps;
          double Result = f(start) + f(end);
          for(int i = 1; i < Steps ; i++) { 
              Result += 2*f(start + i*Step_width); 
          }
          return Step_width * Result / 2; 
   
      }
  
      public static double Integrate(Func<double, double> f, double start, double end, double eps) {
          Steps = 1;
          double Integral_value1 = Integrate(f, start,  end, Steps);
          Steps *= 2; 
          double Integral_value2 = Integrate(f, start,  end, Steps);
          while(Math.Abs(Integral_value1 - Integral_value2) > eps  ) { 
                Steps *= 2;
                Integral_value1 = Integral_value2;
                Integral_value2 = Integrate( f, start, end, Steps);  
            }
          return Integral_value2;
        }
      }

}