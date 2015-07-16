using Algo.Graphs;
using Algo.Tests.Properties;
using Algo.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algo.Tests.Graphs
{
    [TestClass]
    public class DijkstraShortestPathTests
    {
        [TestMethod]
        public void ShortestPath_AdjacentNodes_FindsPath()
        {
            // arrange
            HashSet<int> v = new HashSet<int>();
            Dictionary<int, Dictionary<int, double>> e = new Dictionary<int, Dictionary<int, double>>();
            v.Add(1);
            v.Add(2);
            e[1] = new Dictionary<int, double>();
            e[2] = new Dictionary<int, double>();
            e[1][2] = e[2][1] = 1;
            DijkstraShortestPath d = new DijkstraShortestPath(v, e);

            // act
            // assert
            Assert.AreEqual(1, d.ShortestPath(1, 2));
        }

        [TestMethod]
        public void ShortestPath_ConsecutiveNodesSinglePathSameWeight_FindsPath()
        {
            // arrange
            HashSet<int> v = new HashSet<int>();
            Dictionary<int, Dictionary<int, double>> e = new Dictionary<int, Dictionary<int, double>>();
            v.Add(1);
            v.Add(2);
            v.Add(3);
            e[1] = new Dictionary<int, double>();
            e[2] = new Dictionary<int, double>();
            e[3] = new Dictionary<int, double>();
            e[1][2] = e[2][1] = e[3][2] = e[2][3] = 1;
            DijkstraShortestPath d = new DijkstraShortestPath(v, e);

            // act
            // assert
            Assert.AreEqual(2, d.ShortestPath(1, 3));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShortestPath_KeysNotInGraph_ThrowsException()
        {
            // arrange
            HashSet<int> v = new HashSet<int>();
            Dictionary<int, Dictionary<int, double>> e = new Dictionary<int, Dictionary<int, double>>();
            v.Add(1);
            v.Add(2);
            v.Add(3);
            e[1] = new Dictionary<int, double>();
            e[2] = new Dictionary<int, double>();
            e[3] = new Dictionary<int, double>();
            e[1][2] = e[2][1] = e[3][2] = e[2][3] = 1;
            DijkstraShortestPath d = new DijkstraShortestPath(v, e);

            // act
            // assert
            Assert.AreEqual(double.MaxValue, d.ShortestPath(1, 4));
        }

        [TestMethod]
        public void ShortestPath_NodesNotConnected_ReturnsNotFound()
        {
            // arrange
            HashSet<int> v = new HashSet<int>();
            Dictionary<int, Dictionary<int, double>> e = new Dictionary<int, Dictionary<int, double>>();
            v.Add(1);
            v.Add(2);
            v.Add(3);
            v.Add(4);
            e[1] = new Dictionary<int, double>();
            e[2] = new Dictionary<int, double>();
            e[3] = new Dictionary<int, double>();
            e[4] = new Dictionary<int, double>();
            e[1][2] = e[2][1] = 1;
            e[3][4] = e[4][3] = 1;
            DijkstraShortestPath d = new DijkstraShortestPath(v, e);

            // act
            // assert
            Assert.AreEqual(double.MaxValue, d.ShortestPath(1, 4));
        }

        [TestMethod]
        public void ShortestPath_ShorterPathIsMoreNodes_ReturnsNotFound()
        {
            // arrange
            HashSet<int> v = new HashSet<int>();
            v.Add(1);
            v.Add(2);
            v.Add(3);
            v.Add(4);

            Dictionary<int, Dictionary<int, double>> e = new Dictionary<int, Dictionary<int, double>>();
            e[1] = new Dictionary<int, double>();
            e[2] = new Dictionary<int, double>();
            e[3] = new Dictionary<int, double>();
            e[4] = new Dictionary<int, double>();

            e[1][2] = e[2][1] = 1;
            e[1][4] = e[4][1] = 7;
            e[2][3] = e[3][2] = 2;
            e[3][4] = e[4][3] = 3;

            DijkstraShortestPath d = new DijkstraShortestPath(v, e);

            // act
            // assert
            Assert.AreEqual(6, d.ShortestPath(1, 4));
        }

        [TestMethod]
        [TestCategory("Performance")]
        public void ShortestPath_LargeDataSet_RunsInExpectedTime()
        {
            // arrange
            RoadNetworkParser parser = new RoadNetworkParser(Resources.WashingtonRoadNetwork);
            DijkstraShortestPath d = new DijkstraShortestPath(parser.Vertices, parser.Edges);
            Stopwatch s = Stopwatch.StartNew();

            // act
            double distance = d.ShortestPath(456458, 456399);

            // assert
            Assert.IsTrue(s.Elapsed < TimeSpan.FromSeconds(10));
            Assert.IsTrue(distance < double.MaxValue);
        }
    }
}
