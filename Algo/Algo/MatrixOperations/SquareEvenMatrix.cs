using System;
using System.Text;

namespace Algo.MatrixOperations
{
	/// <summary>
	/// N by N matrix where N is an even number, with addition and multiplication support.
	/// </summary>
	public class SquareEvenMatrix : IEquatable<SquareEvenMatrix>
	{
		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="topLeft">Top left submatrix.</param>
		/// <param name="topRight">Top right submatrix.</param>
		/// <param name="bottomLeft">Bottom left submatrix.</param>
		/// <param name="bottomRight">Bottom right submatrix.</param>
		public SquareEvenMatrix(SquareEvenMatrix topLeft, SquareEvenMatrix topRight,
								SquareEvenMatrix bottomLeft, SquareEvenMatrix bottomRight)
		{
			if (topLeft == null)
			{
				throw new ArgumentNullException("topLeft");
			}

			if (topRight == null)
			{
				throw new ArgumentNullException("topRight");
			}

			if (bottomLeft == null)
			{
				throw new ArgumentNullException("bottomLeft");
			}

			if (bottomRight == null)
			{
				throw new ArgumentNullException("bottomRight");
			}

			if (topLeft.Size != topRight.Size)
			{
				throw new ArgumentException("Submatrices must have same size.", "topRight");
			}

			if (topLeft.Size != bottomLeft.Size)
			{
				throw new ArgumentException("Submatrices must have same size.", "bottomLeft");
			}

			if (topLeft.Size != bottomRight.Size)
			{
				throw new ArgumentException("Submatrices must have same size.", "bottomRight");
			}

			TopLeft = topLeft;
			TopRight = topRight;
			BottomLeft = bottomLeft;
			BottomRight = bottomRight;
			Size = topLeft.Size * 2;
			Half = topLeft.Size;
		}


		/// <summary>
		/// Creates a new blank matrix.
		/// </summary>
		/// <param name="size">The size of the matrix.</param>
		public SquareEvenMatrix(int size)
			: this(new int[size, size])
		{
		}

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="a">Internal matrix.</param>
		public SquareEvenMatrix(int[,] a)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}

			Size = a.GetLength(0);

			if (Size != a.GetLength(1))
			{
				throw new ArgumentException("Array must be square.", "a");
			}

			if (Size == 1)
			{
				// unit matrix
				Value = a[0, 0];
				return;
			}

			if (Size % 2 != 0)
			{
				throw new ArgumentException("No idea how to solve this for odd number of columns.", "a");
			}

			Half = Size / 2;

			TopLeft = new SquareEvenMatrix(Half);
			TopRight = new SquareEvenMatrix(Half);
			BottomLeft = new SquareEvenMatrix(Half);
			BottomRight = new SquareEvenMatrix(Half);

