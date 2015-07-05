using System.Collections.Generic;
using System.Text;

namespace Algo.Graphs
{
    public class GraphSolver
    {
        public string SolveMaze(int[,] maze)
        {
            StringBuilder solution = new StringBuilder();
            int[,] visited = new int[maze.GetLength(0), maze.GetLength(1)];

            if (SolveMaze(maze, 0, 0, visited, solution))
            {
                return solution.ToString();
            }

            return null;
        }

        private bool SolveMaze(int[,] maze, int x, int y, int[,] visited, StringBuilder solution)
        {
            // mark as visited
            visited[x, y] = 1;

            // solution
            if (maze[x, y] == 2)
            {
                return true;
            }

            // bottom
            if (x < maze.GetLength(0) - 1 && maze[x + 1, y] % 2 == 0 && visited[x + 1, y] == 0)
            {
                solution.Append('B');

                if (SolveMaze(maze, x + 1, y, visited, solution))
                {
                    return true;
                }

                solution.Length--;
            }

            // right
            if (y < maze.GetLength(1) - 1 && maze[x, y + 1] % 2 == 0 && visited[x, y + 1] == 0)
            {
                solution.Append('R');

                if (SolveMaze(maze, x, y + 1, visited, solution))
                {
                    return true;
                }

                solution.Length--;
            }

            // top
            if (x > 0 && maze[x - 1, y] % 2 == 0 && visited[x - 1, y] == 0)
            {
                solution.Append('T');

                if (SolveMaze(maze, x - 1, y, visited, solution))
                {
                    return true;
                }

                solution.Length--;
            }

            // left
            if (y > 0 && maze[x, y - 1] % 2 == 0 && visited[x, y - 1] == 0)
            {
                solution.Append('L');

                if (SolveMaze(maze, x, y - 1, visited, solution))
                {
                    return true;
                }

                solution.Length--;
            }

            return false;
        }


        public string ShortestPath(int[,] map)
        {
            Queue<Coordinate> coordinates = new Queue<Coordinate>();
            int[,] visited = new int[map.GetLength(0), map.GetLength(1)];

            Coordinate start = new Coordinate(0, 0, string.Empty);
            coordinates.Enqueue(start);

            while (coordinates.Count > 0)
            {
                Coordinate current = coordinates.Dequeue();

                // visit
                visited[current.X, current.Y] = 1;
                if (map[current.X, current.Y] == 2) return current.Path;

                // right
                if (current.Y < map.GetLength(1) - 1 && map[current.X, current.Y + 1] % 2 == 0 && visited[current.X, current.Y + 1] == 0)
                {
                    coordinates.Enqueue(new Coordinate(current.X, current.Y + 1, current.Path + "R"));
                }

                // bottom
                if (current.X < map.GetLength(1) - 1 && map[current.X + 1, current.Y] % 2 == 0 && visited[current.X + 1, current.Y] == 0)
                {
                    coordinates.Enqueue(new Coordinate(current.X + 1, current.Y, current.Path + "B"));
                }

                // left
                if (current.Y > 0 && map[current.X, current.Y - 1] % 2 == 0 && visited[current.X, current.Y - 1] == 0)
                {
                    coordinates.Enqueue(new Coordinate(current.X, current.Y - 1, current.Path + "L"));
                }

                // top
                if (current.X > 0 && map[current.X - 1, current.Y] % 2 == 0 && visited[current.X - 1, current.Y] == 0)
                {
                    coordinates.Enqueue(new Coordinate(current.X - 1, current.Y, current.Path + "T"));
                }
            }

            return null;
        }

        private struct Coordinate
        {
            public Coordinate(int x, int y, string path)
            {
                X = x;
                Y = y;
                Path = path;
            }

            public int X;
            public int Y;
            public string Path;
        }
    }
}
