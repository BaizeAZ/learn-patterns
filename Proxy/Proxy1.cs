using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Proxy1
    {
        private Math _math;
        public Proxy1()
        {
            _math = new Math();
        }

        public double Add(double a, double b)
        {
            return _math.Add(a, b);
        }

        public double Div(double a, double b)
        {
            return _math.Div(a, b);
        }

        public double Mul(double a, double b)
        {
            return _math.Mul(a, b);
        }

        public double Sub(double a, double b)
        {
            return _math.Sub(a, b);
        }
    }

    /// <summary>
    /// The Subject interface
    /// </summary>
    public interface IMath
    {
        double Add(double a, double b);
        double Sub(double a, double b);
        double Mul(double a, double b);
        double Div(double a, double b);
    }
    /// <summary>
    /// The 'Real Subject' class
    /// </summary>
    public class Math : IMath
    {
        public double Add(double a, double b) { return a + b; }
        public double Div(double a, double b) { return a / b; }
        public double Mul(double a, double b) { return a * b; }
        public double Sub(double a, double b) { return a - b; }
    }
    /// <summary>
    /// The 'Proxy Object' class
    /// </summary>
}
