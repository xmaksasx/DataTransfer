using System;
using System.Runtime.InteropServices;

namespace DataTransfer.Infrastructure.Helpers
{
	class ConvertHelper
	{
		public static bool ByteToObject<T>(byte[] receiveBytes, T obj)
		{
			int len = Marshal.SizeOf(obj);
			if (len != receiveBytes.Length) return false;
			IntPtr i = Marshal.AllocHGlobal(len);
			Marshal.Copy(receiveBytes, 0, i, len);
			Marshal.PtrToStructure(i, obj);
			Marshal.FreeHGlobal(i);
			return true;
		}


		public static byte[] ObjectToByte<T>(T obj)
		{
			var size = Marshal.SizeOf(obj);
			var bytes = new byte[size];
			var ptr = Marshal.AllocHGlobal(size);
			Marshal.StructureToPtr(obj, ptr, false);
			Marshal.Copy(ptr, bytes, 0, size);
			Marshal.FreeHGlobal(ptr);
			return bytes;
		}

        #region Перевод из XZ в LatLon и обратно

        private const double bb2 = 8376121;
        private const double bb4 = 590.42;
        private const double bb6 = 1.68;
        private const double R = 6367558.497;
        private const double AA2 = 5333.5419;
        private const double AA4 = 4.84339;
        private const double AA6 = 0.007622;
        private const double P57 = 57.2957795130823208767;
        private const double P157 = 0.01745329251994329576;

        private static void Linear2Gp(double FL0, double FEast, double xx, double yy, out double lat, out double lon)
        {
            double x = yy;
            double y = xx - FEast;
            double u = x / R;
            double v = y / R;
            double tmp = 2.0 * u;
            double a1 = Math.Sin(tmp);
            double b1 = Math.Cos(tmp);
            double a2 = 2.0 * a1 * b1;
            double b2 = 1.0 - 2.0 * a1 * a1;
            double a3 = a1 * b2 + a2 * b1;
            double b3 = b1 * b2 - a1 * a2;
            tmp = 2.0 * v;
            double c1 = (Math.Exp(tmp) - Math.Exp(-tmp)) * 0.5;
            double c12 = c1 * c1;
            double d1 = Math.Sqrt(1.0 + c12);
            double c2 = 2.0 * c1 * d1;
            double d2 = 1.0 + 2.0 * c12;
            double c3 = c1 * d2 + c2 * d1;
            double d3 = c1 * c2 + d1 * d2;
            double psi = u - (bb2 * a1 * d1 + bb4 * a2 * d2 + bb6 * a3 * d3) * 1.0E-10;
            double p = v - (bb2 * b1 * c1 + bb4 * b2 * c2 + bb6 * b3 * c3) * 1.0E-10;
            double sfi = Math.Sin(psi) / ((Math.Exp(p) + Math.Exp(-p)) * 0.5);
            double sfi2 = sfi * sfi;
            double fi = Math.Atan(sfi / (Math.Sqrt(1.0 - sfi2) + 1.0E-20));
            double tgl = ((Math.Exp(p) - Math.Exp(-p)) * 0.5) / (Math.Cos(psi) + 1.0E-20);
            lon = (Math.Atan(tgl) + FL0) * P57;
            lat = ((fi + ((5645.0 * sfi2 - 531245.0) * sfi2 + 67385254.0) * sfi * Math.Cos(fi) * 1.0E-10) * 180) /
                  Math.PI;
        }

        private static void Gp2Linear(double FL0, double FEast, double lat, double lon, out double Z, out double X)
        {
            double b = lat * P157;
            double l = lon * P157;
            l = l - FL0;
            double sinb = Math.Sin(b);
            double sin2b = sinb * sinb;
            double fi = b - ((2624.0 * sin2b + 372834.0) * sin2b + 66934216.0) * sinb * Math.Cos(b) * 1.0E-10;
            double cosfi = Math.Cos(fi);
            double thp = cosfi * Math.Sin(l);
            double psi = Math.Atan(Math.Sin(fi) / (cosfi + 1.0E-20) / (Math.Cos(l) + 1.0E-20));
            double p = 0.5 * Math.Log((1.0 + thp) / (1.0 - thp));
            double a1 = Math.Sin(2.0 * psi);
            double b1 = Math.Cos(2.0 * psi);
            double tmp = 1.0 / (1.0 - thp * thp);
            double c1 = 2.0 * thp * tmp;
            double d1 = (1.0 + thp * thp) * tmp;
            double a2 = 2.0 * a1 * b1;
            double b2 = 1.0 - 2.0 * a1 * a1;
            double c2 = 2.0 * c1 * d1;
            double d2 = 1.0 + 2.0 * c1 * c1;
            double a3 = a1 * b2 + a2 * b1;
            double b3 = b1 * b2 - a1 * a2;
            double c3 = c1 * d2 + c2 * d1;
            double d3 = d1 * d2 + c1 * c2;
            X = R * psi + AA2 * a1 * d1 + AA4 * a2 * d2 + AA6 * a3 * d3;
            Z = R * p + AA2 * b1 * c1 + AA4 * b2 * c2 + AA6 * b3 * c3 + FEast;
        }

        /// <summary>
        /// Перевод географических координат в прямоугольные
        /// </summary>
        /// <param name="Lat">Нулевая координата</param>
        /// <param name="Lon">Нулевая координата</param>
        /// <param name="X">Текущая координата</param>
        /// <param name="Z">Текущая координата</param>
        /// <param name="LatT">Рассчитанная координата</param>
        /// <param name="LonT">Рассчитанная координата</param>
        public static void LocalCordToLatLon(double Lat, double Lon, double X, double Z, out double LatT,
            out double LonT)
        {
            double Z0, X0;
            double FL0 = Lon * P157;
            double FEast = ((int)(Lon / 6) + 1) * 1000000.0 + 500000.0;
            Gp2Linear(FL0, FEast, Lat, Lon, out Z0, out X0);
            Linear2Gp(FL0, FEast, Z0 + Z, X0 + X, out LatT, out LonT);
        }

        /// <summary>
        /// Перевод прямоугольных координат в географические
        /// </summary>
        /// <param name="Lat">Нулевая координата</param>
        /// <param name="Lon">Нулевая координата</param>
        /// <param name="LatT">Текущая координата</param>
        /// <param name="LonT">Текущая координата</param>
        /// <param name="X">Рассчитанная координата</param>
        /// <param name="Z">Рассчитанная координата</param>
        public static void LocalCordToXZ(double Lat, double Lon, double LatT, double LonT, out double X, out double Z)
        {
            double Z0, X0;
            double FL0 = Lon * P157;
            double FEast = ((int)(Lon / 6) + 1) * 1000000.0 + 5000000.0;
            Gp2Linear(FL0, FEast, Lat, Lon, out Z0, out X0);
            Gp2Linear(FL0, FEast, LatT, LonT, out Z, out X);
            X -= X0;
            Z -= Z0;
        }
		#endregion
	}
}
