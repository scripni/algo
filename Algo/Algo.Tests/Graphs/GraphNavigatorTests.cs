using Algo.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Algo.Tests.Graphs
{
    [TestClass]
    public class GraphNavigatorTests
    {
        [TestMethod]
        public void TopologicalSort_ValidGraph_SortsCorrectly()
        {
            // arrange
            GraphNode openDoor = new GraphNode("open door");
            GraphNode unlockCar = new GraphNode("unlock car");
            GraphNode getInCar = new GraphNode("get in car");
            GraphNode turnOnEngine = new GraphNode("turn on engine");
            GraphNode adjustMirrors = new GraphNode("adjust mirrors");
            GraphNode turnOnHeadlights = new GraphNode("turn on headlights");

            unlockCar.Paths.Add(openDoor);
            openDoor.Paths.Add(getInCar);
            getInCar.Paths.Add(adjustMirrors);
            getInCar.Paths.Add(turnOnHeadlights);
            adjustMirrors.Paths.Add(turnOnEngine);
            turnOnHeadlights.Paths.Add(turnOnEngine);

            GraphNode[] nodes = new GraphNode[] { adjustMirrors, turnOnHeadlights, openDoor, unlockCar, getInCar, turnOnEngine, };
            GraphNavigator navigator = new GraphNavigator();

            // act
            GraphNode[] topologicalSort = navigator.TopologicalSort(nodes).ToArray();

            // assert
            Assert.AreEqual(topologicalSort[0], unlockCar);
            Assert.AreEqual(topologicalSort[1], openDoor);
            Assert.AreEqual(topologicalSort[2], getInCar);
            Assert.IsTrue(topologicalSort[3] == adjustMirrors || topologicalSort[3] == turnOnHeadlights);
            Assert.IsTrue(topologicalSort[4] == adjustMirrors || topologicalSort[4] == turnOnHeadlights);
            Assert.AreEqual(topologicalSort[5], turnOnEngine);
            Assert.AreEqual(topologicalSort.Length, 6);
        }
    }
}
