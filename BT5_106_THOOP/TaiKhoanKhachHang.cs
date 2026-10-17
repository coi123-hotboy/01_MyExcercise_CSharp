using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT5_106_THOOP
{
    public class TaiKhoanKhachHang : TaiKhoan
    {
        protected string loaiKhach;

        public string LoaiKhach
        {
            get { return loaiKhach; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) &&
                    (string.Equals(value, "vip", StringComparison.OrdinalIgnoreCase) || string.Equals(value, "thuong", StringComparison.OrdinalIgnoreCase)))
                    loaiKhach = value;
                else
                    loaiKhach = "Thuong";
            }
        }

        public TaiKhoanKhachHang() : base() { LoaiKhach = "Thuong"; }

        public TaiKhoanKhachHang(string userName, string password, string phoneNumber, string status, string loaiKhach) : base(userName, password, phoneNumber, status)
        {
            LoaiKhach = loaiKhach;
        }

        public void GoiXe(string loaiXe)
        {
            DangNhap();

            int diaChiDon = LayToaDo();

            GuiThongTin(loaiXe, diaChiDon);
        }

        public void GuiThongTin(string loaiXe, int diaChiDon)
        {
            Console.WriteLine($"Loai xe: {loaiXe}");
            Console.WriteLine($"Dia chi don khach: {diaChiDon}");
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Loai khach: {LoaiKhach}");
            Console.WriteLine();
        }
    }
}
