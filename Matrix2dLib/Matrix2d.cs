#nullable disable
using System;
using System.Text.RegularExpressions;

namespace Matrix2dLib
{
    // Immutable class
    public class Matrix2d : IEquatable<Matrix2d>
    {
        int a, b, c, d; // private fields
        /*
          -------
          | a b |
          | c d |
          -------
         */

        // Constructor
        public Matrix2d(int a, int b, int c, int d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public Matrix2d() : this(1, 0, 0, 1) { }
        public Matrix2d Id => new Matrix2d(1, 0, 0, 1); // Identity matrix - property type get 

        public Matrix2d Zero => new Matrix2d(0, 0, 0, 0); // Zero matrix - property type get

        public override string ToString() => $"[[{a}, {b}], [{c}, {d}]]";

        public bool Equals(Matrix2d other)
        {
            //throw new NotImplementedException();
            if (other is null) return false;

            return a == other.a && b == other.b && c == other.c && d == other.d;
        }

        public static bool operator == (Matrix2d left, Matrix2d right) => left.Equals(right);
        public static bool operator != (Matrix2d left, Matrix2d right) => !(left == right);
        
        // Addition
        public static Matrix2d operator +(Matrix2d left, Matrix2d right) => new Matrix2d(left.a + right.a, left.b + right.b, left.c + right.c, left.d + right.d);

        // Subtraction
        public static Matrix2d operator -(Matrix2d left, Matrix2d right) => new Matrix2d(left.a - right.a, left.b - right.b, left.c - right.c, left.d - right.d);

        // Matrix multiplication
        public static Matrix2d operator *(Matrix2d left, Matrix2d right) => new Matrix2d(left.a * right.a + left.b * right.c,
                                                                                         left.a * right.b + left.b * right.d,
                                                                                         left.c * right.a + left.d * right.c,
                                                                                         left.c * right.b + left.d * right.d);

        // Scalar multiplication
        public static Matrix2d operator *(int k, Matrix2d m) => new Matrix2d(k * m.a, k * m.b, k * m.c, k * m.d);
        public static Matrix2d operator *(Matrix2d m, int k) => k * m;

        // Negation
        public static Matrix2d operator -(Matrix2d m) => new Matrix2d(-m.a, -m.b, -m.c, -m.d);

        // Transpose
        public static Matrix2d Transpose(Matrix2d m) => new Matrix2d(m.a, m.c, m.b, m.d);

        // Determinant (static method)
        public static int Determinant(Matrix2d m) => (m.a * m.d) - (m.b * m.c);

        // Determinant (instance method)
        public int Det() => (a * d) - (b * c);

        // Explicit cast to int[2,2]
        public static explicit operator int[,](Matrix2d m) => new int[2, 2] { { m.a, m.b }, { m.c, m.d } };

        // Parse string to Matrix2d
        public static Matrix2d Parse(string s)
        {
            var match = Regex.Match(s, @"\[\[(\-?\d+), (\-?\d+)\], \[(\-?\d+), (\-?\d+)\]\]");
            if (!match.Success)
                throw new FormatException("Invalid matrix format. Expected format: [[a, b], [c, d]]");

            int a = int.Parse(match.Groups[1].Value);
            int b = int.Parse(match.Groups[2].Value);
            int c = int.Parse(match.Groups[3].Value);
            int d = int.Parse(match.Groups[4].Value);

            return new Matrix2d(a, b, c, d);
        }
    }
}
