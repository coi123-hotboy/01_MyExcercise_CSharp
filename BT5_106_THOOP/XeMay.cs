using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT5_106_THOOP
{
    public class XeMay : TaiKhoanTaiXe, IPhuThuTheoGio
    {
        public static double tiLePhi = 0.05;

        // get: trả về loại xe cố định của lớp đó.
        // Không có set vì loại xe đã được xác định bởi lớp con, không cần cho phép thay đổi.
        public override string HinhThuc
        {
            get { return "Gan may"; }
        }

        public XeMay() : base() { }

        public XeMay(string userName, string password, string phoneNumber, string status, string maSo, string tenTX) 
            : base(userName, password, phoneNumber, status, maSo, tenTX) { }
    
        public double PhuThuTheoGio(double soKm, int gioDon)
        {
            double phuThu = 0.0d;

            if (gioDon >= 22 || gioDon < 5)
            {
                phuThu = 3000 * soKm;
            }

            return phuThu;
        }

        public override double TinhTienChuyenDi(double soKm)
        {
            double tt = 0.0d;

            if (soKm <= 2)
                tt = 8000;

            else
            {
                tt = (soKm - 2) * 5000 + 8000;
            }

            return tt;
        }

        public override double TinhPhiTraCongTy(double tienChuyenDi)
        {
            double phi = 0.0d;

            phi = tienChuyenDi * tiLePhi;

            return phi;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine();
        }
    }
}
