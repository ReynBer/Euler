using System;
using System.Collections.Generic;

namespace Euler.Problems
{
	public class Problem102 : Problem
	{
		private Point3D O = new Point3D(0, 0);

		public bool IsInside(Point3D XY1, Point3D XY2, Point3D Ref, int prof)
		{
			double a = XY1.X - XY2.X;
			double b = XY2.Y - XY1.Y;
			double c = XY2.X * XY1.Y - XY1.X * XY2.Y;
			if (a * Ref.Y + b * Ref.X + c >= 0)
			{
				if (c >= 0)
				{
					if (prof == 3)
					{
						return true;
					}
					return IsInside(Ref, XY1, XY2, prof + 1);
				}
			}
			else
			{
				if (c < 0)
				{
					if (prof == 3)
					{
						return true;
					}
					return IsInside(Ref, XY1, XY2, prof + 1);
				}
			}
			return false;
		}

		public bool IsInside(int x1, int y1, int x2, int y2, int x3, int y3, int prof)
		{
			int a = x1 - x2;
			int b = y2 - y1;
			int c = x2 * y1 - x1 * y2;
			if (Math.Sign(a * y3 + b * x3 + c) == Math.Sign(c))
			{
				if (prof == 1)
					return true;
				return IsInside(x3, y3, x1, y1, x2, y2, prof - 1);
			}
			return false;
		}

		public bool AffineMethod(int x1, int y1, int x2, int y2, int x3, int y3)
		{
			 return IsInside(x1, y1, x2, y2, x3, y3, 3);
		}

		public bool AffineFastMethod(int x1, int y1, int x2, int y2, int x3, int y3)
		{
			/* Version Développée */
			int a = x1 - x2;
			int b = y2 - y1;
			int c = x2 * y1 - x1 * y2;
			if (Math.Sign(a * y3 + b * x3 + c) == Math.Sign(c))
			{
				a = x2 - x3;
				b = y3 - y2;
				c = x3 * y2 - x2 * y3;
				if (Math.Sign(a * y1 + b * x1 + c) == Math.Sign(c))
				{
					a = x1 - x3;
					b = y3 - y1;
					c = x3 * y1 - x1 * y3;
					return Math.Sign(a * y2 + b * x2 + c) == Math.Sign(c);
				}
			}
			return false;
		}

		public bool VectorMethod(double x1, double y1, double x2, double y2, double x3, double y3)
		{
			Point3D A = new Point3D(x1, y1);
			Point3D B = new Point3D(x2, y2);
			Point3D C = new Point3D(x3, y3);

			/* Solution Vectorielle */
			Vector3D AB = new Vector3D(A, B).Normalized;
			Vector3D AC = new Vector3D(A, C).Normalized;
			Vector3D AO = new Vector3D(A, O).Normalized;
			double sinBAC = AB.VectorProduct(AC).Z;
			double sinBAO = AB.VectorProduct(AO).Z;
			double cosBAC = AB.ScalarProduct(AC);
			double cosBAO = AB.ScalarProduct(AO);
			if (Math.Sign(sinBAO) == Math.Sign(sinBAC) && cosBAC < cosBAO)
			{
				AB = new Vector3D(B, A).Normalized;
				AC = new Vector3D(B, C).Normalized;
				AO = new Vector3D(B, O).Normalized;
				sinBAC = AB.VectorProduct(AC).Z;
				sinBAO = AB.VectorProduct(AO).Z;
				cosBAC = AB.ScalarProduct(AC);
				cosBAO = AB.ScalarProduct(AO);
				return (Math.Sign(sinBAO) == Math.Sign(sinBAC) && cosBAC < cosBAO);
			}
			return false;
		}

		public override object Launch()
		{
			int count = 0;
			string[] splitted = Resource.triangles.Split(new string[1] { "\r\n" }, StringSplitOptions.None);
			foreach (string s in splitted)
			{
				string[] points = s.Split(new char[]{','},StringSplitOptions.None);
				int x1 = int.Parse(points[0]);
				int y1 = int.Parse(points[1]);
				int x2 = int.Parse(points[2]);
				int y2 = int.Parse(points[3]);
				int x3 = int.Parse(points[4]);
				int y3 = int.Parse(points[5]);
				/*if (AffineMethod(x1, y1, x2, y2, x3, y3))
				{
					count++;
				}*/
				/*if (AffineMethod(x1, y1, x2, y2, x3, y3))
				{
					count++;
				}*/
				if (VectorMethod(x1, y1, x2, y2, x3, y3))
				{
					count++;
				}
			}
			//Console.Out.WriteLine("count = {0}", count);
			return count;
		}

		public override void Dispose()
		{
			//throw new NotImplementedException();
		}
	}
}
