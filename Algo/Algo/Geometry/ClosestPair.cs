using System;
using System.Linq;
using Algo.Sorting;

namespace Algo.Geometry
{
	/// <summary>
	/// Closest pair algorithm.
	/// </summary>
	public class ClosestPair
	{
		/// <summary>
		/// Finds the closest pair in a set of coordinates.
		/// </summary>
		/// <param name="coordinates">The coordinates.</param>
		/// <returns>Closest pair.</returns>
		public Tuple<PlaneCoordinate, PlaneCoordinate> FindClosestPair(
			PlaneCoordinate[] coordinates)
		{
			return BruteForceClosestPair(coordinates);
		}


		private static Tuple<PlaneCoordinate, PlaneCoordinate> DivideConquerClosestPair(PlaneCoordinate[] coordinates)
		{
			// sort by x and y
			Sorter<double> mergeSort = new MergeSort<double>();
			double[] px = mergeSort.Sort(coordinates.Select(p => p.X).ToArray());
			double[] py = mergeSort.Sort(coordinates.Select(p => p.Y).ToArray());

			return FindClosestPair(px, py);
		}


		private static Tuple<PlaneCoordinate, PlaneCoordinate> FindClosestPair(double[] px, double[] py)
		{
			if (px.Length == 2)
			{
				return new Tuple<PlaneCoordinate, PlaneCoordinate>(new PlaneCoordinate(px[0], py[0]),
					new PlaneCoordinate(px[1], py[1]));
			}

			double minDistance;

			if (px.Length == 3)
			{
				PlaneCoordinate a = new PlaneCoordinate(px[0], py[0]);
				PlaneCoordinate b = new PlaneCoordinate(px[1], py[1]);
				PlaneCoordinate c = new PlaneCoordinate(px[2], py[2]);

				double ab = a.Distance(b);
				double ac = a.Distance(c);
				double bc = b.Distance(c);

				minDistance = Math.Min(ab, Math.Min(ac, bc));

				if (minDistance == ab)
				{
					return new Tuple<PlaneCoordinate, PlaneCoordinate>(a, b);
				}

				if (minDistance == ac)
				{
					return new Tuple<PlaneCoordinate, PlaneCoordinate>(a, c);
				}

				return new Tuple<PlaneCoordinate, PlaneCoordinate>(b, c);
			}

			// divide
			int middle = px.Length / 2;

			// left
			double[] qpx = new double[middle];
			Array.Copy(px, qpx, qpx.Length);
			double[] qpy = new double[middle];
			Array.Copy(py, qpy, qpy.Length);

			// right
			double[] rpx = new double[px.Length - middle];
			Array.Copy(px, middle, rpx, 0, rpx.Length);
			double[] rpy = new double[px.Length - middle];
			Array.Copy(py, middle, rpy, 0, rpy.Length);

			// conquer
			Tuple<PlaneCoordinate, PlaneCoordinate> p1q1 = FindClosestPair(qpx, qpy);
			double dist1 = p1q1.Item1.Distance(p1q1.Item2);
			Tuple<PlaneCoordinate, PlaneCoordinate> p2q2 = FindClosestPair(rpx, rpy);
			double dist2 = p2q2.Item1.Distance(p2q2.Item2);

			minDistance = Math.Min(dist1, dist2);
			Tuple<PlaneCoordinate, PlaneCoordinate> p3q3 = ClosestPairSplit(px, py, minDistance);
			double dist3 = p3q3.Item1.Distance(p3q3.Item2);

			minDistance = Math.Min(minDistance, dist3);

			if (minDistance == dist1)
			{
				return p1q1;
			}

			if (minDistance == dist2)
			{
				return p2q2;
			}

			return p3q3;
		}

		private static Tuple<PlaneCoordinate, PlaneCoordinate> ClosestPairSplit(double[] px, double[] py, double minDistance)
		{
			throw new NotImplementedException();
		}


		/// <summary>
		/// Brute-force closest pair implementation.
		/// </summary>
		/// <param name="coordinates">The coordinates.</param>
		/// <returns>Closest pair.</returns>
		private static Tuple<PlaneCoordinate, PlaneCoordinate> BruteForceClosestPair(PlaneCoordinate[] coordinates)
		{
			if (coordinates == null)
			{
				throw new ArgumentNullException("coordinates");
			}

			if (coordinates.Length < 2)
			{
				throw new ArgumentException("At least two points must be passed.", "coordinates");
			}

			double minDistance = double.MaxValue;
			int minI = -1, minJ = -1;
			for (int i = 0; i < coordinates.Length; i++)
			{
				for (int j = i; j < coordinates.Length; j++)
				{
					if (i == j)
					{
						continue;
					}

					double distance = coordinates[i].Distance(coordinates[j]);
					if (distance < minDistance)
					{
						minI = i;
						minJ = j;
						minDistance = distance;
					}
				}
			}

			return new Tuple<PlaneCoordinate, PlaneCoordinate>(
				coordinates[minI], coordinates[minJ]);
		}
	}
}
