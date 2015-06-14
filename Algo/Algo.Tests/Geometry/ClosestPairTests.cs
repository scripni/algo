using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algo.Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests.Geometry
{
	[TestClass]
	public class ClosestPairTests
	{
		[TestMethod]
		public void FindClosestPair_TwoPoints_ReturnsExpected()
		{
			// arrange
			PlaneCoordinate x = new PlaneCoordinate(0, 0);
			PlaneCoordinate y = new PlaneCoordinate(0, 1);
			ClosestPair algorithm = new ClosestPair();

			// act
			Tuple<PlaneCoordinate, PlaneCoordinate> closestPair = algorithm.FindClosestPair(new[] { x, y });

			// assert
			Assert.AreEqual(closestPair.Item1, x);
			Assert.AreEqual(closestPair.Item2, y);
		}


		[TestMethod]
		public void FindClosestPair_ThreePoints_ReturnsExpected()
		{
			// arrange
			PlaneCoordinate x = new PlaneCoordinate(0, 0);
			PlaneCoordinate y = new PlaneCoordinate(0, 1);
			PlaneCoordinate z = new PlaneCoordinate(0, 1.5);
			ClosestPair algorithm = new ClosestPair();

			// act
			Tuple<PlaneCoordinate, PlaneCoordinate> closestPair = algorithm.FindClosestPair(new[] { x, y, z });

			// assert
			Assert.AreEqual(closestPair.Item1, y);
			Assert.AreEqual(closestPair.Item2, z);
		}


		[TestMethod]
		public void FindClosestPair_AllAxesDifferent_ReturnsExpected()
		{
			// arrange
			PlaneCoordinate x = new PlaneCoordinate(0, 1);
			PlaneCoordinate y = new PlaneCoordinate(1, 5);
			PlaneCoordinate z = new PlaneCoordinate(4, -10);
			ClosestPair algorithm = new ClosestPair();

			// act
			Tuple<PlaneCoordinate, PlaneCoordinate> closestPair = algorithm.FindClosestPair(new[] { x, y, z });

			// assert
			Assert.AreEqual(closestPair.Item1, x);
			Assert.AreEqual(closestPair.Item2, y);
		}
	}
}
