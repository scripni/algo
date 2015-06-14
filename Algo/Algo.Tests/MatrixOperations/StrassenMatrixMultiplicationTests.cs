using Algo.MatrixOperations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests.MatrixOperations
{
	[TestClass]
	public class StrassenMatrixMultiplicationTests
	{
		[TestMethod]
		public void Constructor_TwoByTwo_IndicesReturnExpectedValues()
		{
			// arrange
			int[,] value = new int[,]
				{
					{2, 3},
					{4, 5},
				};

			// act
			SquareEvenMatrix a = new SquareEvenMatrix(value);

			// assert
			Assert.AreEqual(2, a[0, 0]);
			Assert.AreEqual(2, a.TopLeft[0, 0]);
			Assert.AreEqual(3, a[0, 1]);
			Assert.AreEqual(3, a.TopRight[0, 0]);
			Assert.AreEqual(4, a[1, 0]);
			Assert.AreEqual(4, a.BottomLeft[0, 0]);
			Assert.AreEqual(5, a[1, 1]);
			Assert.AreEqual(5, a.BottomRight[0, 0]);
		}


		[TestMethod]
		public void Multiply_FourByFour_ReturnsExpectedValue()
		{
			// arrange
			SquareEvenMatrix a = new SquareEvenMatrix(new int[,]
				{
					{2, 3, 4, 5, },
					{6, 7, 8 ,9, },
					{10, 11, 12, 13,},
					{14, 15, 16 ,17,},
				});

			SquareEvenMatrix b = new SquareEvenMatrix(new int[,]
				{
					{5, 4, 3, 2, },
					{6, 7, 8 ,9, },
					{10, 11, 12, 13,},
					{14, 15, 16 ,17,},
				});

			SquareEvenMatrix expected = new SquareEvenMatrix(new int[,]
				{
					{
						2 * 5 + 3 * 6 + 4 * 10 + 5 * 14,
						2 * 4 + 3 * 7 + 4 * 11 + 5 * 15,
						2 * 3 + 3 * 8 + 4 * 12 + 5 * 16,
						2 * 2 + 3 * 9 + 4 * 13 + 5 * 17,
					},
					{
						6 * 5 + 7 * 6 + 8 * 10 + 9 * 14,
						6 * 4 + 7 * 7 + 8 * 11 + 9 * 15,
						6 * 3 + 7 * 8 + 8 * 12 + 9 * 16,
						6 * 2 + 7 * 9 + 8 * 13 + 9 * 17,
					},
					{
						10 * 5 + 11 * 6 + 12 * 10 + 13 * 14,
						10 * 4 + 11 * 7 + 12 * 11 + 13 * 15,
						10 * 3 + 11 * 8 + 12 * 12 + 13 * 16,
						10 * 2 + 11 * 9 + 12 * 13 + 13 * 17,
					},
					{
						14 * 5 + 15 * 6 + 16 * 10 + 17 * 14,
						14 * 4 + 15 * 7 + 16 * 11 + 17 * 15,
						14 * 3 + 15 * 8 + 16 * 12 + 17 * 16,
						14 * 2 + 15 * 9 + 16 * 13 + 17 * 17,
					},
				});

			// act
			SquareEvenMatrix actual = a * b;

			// assert
			Assert.AreEqual(expected, actual);
		}


		[TestMethod]
		public void Multiply_UnitMatrices_ReturnsUnitMatrix()
		{
			// arrange
			SquareEvenMatrix a = new SquareEvenMatrix(new int[,] { { 2 } });
			SquareEvenMatrix b = new SquareEvenMatrix(new int[,] { { 3 } });

			// act
			SquareEvenMatrix c = a * b;

			// assert
			Assert.AreEqual(6, c[0, 0], "Multiplication should produce expected result.");
		}


		[TestMethod]
		public void Multiply_TwoByTwo_ReturnsExpectedResult()
		{
			// arrange
			SquareEvenMatrix a = new SquareEvenMatrix(new int[,]
				{
					{2, 3},
					{4, 5},
				});

			SquareEvenMatrix b = new SquareEvenMatrix(new int[,]
				{
					{3, 4},
					{5, 6},
				});

			// act
			SquareEvenMatrix actual = a * b;

			// assert
			Assert.AreEqual(2 * 3 + 3 * 5, actual[0, 0], "Multiplication should produce expected result.");
			Assert.AreEqual(2 * 4 + 3 * 6, actual[0, 1], "Multiplication should produce expected result.");
			Assert.AreEqual(4 * 3 + 5 * 5, actual[1, 0], "Multiplication should produce expected result.");
			Assert.AreEqual(4 * 4 + 5 * 6, actual[1, 1], "Multiplication should produce expected result.");
		}
	}
}
