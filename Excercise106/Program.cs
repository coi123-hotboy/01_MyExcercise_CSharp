using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace BT5_106_THOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CongTy ct = new CongTy();

            int choice;

            do
            {
                Console.WriteLine("=================== MENU ===================");
                Console.WriteLine("1. Doc toan bo danh sach");
                Console.WriteLine("2. Xuat toan bo danh sach: khach hang, tai xe, chuyen xe");
                Console.WriteLine("3. Neu khach hang nao di tu chuyen thu 10 tro di se duoc chuyen thanh khach VIP");
                Console.WriteLine("4. Dem so xe moi loai");
                Console.WriteLine("5. Dem so tai khoan khach hien co trong danh sach");
                Console.WriteLine("6. Xuat thong tin tai xe lai xe gan may");
                Console.WriteLine("7. Tinh tong doanh thu tung loai xe trong mot ngay");
                Console.WriteLine("8. Xuat thong tin chuyen xe co tien cuoc nhieu nhat doi voi xe may");
                Console.WriteLine("9. Xuat thong tin chuyen xe co tien cuoc nhieu nhat doi voi o to");
                Console.WriteLine("10. Xuat thong tin chuyen xe co tien cuoc nhieu nhat doi voi o to tai");
                Console.WriteLine("11. Sap xep chuyen xe tang dan theo tien cuoc va ma tai xe");
                Console.WriteLine("12. Xuat thong tin khach hang Vip");
                Console.WriteLine("13. Tim khach hang co so chuyen di nhieu nhat");
                Console.WriteLine("14. Tim tai xe doanh thu cao nhat");
                Console.WriteLine("15. Xuat thong tin tai xe o to duoc thuong");
                Console.WriteLine("16. Xuat thong tin tai xe o to tai duoc thuong");
                Console.WriteLine("0. Thoat chuong trinh");
                Console.Write("Moi ban lua chon: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {

                    case 1:
                        Console.WriteLine();
                        ct.DocDSTX("C:\\C# Basic\\Bài tập THOOP\\BT5_106_THOOP\\BT5_106_THOOP\\DanhSachTaiXe.xml");
                        ct.DocDSKH("C:\\C# Basic\\Bài tập THOOP\\BT5_106_THOOP\\BT5_106_THOOP\\DanhSachKhachHang.xml");
                        ct.DocDSCX("C:\\C# Basic\\Bài tập THOOP\\BT5_106_THOOP\\BT5_106_THOOP\\DanhSachChuyenXe.xml");
                        Console.WriteLine("Doc file thanh cong!");
                        Console.WriteLine();
                        break;

                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("--- DANH SACH TAI XE ---");
                        ct.XuatDSTX();
                        Console.WriteLine("--- DANH SACH KHACH HANG ---");
                        ct.XuatDSKH();
                        Console.WriteLine("--- DANH SACH CHUYEN XE ---");
                        ct.XuatDSChuyenXe();
                        break;

                    case 3:
                        Console.WriteLine();
                        ct.ChuyenKhachVip();
                        Console.WriteLine();
                        break;

                    case 4:
                        Console.WriteLine();
                        ct.DemSoXeMoiLoai();
                        Console.WriteLine();
                        break;

                    case 5:
                        Console.WriteLine();
                        int count = ct.CountTaiKhoanKhach();
                        Console.WriteLine($"So tai khoan khach hien co trong he thong la: {count}");
                        Console.WriteLine();
                        break;

                    case 6:
                        Console.WriteLine();
                        ct.XuatTaiXe_XeGanMay();
                        Console.WriteLine();
                        break;

                    case 7:
                        Console.WriteLine();
                        Console.WriteLine("Nhap ngay can tinh: ");
                        DateTime ngayCanTinh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        ct.TongDoanhThu_TungLoaiXe(ngayCanTinh);
                        Console.WriteLine();
                        break;

                    case 8:
                        Console.WriteLine();
                        Console.WriteLine("Thong tin chuyen xe co tien cuoc nhieu nhat doi voi xe may: ");
                        ChuyenXeCuaKhach cxxm = ct.XuatChuyenXeNhieuCuocNhat_XeMay();
                        cxxm.XuatChuyenXe();
                        Console.WriteLine();
                        break;

                    case 9:
                        Console.WriteLine();
                        Console.WriteLine("Thong tin chuyen xe co tien cuoc nhieu nhat doi voi xe o to: ");
                        ChuyenXeCuaKhach cxxot = ct.XuatChuyenXeNhieuCuocNhat_XeOTo();
                        cxxot.XuatChuyenXe();
                        Console.WriteLine();
                        break;

                    case 10:
                        Console.WriteLine();
                        Console.WriteLine("Thong tin chuyen xe co tien cuoc nhieu nhat doi voi xe o to tai: ");
                        ChuyenXeCuaKhach cxxott = ct.XuatChuyenXeNhieuCuocNhat_XeOToTai();
                        cxxott.XuatChuyenXe();
                        Console.WriteLine();
                        break;

                    case 11:
                        Console.WriteLine();
                        ct.SapXepTangDan();
                        Console.WriteLine();
                        break;


                    case 12:
                        Console.WriteLine();
                        ct.Xuat_KhachVip();
                        Console.WriteLine();
                        break;

                    case 13:
                        Console.WriteLine();
                        TaiKhoanKhachHang kh = ct.KhachHangDiNhieuNhat();
                        kh.Xuat();
                        Console.WriteLine();
                        break;

                    case 14:
                        Console.WriteLine();
                        TaiKhoanTaiXe tx = ct.TaiXe_MaxDoanhThu();
                        tx.Xuat();
                        Console.WriteLine();
                        break;

                    case 15:
                        Console.WriteLine();
                        ct.XuatTaiXe_OToDuocThuong();
                        Console.WriteLine();
                        break;

                    case 16:
                        Console.WriteLine();
                        ct.XuatTaiXe_OToTaiDuocThuong();
                        Console.WriteLine();
                        break;

                    case 0:
                        Console.WriteLine();
                        Console.WriteLine("Cam mon ban da su dung chuong trinh");
                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Error");
                        Console.WriteLine();
                        break;
                }

            } while (choice != 0);
        }
    }
}
