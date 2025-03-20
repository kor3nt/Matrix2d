using Matrix2dLib;

namespace Matrix2dTest
{
    [TestClass]
    public class TestMatrix2dArray
    {
        [TestMethod]
        public void Constructor_ShouldInitializeCorrectly()
        {
            var matrix = new Matrix2dArray(1, 2, 3, 4);
            Assert.AreEqual("[[1, 2], [3, 4]]", matrix.ToString());
        }

        [TestMethod]
        public void DefaultConstructor_ShouldInitializeIdentityMatrix()
        {
            var matrix = new Matrix2dArray();
            Assert.AreEqual("[[1, 0], [0, 1]]", matrix.ToString());
        }

        [TestMethod]
        public void StaticProperties_ShouldReturnCorrectMatrices()
        {
            Assert.AreEqual("[[1, 0], [0, 1]]", new Matrix2dArray().Id.ToString());
            Assert.AreEqual("[[0, 0], [0, 0]]", new Matrix2dArray().Zero.ToString());
        }

        [TestMethod]
        public void AdditionOperator_ShouldAddMatricesCorrectly()
        {
            var a = new Matrix2dArray(1, 2, 3, 4);
            var b = new Matrix2dArray(5, 6, 7, 8);
            var result = a + b;
            Assert.AreEqual("[[6, 8], [10, 12]]", result.ToString());
        }

        [TestMethod]
        public void SubtractionOperator_ShouldSubtractMatricesCorrectly()
        {
            var a = new Matrix2dArray(5, 6, 7, 8);
            var b = new Matrix2dArray(1, 2, 3, 4);
            var result = a - b;
            Assert.AreEqual("[[4, 4], [4, 4]]", result.ToString());
        }

        [TestMethod]
        public void MultiplicationOperator_ShouldMultiplyMatricesCorrectly()
        {
            var a = new Matrix2dArray(1, 2, 3, 4);
            var b = new Matrix2dArray(2, 0, 1, 2);
            var result = a * b;
            Assert.AreEqual("[[4, 4], [10, 8]]", result.ToString());
        }

        [TestMethod]
        public void ScalarMultiplication_ShouldMultiplyByScalarCorrectly()
        {
            var matrix = new Matrix2dArray(1, 2, 3, 4);
            var result = 2 * matrix;
            Assert.AreEqual("[[2, 4], [6, 8]]", result.ToString());
        }

        [TestMethod]
        public void NegationOperator_ShouldNegateMatrixCorrectly()
        {
            var matrix = new Matrix2dArray(1, -2, 3, -4);
            var result = -matrix;
            Assert.AreEqual("[[-1, 2], [-3, 4]]", result.ToString());
        }

        [TestMethod]
        public void Transpose_ShouldTransposeMatrixCorrectly()
        {
            var matrix = new Matrix2dArray(1, 2, 3, 4);
            var transposed = Matrix2dArray.Transpose(matrix);
            Assert.AreEqual("[[1, 3], [2, 4]]", transposed.ToString());
        }

        [TestMethod]
        public void Determinant_ShouldReturnCorrectValue()
        {
            var matrix = new Matrix2dArray(1, 2, 3, 4);
            Assert.AreEqual(-2, matrix.Det());
        }

        [TestMethod]
        public void ExplicitCast_ShouldConvertToArrayCorrectly()
        {
            var matrix = new Matrix2dArray(1, 2, 3, 4);
            int[,] array = (int[,])matrix;
            Assert.AreEqual(1, array[0, 0]);
            Assert.AreEqual(2, array[0, 1]);
            Assert.AreEqual(3, array[1, 0]);
            Assert.AreEqual(4, array[1, 1]);
        }

        [TestMethod]
        public void Parse_ShouldCreateMatrixFromString()
        {
            var matrix = Matrix2dArray.Parse("[[1, 2], [3, 4]]");
            Assert.AreEqual("[[1, 2], [3, 4]]", matrix.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Parse_InvalidString_ShouldThrowException()
        {
            Matrix2dArray.Parse("invalid");
        }
    }
}
