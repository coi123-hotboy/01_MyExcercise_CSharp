using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BT5_106_THOOP
{
    public class XeOTo : TaiKhoanTaiXe, IPhuThuTheoKm, ITinhThuongNgay
    {
        protected int soChoNgoi;
        public static double tiLePhi = 0.1;

        public int SoChoNgoi
        {
            get { return soChoNgoi; }
            set
            {
                if (value == 4 || value == 7)
                    soChoNgoi = value;
                else
                    soChoNgoi = 4;
            }
        }

        public override string HinhThuc
        {
            get { return "O to"; }
        }

        public XeOTo() : base() { }

        public XeOTo(string userName, string password, string phoneNumber, string status, string maSo, string tenTX, int soChoNgoi)
            : base(userName, password, phoneNumber, status, maSo, tenTX) { SoChoNgoi = soChoNgoi; }

        public double PhuThuTheoKm(double soKm)
        {
            double phuThu = 0.0d;

            phuThu = soKm * 500;

            return phuThu;
        }

        public override double TinhTienChuyenDi(double soKm)
        {
            double tt = 0.0d;

            if (SoChoNgoi == 4)
            {
                if (soKm <= 2)
                    tt = 15000;

                else if (soKm > 2 && soKm <= 7)
                    tt = (soKm - 2) * 12000 + 15000;

                else
                    tt = 75000 + (soKm - 7) * 8000;
            }

            else
            {
                if (soKm <= 2)
                    tt = 17000;

                else if (soKm > 2 && soKm <= 7)
                    tt = (soKm - 2) * 15000 + 17000;

                else
                    tt = 92000 + (soKm - 7) * 10000;
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

            if (doanhThuNgay > 2000000)
                thuong = 200000;

            return thuong;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"So cho ngoi: {SoChoNgoi}");
            Console.WriteLine();
        }
    }
}
