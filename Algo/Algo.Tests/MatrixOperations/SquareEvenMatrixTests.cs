using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algo.MatrixOperations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests.MatrixOperations
{
	[TestClass]
	public class SquareEvenMatrixTests
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
	}
}
