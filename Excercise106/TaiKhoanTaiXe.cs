using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT5_106_THOOP
{
    public abstract class TaiKhoanTaiXe : TaiKhoan
    {
        protected string maSo;
        protected string tenTX;
        protected string hinhThuc;

        public string MaSo
        {
            get { return maSo; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.StartsWith("TX") && value.Length == 5 && value.Substring(2).All(char.IsDigit))
                    maSo = value;
                else
                    maSo = "TX001";
            }
        }

        public string TenTX
        {
            get { return tenTX; }
            set { tenTX = value; }
        }

        //get: trả về loại xe cố định của lớp đó.
        public abstract string HinhThuc { get; }

        public TaiKhoanTaiXe() { }

        public TaiKhoanTaiXe(string userName, string password, string phoneNumber, string status, string maSo, string tenTX) : base(userName, password, phoneNumber, status)
        {
            MaSo = maSo;
            TenTX = tenTX;
        }

        public void PhatTinHieuCuocGoi()
        {
            Console.WriteLine($"Vi tri khach goi xe: {LayToaDo()}");
        }

        public abstract double TinhTienChuyenDi(double soKm);

        public abstract double TinhPhiTraCongTy(double tienChuyenDi);

        // không nên dùng public abstract double TinhPhuThu(...) vì:
        // mặc dù 3 lớp xe đều có tính phụ thu nhưng điều kiện tính không giống nhau
        // lớp XeMay cần tham số gioDon để tính phụ thu nhưng 2 lớp còn lại không cần

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Ma so tai xe: {MaSo}");
            Console.WriteLine($"Ten tai xe: {TenTX}");
            Console.WriteLine($"Hinh thuc: {HinhThuc}");
        }
    }
}