			for (int row = 0; row < Size; row++)
			{
				for (int column = 0; column < Size; column++)
				{
					this[row, column] = a[row, column];
				}
			}
		}


		/// <summary>
		/// Gets the matrix size.
		/// </summary>
		public int Size { get; private set; }


		/// <summary>
		/// Gets the top-left submatrix.
		/// </summary>
		public SquareEvenMatrix TopLeft { get; private set; }


		/// <summary>
		/// Gets the top-right submatrix.
		/// </summary>
		public SquareEvenMatrix TopRight { get; private set; }


		/// <summary>
		/// Gets the bottom-left submatrix.
		/// </summary>
		public SquareEvenMatrix BottomLeft { get; private set; }


		/// <summary>
		/// Gets the bottom-right submatrix.
		/// </summary>
		public SquareEvenMatrix BottomRight { get; private set; }


		/// <summary>
		/// Value for a unit matrix.
		/// </summary>
		private int Value { get; set; }


		/// <summary>
		/// Stores the half-size of the matrix, used in most computations.
		/// </summary>
		private int Half { get; set; }


		/// <summary>
		/// Gets the value at the specified <paramref name="row"/> and <paramref name="column"/>.
		/// </summary>
		/// <param name="row">The row.</param>
		/// <param name="column">The column.</param>
		/// <returns>The value.</returns>
		public int this[int row, int column]
		{
			get
			{
				if (row >= Size)
				{
					throw new ArgumentOutOfRangeException("row");
				}

				if (column >= Size)
				{
					throw new ArgumentOutOfRangeException("column");
				}

				if (Size == 1)
				{
					return Value;
				}

				int safeRow = row % Half;
				int safeColumn = column % Half;
				if (row < Half)
				{
					if (column < Half)
					{
						return TopLeft[safeRow, safeColumn];
					}
					else
					{
						return TopRight[safeRow, safeColumn];
					}
				}
				else
				{
					if (column < Half)
					{
						return BottomLeft[safeRow, safeColumn];
					}
					else
					{
						return BottomRight[safeRow, safeColumn];
					}
				}
			}
			set
			{
				if (row >= Size)
				{
					throw new ArgumentOutOfRangeException("row");
				}

				if (column >= Size)
				{
					throw new ArgumentOutOfRangeException("column");
				}

				if (Size == 1)
				{
					Value = value;
					return;
				}

				int safeRow = row % Half;
				int safeColumn = column % Half;
				if (row < Half)
				{
					if (column < Half)
					{
						TopLeft[safeRow, safeColumn] = value;
					}
					else
					{
						TopRight[safeRow, safeColumn] = value;
					}
				}
				else
				{
					if (column < Half)
					{
						BottomLeft[safeRow, safeColumn] = value;
					}
					else
					{
						BottomRight[safeRow, safeColumn] = value;
					}
				}
			}
		}


		/// <summary>
		/// Multiplies two matrices.
		/// </summary>
		/// <param name="a">The left matrix.</param>
		/// <param name="b">The right matrix.</param>
		/// <returns>The multiplication result.</returns>
		public static SquareEvenMatrix operator *(SquareEvenMatrix a, SquareEvenMatrix b)
		{
			if (UseStrassenMultiplicationOptimization)
			{
				return StrassenMatrixMultiplication(a, b);
			}
			else
			{
				return StandardRecursiveMultiplication(a, b);
			}
		}


		/// <summary>
		/// Specifies if the Strassen multiplication algorithm should be used when multiplying matrices.
		/// </summary>
		public static bool UseStrassenMultiplicationOptimization { get; set; }


		/// <summary>
		/// Multiplies two matrices using Strassen matrix multiplication.
		/// </summary>
		/// <param name="a">The left matrix.</param>
		/// <param name="b">The right matrix.</param>
		/// <returns>The multiplication result.</returns>
		public static SquareEvenMatrix StrassenMatrixMultiplication(SquareEvenMatrix a, SquareEvenMatrix b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}

			if (b == null)
			{
				throw new ArgumentNullException("b");
			}

			if (a.Size != b.Size)
			{
				throw new ArgumentException("Sizes must match.", "b");
			}

			if (a.Size == 1)
			{
				int[,] result = new int[1, 1];
				result[0, 0] = a.Value * b.Value;
				return new SquareEvenMatrix(result);
			}
			else
			{
				SquareEvenMatrix p1 = StrassenMatrixMultiplication(a.TopLeft, (b.TopRight - b.BottomRight));
				SquareEvenMatrix p2 = StrassenMatrixMultiplication(a.TopLeft + a.TopRight, b.BottomRight);
				SquareEvenMatrix p3 = StrassenMatrixMultiplication(a.BottomLeft + a.BottomRight, b.TopLeft);
				SquareEvenMatrix p4 = StrassenMatrixMultiplication(a.BottomRight, b.BottomLeft - b.TopLeft);
				SquareEvenMatrix p5 = StrassenMatrixMultiplication(a.TopLeft + a.BottomRight, b.TopLeft + b.BottomRight);
				SquareEvenMatrix p6 = StrassenMatrixMultiplication(a.TopRight - a.BottomRight, b.BottomLeft + b.BottomRight);
				SquareEvenMatrix p7 = StrassenMatrixMultiplication(a.TopLeft - a.BottomLeft, b.TopLeft + b.TopRight);

				return new SquareEvenMatrix(p5 + p4 - p2 + p6, p1 + p2,
											p3 + p4, p1 + p5 - p3 - p7);
			}
		}

		/// <summary>
		/// Recursive multiplication of matrices without any optimizations.
		/// Does 8 recursive calls per level.
		/// </summary>
		/// <param name="a">The left matrix.</param>
		/// <param name="b">The right matrix.</param>
		/// <returns>Matrix product.</returns>
		public static SquareEvenMatrix StandardRecursiveMultiplication(SquareEvenMatrix a, SquareEvenMatrix b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}

			if (b == null)
			{
				throw new ArgumentNullException("b");
			}

			if (a.Size != b.Size)
			{
				throw new ArgumentException("Sizes must match.", "b");
			}

			if (a.Size == 1)
			{
				int[,] result = new int[1, 1];
				result[0, 0] = a.Value * b.Value;
				return new SquareEvenMatrix(result);
			}
			else
			{
				SquareEvenMatrix topLeft = StandardRecursiveMultiplication(a.TopLeft, b.TopLeft) +
					StandardRecursiveMultiplication(a.TopRight, b.BottomLeft);
				SquareEvenMatrix topRight = StandardRecursiveMultiplication(a.TopLeft, b.TopRight) +
					StandardRecursiveMultiplication(a.TopRight, b.BottomRight);
				SquareEvenMatrix bottomLeft = StandardRecursiveMultiplication(a.BottomLeft, b.TopLeft) +
					StandardRecursiveMultiplication(a.BottomRight, b.BottomLeft);
				SquareEvenMatrix bottomRight = StandardRecursiveMultiplication(a.BottomLeft, b.TopRight) +
					StandardRecursiveMultiplication(a.BottomRight, b.BottomRight);

				return new SquareEvenMatrix(topLeft, topRight,
											bottomLeft, bottomRight);
			}
		}


		/// <summary>
		/// Adds two matrices.
		/// </summary>
		/// <param name="a">First matrix.</param>
		/// <param name="b">Second matrix.</param>
		/// <returns>A new matrix holding the sum of the two arguments.</returns>
		public static SquareEvenMatrix operator +(SquareEvenMatrix a, SquareEvenMatrix b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}

			if (b == null)
			{
				throw new ArgumentNullException("b");
			}

			if (a.Size != b.Size)
			{
				throw new ArgumentException("Sizes must match.", "b");
			}

			int[,] result = new int[a.Size, a.Size];

			for (int i = 0; i < a.Size; i++)
			{
				for (int j = 0; j < a.Size; j++)
				{
					result[i, j] = a[i, j] + b[i, j];
				}
			}

			return new SquareEvenMatrix(result);
		}


		/// <summary>
		/// Substracts two matrices.
		/// </summary>
		/// <param name="a">First matrix.</param>
		/// <param name="b">Second matrix.</param>
		/// <returns>A new matrix holding the difference of the two arguments.</returns>
		public static SquareEvenMatrix operator -(SquareEvenMatrix a, SquareEvenMatrix b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}

			if (b == null)
			{
				throw new ArgumentNullException("b");
			}

			if (a.Size != b.Size)
			{
				throw new ArgumentException("Sizes must match.", "b");
			}

			int[,] result = new int[a.Size, a.Size];

			for (int i = 0; i < a.Size; i++)
			{
				for (int j = 0; j < a.Size; j++)
				{
					result[i, j] = a[i, j] - b[i, j];
				}
			}

			return new SquareEvenMatrix(result);
		}


		/// <summary>
		/// String representation.
		/// </summary>
		/// <returns>A string representation of the matrix.</returns>
		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			for (int row = 0; row < Size; row++)
			{
				for (int column = 0; column < Size; column++)
				{
					builder.AppendFormat("{0} ", this[row, column]);
				}

				builder.AppendLine("/");
			}

			return builder.ToString();
		}


		/// <summary>
		/// Compares against a matrix for equality.
		/// </summary>
		/// <param name="other">Other matrix to compare.</param>
		/// <returns><c>true</c> if the matrices are equal.</returns>
		public bool Equals(SquareEvenMatrix other)
		{
			if (other == null)
			{
				return false;
			}

			if (other.Size != Size)
			{
				return false;
			}

			for (int i = 0; i < Size; i++)
			{
				for (int j = 0; j < Size; j++)
				{
					if (this[i, j] != other[i, j])
					{
						return false;
					}
				}
			}

			return true;
		}


		/// <summary>
		/// Compares for equality.
		/// </summary>
		/// <param name="obj">Other object to compare.</param>
		/// <returns>Equality status.</returns>
		public override bool Equals(object obj)
		{
			return Equals(obj as SquareEvenMatrix);
		}
	}
}
