using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Problems
{
	public class Vector3D
	{
		public Vector3D(Point3D A, Point3D B)
		{
			X = B.X - A.X;
			Y = B.Y - A.Y;
			Z = B.Z - A.Z;
		}

		public double X { get; set; }
		public double Y { get; set; }
		public double Z { get; set; }
		public double Norme
		{
			get { return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2)); }
		}

		public Vector3D(double x, double y) : this(x, y, 0)
		{
		}

		public Vector3D(double x, double y, double z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public Vector3D Normalized
		{
			get
			{
				double norme = Norme;
				return new Vector3D(X/norme, Y/norme, Z/norme);
			}
		}

		public double ScalarProduct(Vector3D AB)
		{
			return AB.X * X + AB.Y * Y + AB.Z * Z;
		}

		public Vector3D VectorProduct(Vector3D AB)
		{
			return new Vector3D(Y * AB.Z - Z * AB.Y, Z * AB.X - X * AB.Z, X * AB.Y - Y * AB.X);
		}

	}
}
