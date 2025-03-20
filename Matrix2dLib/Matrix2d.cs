#nullable disable
using System;

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

        // construcotr
        public Matrix2d(int a, int b, int c, int d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public Matrix2d() : this(1, 0, 0, 1) { }

        public Matrix2d Id => new Matrix2d(1, 0, 0, 1); // property type get 

        public Matrix2d Zero => new Matrix2d(0, 0, 0, 0); // property type get

        public override string ToString() => $"[[{a}, {b}], [{c}, {d}]]";

        public bool Equals(Matrix2d other)
        {
            //throw new NotImplementedException();
            if (other is null) return false;

            return a == other.a && b == other.b && c == other.c && d == other.d;
        }

        public static bool operator == (Matrix2d left, Matrix2d right) => left.Equals(right);
        public static bool operator != (Matrix2d left, Matrix2d right) => !(left == right);

        // Add
        public static Matrix2d operator +(Matrix2d left, Matrix2d right) => new Matrix2d(left.a + right.a, left.b + right.b, left.c + right.c, left.d + right.d);

        // Minus
        public static Matrix2d operator -(Matrix2d left, Matrix2d right) => new Matrix2d(left.a - right.a, left.b - right.b, left.c - right.c, left.d - right.d);

        // Multiple
        public static Matrix2d operator *(Matrix2d left, Matrix2d right) => new Matrix2d(left.a * right.a - left.b * right.c,
                                                                                         left.a * right.b - left.b * right.d,
                                                                                         left.c * right.a - left.d * right.c,
                                                                                         left.c * right.b - left.d * right.d);
        
        // Multiple by number
        public static Matrix2d operator *(int k, Matrix2d m) => new Matrix2d(k * m.a, k * m.b, k * m.c, k * m.d);
        public static Matrix2d operator *(Matrix2d m, int k) => k * m;

        public static Matrix2d Transpose(Matrix2d m) => new Matrix2d(m.a, m.c, m.b, m.d);

        // change to int [2,2]
        public static explicit operator int[,](Matrix2d m) => new int[2, 2] { { m.a, m.b }, { m.c, m.d } };


    }
}
