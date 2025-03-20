using System.Text.RegularExpressions;

namespace Matrix2dLib
{
    public class Matrix2dArray : IEquatable<Matrix2dArray>
    {
        //int[,] array;
        private readonly int[,] array = new int[2,2];

        public Matrix2dArray(int a, int b, int c, int d)
        {
            array[0, 0] = a;
            array[0, 1] = b;
            array[1, 0] = c;
            array[1, 1] = d;
        }

        public Matrix2dArray() : this(1, 0, 0, 1) { }

        public Matrix2dArray Id => new Matrix2dArray(1, 0, 0, 1);

        public Matrix2dArray Zero => new Matrix2dArray(0, 0, 0, 0);

        public override string ToString() => $"[[{array[0, 0]}, {array[0, 1]}], [{array[1, 0]}, {array[1, 1]}]]";

        public bool Equals(Matrix2dArray? other)
        {
            //throw new NotImplementedException();
            if (other is null) return false;

            return array[0, 0] == other.array[0, 0] && array[0, 1] == other.array[0, 1] && array[1, 0] == other.array[1, 0] && array[1, 1] == other.array[1, 1];
        }

        public static bool operator ==(Matrix2dArray left, Matrix2dArray right) => left.Equals(right);
        public static bool operator !=(Matrix2dArray left, Matrix2dArray right) => !(left == right);

        // Add
        public static Matrix2dArray operator +(Matrix2dArray left, Matrix2dArray right) => new Matrix2dArray(left.array[0, 0] + right.array[0, 0], 
                                                                                                            left.array[0, 1] + right.array[0, 1], 
                                                                                                            left.array[1, 0] + right.array[1, 0], 
                                                                                                            left.array[1, 1] + right.array[1, 1]);

        // Minus
        public static Matrix2dArray operator -(Matrix2dArray left, Matrix2dArray right) => new Matrix2dArray(left.array[0, 0] - right.array[0, 0], 
                                                                                                            left.array[0, 1] - right.array[0, 1], 
                                                                                                            left.array[1, 0] - right.array[1, 0], 
                                                                                                            left.array[1, 1] - right.array[1, 1]);

        // Multiple
        public static Matrix2dArray operator *(Matrix2dArray left, Matrix2dArray right) => new Matrix2dArray(left.array[0, 0] * right.array[0, 0] + left.array[0, 1] * right.array[1, 0],
                                                                                                            left.array[0, 0] * right.array[0, 1] + left.array[0, 1] * right.array[1, 1],
                                                                                                            left.array[1, 0] * right.array[0, 0] + left.array[1, 1] * right.array[1, 0],
                                                                                                            left.array[1, 0] * right.array[0, 1] + left.array[1, 1] * right.array[1, 1]);

        // Multiple by number
        public static Matrix2dArray operator *(int k, Matrix2dArray m) => new Matrix2dArray(k * m.array[0, 0], k * m.array[0, 1], k * m.array[1, 0], k * m.array[1, 1]);
        public static Matrix2dArray operator *(Matrix2dArray m, int k) => k * m;

        public static Matrix2dArray operator -(Matrix2dArray m) => new Matrix2dArray(-m.array[0, 0], -m.array[0, 1], -m.array[1, 0], -m.array[1, 1]);

        public static Matrix2dArray Transpose(Matrix2dArray m) => new Matrix2dArray(m.array[0, 0], m.array[1, 0], m.array[0, 1], m.array[1, 1]);

        public int Det() => array[0, 0] * array[1, 1] - array[0, 1] * array[1, 0];

        public static int Determinant(Matrix2dArray m) => m.Det();

        public static explicit operator int[,](Matrix2dArray m) =>
            new int[,] { { m.array[0, 0], m.array[0, 1] }, { m.array[1, 0], m.array[1, 1] } };

        public static Matrix2dArray Parse(string s)
        {
            var regex = new Regex(@"\[\[(\d+),\s*(\d+)\],\s*\[(\d+),\s*(\d+)\]\]");
            var match = regex.Match(s);
            if (!match.Success) throw new FormatException("Invalid matrix format.");

            return new Matrix2dArray(
                int.Parse(match.Groups[1].Value),
                int.Parse(match.Groups[2].Value),
                int.Parse(match.Groups[3].Value),
                int.Parse(match.Groups[4].Value));
        }
    }

    
}
