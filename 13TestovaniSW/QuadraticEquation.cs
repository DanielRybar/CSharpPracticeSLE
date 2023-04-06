using _13TestovaniSW.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13TestovaniSW
{
    public class QuadraticEquation
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public QuadraticEquation(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public void SetParameters(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public double GetDiscriminant()
        {
            return Math.Pow(B, 2) - 4 * A * C;
        }

        public int RootCount
        {
            get
            {
                if (A == 0) throw new QuadraticCoefficientException();

                double discriminant = GetDiscriminant();
                if (discriminant > 0)
                    return 2;
                else if (discriminant == 0)
                    return 1;
                else
                    return 0;
            }
        }

        public double[] Roots()
        {
            if (A == 0) throw new QuadraticCoefficientException();

            double discriminant = GetDiscriminant();
            if (RootCount == 0)
                return null!;
            else if (RootCount == 1)
                return new double[] { -B / (2 * A) };
            else
            {
                double root1 = (-B + Math.Sqrt(discriminant)) / (2 * A);
                double root2 = (-B - Math.Sqrt(discriminant)) / (2 * A);
                return new double[] { root1, root2 };
            }
        }

        public double[] Vertex // vrchol
        {
            get
            {
                double x = -B / (2 * A);
                double y = A * Math.Pow(x, 2) + B * x + C;
                return new double[] { x, y };
            }
        }

        public double Value(int x)
        {
            if (A == 0) throw new QuadraticCoefficientException();

            return A * Math.Pow(x, 2) + B * x + C;
        }

        public override string ToString()
        {
            return string.Format("{0}x^2 + {1}x + {2} = 0", A, B, C);
        }
    }
}
