using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BT5_106_THOOP
{
    public class ChuyenXeCuaKhach
    {
        TaiKhoanTaiXe taiXe;
        TaiKhoanKhachHang khachHang;
        string diaChiDon;
        string diaChiDen;
        double distance;
        int gioDon;
        DateTime ngayDi;

        public TaiKhoanTaiXe TaiXe
        {
            get { return taiXe; }
            set { taiXe = value; }
        }

        public TaiKhoanKhachHang KhachHang
        {
            get { return khachHang; }
            set { khachHang = value; }
        }

        public string DiaChiDon
        {
            get { return diaChiDon; }
            set { diaChiDon = value; }
        }

        public string DiaChiDen
        {
            get { return diaChiDen; }
            set { diaChiDen = value; }
        }

        public double Distance
        {
            get { return distance; }
            set
            {
                if (value < 0)
                    distance = 0;
                else
                    distance = value;
            }
        }

        public int GioDon
        {
            get { return gioDon; }
            set { gioDon = value; }
        }

        public DateTime NgayDi
        {
            get { return ngayDi; }
            set { ngayDi = value; }
        }

        public ChuyenXeCuaKhach() { }

        public ChuyenXeCuaKhach(TaiKhoanTaiXe taiXe, TaiKhoanKhachHang khachHang, string diaChiDon, string diaChiDen, double distance, int gioDon, DateTime ngayDi)
        {
            // thay vì tạo đối tượng bên trong constructor = new, ta truyền đối tượng đã được tạo từ bên ngoài vào constructor rồi gán nó cho property tương ứng
            TaiXe = taiXe;
            KhachHang = khachHang;
            DiaChiDon = diaChiDon;
            DiaChiDen = diaChiDen;
            Distance = distance;
            GioDon = gioDon;
            NgayDi = ngayDi;
        }

        public double TinhThanhTienChuyenXe()
        {
            double tien = TaiXe.TinhTienChuyenDi(Distance);

            if (TaiXe is IPhuThuTheoGio theoGio)
            {
                tien += theoGio.PhuThuTheoGio(Distance, GioDon);
            }

            else if (TaiXe is IPhuThuTheoKm theoKm)
            {
                tien += theoKm.PhuThuTheoKm(Distance);
            }

            if (string.Equals(KhachHang.LoaiKhach, "vip", StringComparison.OrdinalIgnoreCase) && tien > 200000)
                tien = tien * 0.9;

            return tien;
        }

        public double TienTaiXeThucNhan()
        {
            double tienChuyenDi = TinhThanhTienChuyenXe();

            return tienChuyenDi - TaiXe.TinhPhiTraCongTy(tienChuyenDi);
        }

        public void XuatChuyenXe()
        {
            Console.WriteLine($"Username tai xe: {TaiXe.UserName}");
            Console.WriteLine($"Username khach hang: {KhachHang.UserName}");
            Console.WriteLine($"Dia chi don: {DiaChiDon}");
            Console.WriteLine($"Dia chi den: {DiaChiDen}");
            Console.WriteLine($"Khoang cach: {Distance}");
            Console.WriteLine($"Gio don: {GioDon}");
            Console.WriteLine($"Ngay di: {NgayDi: dd/MM//yyyy}");
            Console.WriteLine($"Thanh tien chuyen xe: {TinhThanhTienChuyenXe()} dong");
            Console.WriteLine($"Phi tra cong ty: {TaiXe.TinhPhiTraCongTy(TinhThanhTienChuyenXe())} dong");
            Console.WriteLine($"Tien tai xe thuc nhan: {TienTaiXeThucNhan()} dong");
            Console.WriteLine();
        }
    }
}
