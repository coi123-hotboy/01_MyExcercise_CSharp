using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT5_106_THOOP
{
    public class XeOToTai : TaiKhoanTaiXe, IPhuThuTheoKm, ITinhThuongNgay
    {
        protected double trongTai;
        public static double tiLePhi = 0.15;

        public double TrongTai
        {
            get { return trongTai; }
            set
            {
                if (value < 0)
                    trongTai = 0;
                else
                    trongTai = value;
            }
        }

        public override string HinhThuc
        {
            get { return "O to tai"; }
        }

        public XeOToTai() : base() { }

        public XeOToTai(string userName, string password, string phoneNumber, string status, string maSo, string tenTX, double trongTai)
            : base(userName, password, phoneNumber, status, maSo, tenTX) { TrongTai = trongTai; }

        public double PhuThuTheoKm(double soKm)
        {
            double phuThu = 0.0d;

            phuThu = soKm * 5000;

            return phuThu;
        }

        // tiền cước cơ bản, chưa cộng phụ thu, chưa giảm giá vip, chưa trừ phí công ty
        public override double TinhTienChuyenDi(double soKm)
        {
            double tt = 0.0d;

            if (TrongTai <= 3)
            {
                if (soKm <= 5)
                    tt = 60000;

                else if (soKm > 5 && soKm <= 10)
                    tt = 60000 + (soKm - 5) * 50000;

                else
                    tt = 310000 + (soKm - 10) * 30000;
            }

            else
            {
                if (soKm <= 5)
                    tt = 70000;

                else if (soKm > 5 && soKm <= 10)
                    tt = 70000 + (soKm - 5) * 60000;

                else
                    tt = 370000 + (soKm - 10) * 40000;
            }

            return tt;
        }

        public override double TinhPhiTraCongTy(double tienChuyenDi)
        {
            double phi = 0.0d;

            phi = tienChuyenDi * tiLePhi;

            return phi;
        }

        public double TinhThuongNgay(double doanhThuNgay)
        {
            double thuong = 0.0d;

            if (doanhThuNgay > 3000000)
                thuong = 300000;

            return thuong;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Trong tai: {TrongTai} tan");
            Console.WriteLine();
        }
    }
}
