using Matrix2dLib;

Matrix2d m = new Matrix2d();
Console.WriteLine(m);

Matrix2d m1 = new Matrix2d(1, 2, 3, 4);
Console.WriteLine(m1);

Matrix2d m2 = Matrix2d.Transpose(m1);

var m3 = (int[,])m2;