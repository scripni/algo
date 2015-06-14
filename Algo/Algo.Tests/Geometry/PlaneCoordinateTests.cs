using System;
using Algo.Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests.Geometry
{
	[TestClass]
	public class PlaneCoordinateTests
	{
		[TestMethod]
		public void Distance_SameXY_ReturnsExpected()
		{
			// arrange
			PlaneCoordinate a = new PlaneCoordinate(1, 1);
			PlaneCoordinate b = new PlaneCoordinate(2, 2);
			double expected = Math.Sqrt(2);

			// act
			double actual = a.Distance(b);

			// assert
			Assert.AreEqual(expected, actual);
		}


		[TestMethod]
		public void Distance_DifferentXY_ReturnsExpected()
		{
			// arrange
			PlaneCoordinate a = new PlaneCoordinate(0, 0);
			PlaneCoordinate b = new PlaneCoordinate(3, 4);
			double expected = 5;

			// act
			double actual = a.Distance(b);

			// assert
			Assert.AreEqual(expected, actual);
		}


		[TestMethod]
		public void Distance_SamePoint_ReturnsZero()
		{
			// arrange
			PlaneCoordinate a = new PlaneCoordinate(1, 1);
			PlaneCoordinate b = new PlaneCoordinate(1, 1);

			// act
			double actual = a.Distance(b);

			// assert
			Assert.AreEqual(0, actual);
		}
	}
}
