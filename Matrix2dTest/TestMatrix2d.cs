using Matrix2dLib;

namespace Matrix2dTest
{
    [TestClass]
    public class TestMatrix2d
    {
        [TestMethod]
        public void Determinant_ShouldReturnCorrectValue()
        {
            var m = new Matrix2d(2, 1, 3, 2);
            Assert.AreEqual(1, m.Det());
        }

        [TestMethod]
        public void Matrix_Addition_ShouldWorkCorrectly()
        {
            var m1 = new Matrix2d(1, 2, 3, 4);
            var m2 = new Matrix2d(5, 6, 7, 8);
            var expected = new Matrix2d(6, 8, 10, 12);
            Assert.AreEqual(expected, m1 + m2);
        }

        [TestMethod]
        public void Matrix_Subtraction_ShouldWorkCorrectly()
        {
            var m1 = new Matrix2d(5, 6, 7, 8);
            var m2 = new Matrix2d(1, 2, 3, 4);
            var expected = new Matrix2d(4, 4, 4, 4);
            Assert.AreEqual(expected, m1 - m2);
        }

        [TestMethod]
        public void Matrix_Multiplication_ShouldWorkCorrectly()
        {
            var m1 = new Matrix2d(1, 2, 3, 4);
            var m2 = new Matrix2d(2, 0, 1, 2);
            var expected = new Matrix2d(4, 4, 10, 8);
            Assert.AreEqual(expected, m1 * m2);
        }

        [TestMethod]
        public void Matrix_ScalarMultiplication_Left_ShouldWorkCorrectly()
        {
            var m = new Matrix2d(1, 2, 3, 4);
            var expected = new Matrix2d(2, 4, 6, 8);
            Assert.AreEqual(expected, 2 * m);
        }

        [TestMethod]
        public void Matrix_ScalarMultiplication_Right_ShouldWorkCorrectly()
        {
            var m = new Matrix2d(1, 2, 3, 4);
            var expected = new Matrix2d(2, 4, 6, 8);
            Assert.AreEqual(expected, m * 2);
        }

        [TestMethod]
        public void Matrix_Negation_ShouldWorkCorrectly()
        {
            var m = new Matrix2d(1, -2, 3, -4);
            var expected = new Matrix2d(-1, 2, -3, 4);
            Assert.AreEqual(expected, -m);
        }

        [TestMethod]
        public void Parse_ShouldReturnCorrectMatrix()
        {
            var m = Matrix2d.Parse("[[2, 1], [3, 2]]");
            var expected = new Matrix2d(2, 1, 3, 2);
            Assert.AreEqual(expected, m);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Parse_ShouldThrowException_OnInvalidFormat()
        {
            Matrix2d.Parse("[[2, 1] [3, 2]]");
        }

        [TestMethod]
        public void ExplicitCast_ToIntArray_ShouldWorkCorrectly()
        {
            var m = new Matrix2d(2, 1, 3, 2);
            int[,] expected = { { 2, 1 }, { 3, 2 } };
            CollectionAssert.AreEqual(expected, (int[,])m);
        }
    }
}
