using System;

namespace Algo.Geometry
{
	/// <summary>
	/// X/Y coordinate.
	/// </summary>
	public struct PlaneCoordinate : IEquatable<PlaneCoordinate>
	{
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="x">X coordinate.</param>
		/// <param name="y">Y coordinate.</param>
		public PlaneCoordinate(double x, double y)
		{
			X = x;
			Y = y;
		}


		/// <summary>
		/// X coordinate.
		/// </summary>
		public double X;


		/// <summary>
		/// Y coordinate.
		/// </summary>
		public double Y;


		/// <summary>
		/// Computes the distance between points.
		/// </summary>
		/// <param name="other">Point to compute distance to.</param>
		/// <returns>Distance.</returns>
		public double Distance(PlaneCoordinate other)
		{
			double x = X - other.X;
			double y = Y - other.Y;
			return Math.Sqrt(x * x + y * y);
		}


		/// <summary>
		/// Compares for equality.
		/// </summary>
		/// <param name="x">First operand.</param>
		/// <param name="y">Second operand.</param>
		/// <returns>Equality status.</returns>
		public static bool operator ==(PlaneCoordinate x, PlaneCoordinate y)
		{
			return x.Equals(y);
		}


		/// <summary>
		/// Compares for difference.
		/// </summary>
		/// <param name="x">First operand.</param>
		/// <param name="y">Second operand.</param>
		/// <returns>Difference status.</returns>
		public static bool operator !=(PlaneCoordinate x, PlaneCoordinate y)
		{
			return !x.Equals(y);
		}


		/// <summary>
		/// Compares for equality.
		/// </summary>
		/// <param name="obj">Other operand.</param>
		/// <returns>Equality status.</returns>
		public override bool Equals(object obj)
		{
			if (obj is PlaneCoordinate)
			{
				return Equals((PlaneCoordinate)obj);
			}

			return false;
		}


		/// <summary>
		/// Compares for equality.
		/// </summary>
		/// <param name="other">Other operand.</param>
		/// <returns>Equality status.</returns>
		public bool Equals(PlaneCoordinate other)
		{
			return X == other.X && Y == other.Y;
		}

		public override int GetHashCode()
		{
			return X.GetHashCode() ^ Y.GetHashCode();
		}
	}
}
