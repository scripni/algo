using Algo.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo.Tests.Graphs
{
    [TestClass]
    public class GraphSolverTests
    {
        [TestMethod]
        public void SolveMaze_ValidSolution_ReturnsCorrectPath()
        {
            // arrange
            int[,] maze = new int[,]
            {
                {0, 1, 1, 0, 0 },
                {0, 0, 1, 0, 1 },
                {1, 0, 0, 0, 1 },
                {2, 1, 1, 0, 0 },
                {0, 0, 0, 0, 1 },
            };
            string expected = "BRBRRBBLLLT";
            GraphSolver solver = new GraphSolver();

            // act
            string actual = solver.SolveMaze(maze);

            // assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ShortestPath_SingleSolution_SelectsCorrectSolution()
        {
            // arrange
            int[,] map = new int[,]
            {
                {0, 1, 1, 0, 0 },
                {0, 0, 1, 0, 1 },
                {1, 0, 0, 0, 1 },
                {2, 1, 1, 0, 0 },
                {0, 0, 0, 0, 1 },
            };
            string expected = "BRBRRBBLLLT";
            GraphSolver solver = new GraphSolver();

            // act
            string actual = solver.ShortestPath(map);

            // assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void ShortestPath_TwoSolutions_SelectsCorrectSolution()
        {
            // arrange
            int[,] map = new int[,]
            {
                {0, 1, 1, 0, 0 },
                {0, 0, 1, 0, 1 },
                {1, 0, 0, 0, 1 },
                {2, 0, 1, 0, 0 },
                {0, 0, 0, 0, 1 },
            };
            string expected = "BRBBL";
            GraphSolver solver = new GraphSolver();

            // act
            string actual = solver.ShortestPath(map);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}

