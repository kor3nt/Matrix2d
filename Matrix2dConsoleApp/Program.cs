using Matrix2dLib;

Console.WriteLine("\n===============");
Console.WriteLine("Matrix2d:");
Console.WriteLine("===============");

var m1 = new Matrix2d(2, 1, 3, 2);
var m2 = new Matrix2d(1, 2, 3, 4);

Console.WriteLine("Macierz 1:");
Console.WriteLine(m1);
Console.WriteLine("Macierz 2:");
Console.WriteLine(m2);

Console.WriteLine("Dodawanie:");
Console.WriteLine(m1 + m2);

Console.WriteLine("Odejmowanie:");
Console.WriteLine(m1 - m2);

Console.WriteLine("Mnożenie macierzy:");
Console.WriteLine(m1 * m2);

Console.WriteLine("Mnożenie przez skalar (3 * macierz):");
Console.WriteLine(3 * m1);

Console.WriteLine("Wyznacznik macierzy 1:");
Console.WriteLine(m1.Det());

Console.WriteLine("Konwersja na tablicę int[2,2]:");
int[,] array = (int[,])m1;
Console.WriteLine($"[[{array[0, 0]}, {array[0, 1]}], [{array[1, 0]}, {array[1, 1]}]]");

Console.WriteLine("Parsowanie macierzy ze stringa:");
var parsed = Matrix2d.Parse("[[5, 6], [7, 8]]");
Console.WriteLine(parsed);

Console.WriteLine("\n===============");
Console.WriteLine("Matrix2d Array:");
Console.WriteLine("===============");

var m1array = new Matrix2dArray(2, 1, 3, 2);
var m2array = new Matrix2dArray(1, 2, 3, 4);

Console.WriteLine("Macierz 1:");
Console.WriteLine(m1array);
Console.WriteLine("Macierz 2:");
Console.WriteLine(m2array);

Console.WriteLine("Dodawanie:");
Console.WriteLine(m1array + m2array);

Console.WriteLine("Odejmowanie:");
Console.WriteLine(m1array - m2array);

Console.WriteLine("Mnożenie macierzy:");
Console.WriteLine(m1array * m2array);

Console.WriteLine("Mnożenie przez skalar (3 * macierz):");
Console.WriteLine(3 * m1array);

Console.WriteLine("Wyznacznik macierzy 1:");
Console.WriteLine(m1array.Det());

Console.WriteLine("Konwersja na tablicę int[2,2]:");
int[,] array1 = (int[,])m1array;
Console.WriteLine($"[[{array1[0, 0]}, {array1[0, 1]}], [{array1[1, 0]}, {array1[1, 1]}]]");

Console.WriteLine("Parsowanie macierzy ze stringa:");
var parsed1 = Matrix2dArray.Parse("[[5, 6], [7, 8]]");
Console.WriteLine(parsed1);