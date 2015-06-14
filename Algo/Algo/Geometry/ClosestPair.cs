using System;

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
