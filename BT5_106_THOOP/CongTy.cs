using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Globalization;

namespace BT5_106_THOOP
{
    public class CongTy
    {
        List<TaiKhoanTaiXe> listTX; // lưu các tài xế, dùng để tìm tài xế xe máy, ô tô và ô tô tải
        List<TaiKhoanKhachHang> listKH; // lưu khách hàng, dùng để tìm khách vip, đếm khách hàng, ....
        List<ChuyenXeCuaKhach> listChuyenXe; // lưu các chuyến xe, dùng để tính doanh thu, tìm chuyến có giá cao nhất

        public List<TaiKhoanTaiXe> ListTX
        {
            get { return listTX; }
            set { listTX = value; }
        }

        public List<TaiKhoanKhachHang> ListKH
        {
            get { return listKH; }
            set { listKH = value; }
        }

        public List<ChuyenXeCuaKhach> ListChuyenXe
        {
            get { return listChuyenXe; }
            set { listChuyenXe = value; }
        }

        public CongTy()
        {
            ListTX = new List<TaiKhoanTaiXe>();
            ListKH = new List<TaiKhoanKhachHang>();
            ListChuyenXe = new List<ChuyenXeCuaKhach>();
        }

        public CongTy(List<TaiKhoanTaiXe> dsTX, List<TaiKhoanKhachHang> dsKH, List<ChuyenXeCuaKhach> dsCX)
        {
            ListTX = dsTX;
            ListKH = dsKH;
            ListChuyenXe = dsCX;
        }
     
        // đọc danh sách tài xế 
        public void DocDSTX(string file)
        {
            XmlDocument read = new XmlDocument();

            read.Load(file);

            XmlNodeList nodelist = read.SelectNodes("/DSTaiXe/TaiXe");

            foreach (XmlNode node in nodelist)
            {
                TaiKhoanTaiXe tk;

                int loai = int.Parse(node["Loai"].InnerText);
                string username = node["UserName"].InnerText;
                string password = node["Password"].InnerText;
                string phoneNumber = node["PhoneNumber"].InnerText;
                string status = node["Status"].InnerText;
                string maSo = node["MaSo"].InnerText;
                string tenTX = node["TenTX"].InnerText;

                if (loai == 1) // xe may
                {
                    tk = new XeMay(username, password, phoneNumber, status, maSo, tenTX);
                }

                else if (loai == 2)
                {
                    int soChoNgoi = int.Parse(node["SoChoNgoi"].InnerText);
                    tk = new XeOTo(username, password, phoneNumber, status, maSo, tenTX, soChoNgoi);
                }

                else if (loai == 3)
                {
                    double trongTai = double.Parse(node["TrongTai"].InnerText);
                    tk = new XeOToTai(username, password, phoneNumber, status, maSo, tenTX, trongTai);
                }

                else
                    continue;

                ListTX.Add(tk);
            }
        }

        // đọc danh sách khách hàng
        public void DocDSKH(string file)
        {
            XmlDocument read = new XmlDocument();

            read.Load(file);

            XmlNodeList nodelist = read.SelectNodes("/DSKhach/Khach");

            foreach (XmlNode node in nodelist)
            {
                TaiKhoanKhachHang tk;

                string username = node["UserName"].InnerText;
                string password = node["Password"].InnerText;
                string phoneNumber = node["PhoneNumber"].InnerText;
                string status = node["Status"].InnerText;
                string loai = node["LoaiKhach"].InnerText;

                tk = new TaiKhoanKhachHang(username, password, phoneNumber, status, loai);

                ListKH.Add(tk);
            }
        }

        // đọc danh sách chuyến xe
        public void DocDSCX(string file)
        {
            XmlDocument read = new XmlDocument();

            read.Load(file);

            XmlNodeList nodelist = read.SelectNodes("/DSChuyenXe/ChuyenXe");

            foreach (XmlNode node in nodelist)
            {
                string userTX = node["UserTaiXe"].InnerText;
                string userKhach = node["UserKhach"].InnerText;
                string diaChiDon = node["DiaChiDon"].InnerText;
                string diaChiDen = node["DiaChiDen"].InnerText;
                double distance = double.Parse(node["Distance"].InnerText);
                int gioDon = int.Parse(node["GioDon"].InnerText);
                DateTime ngayDi = DateTime.ParseExact(node["NgayDi"].InnerText, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                TaiKhoanTaiXe taiXe = null;
                TaiKhoanKhachHang khachHang = null;

                foreach (TaiKhoanTaiXe tx in ListTX)
                {
                    if (tx.UserName == userTX)
                    {
                        taiXe = tx;
                        break;
                    }
                }

                foreach (TaiKhoanKhachHang kh in ListKH)
                {
                    if (kh.UserName == userKhach)
                    {
                        khachHang = kh;
                        break;
                    }
                }

                if(taiXe != null && khachHang != null)
                {
                    ChuyenXeCuaKhach cx = new ChuyenXeCuaKhach(taiXe, khachHang, diaChiDon, diaChiDen, distance, gioDon, ngayDi);

                    ListChuyenXe.Add(cx);
                }
            }
        }

        public void XuatDSTX()
        {
            foreach (TaiKhoanTaiXe tk in ListTX)
            {
                tk.Xuat();
            }
        }

        public void XuatDSKH()
        {
            foreach(TaiKhoanKhachHang kh in ListKH)
            {
                kh.Xuat();
            }
        }

        public void XuatDSChuyenXe()
        {
            foreach (ChuyenXeCuaKhach cx in ListChuyenXe)
            {
                cx.XuatChuyenXe();
            }
        }

        public void ChuyenKhachVip()
        {
            bool yes = false;

            foreach (TaiKhoanKhachHang kh in ListKH)
            {
                int soChuyen = 0;

                foreach (ChuyenXeCuaKhach cx in ListChuyenXe)
                {
                    if (cx.KhachHang.UserName == kh.UserName)
                        soChuyen++;
                }

                if (soChuyen >= 10)
                {
                    kh.LoaiKhach = "Vip";
                    Console.WriteLine($"Da chuyen khach hang {kh.UserName} thanh khach Vip");
                    yes = true;
                }

                if (yes == false)
                    Console.WriteLine("Khong co khach hang nao co so chuyen lon hon hoac bang 10");
            }
        }

        public void DemSoXeMoiLoai()
        {
            int countXeMay = 0;
            int countXeOTo = 0;
            int countXeOToTai = 0;

            foreach (TaiKhoanTaiXe tx in ListTX)
            {
                if (tx is XeMay)
                {
                    countXeMay++;
                }

                else if (tx is XeOTo)
                {
                    countXeOTo++;
                }

                else if (tx is XeOToTai)
                {
                    countXeOToTai++;
                }

                else
                    continue;
            }

            Console.WriteLine($"Xe may: {countXeMay}");
            Console.WriteLine($"Xe o to: {countXeOTo}");
            Console.WriteLine($"Xe o to tai: {countXeOToTai}");
        }

        public int CountTaiKhoanKhach()
        {
            int count = 0;

            foreach (TaiKhoanKhachHang tk in ListKH)
            {
                count++;
            }

            return count;
        }

        public void XuatTaiXe_XeGanMay()
        {
            foreach (TaiKhoanTaiXe tx in ListTX)
            {
                if(tx is XeMay xm)
                {
                    xm.Xuat();
                }
            }
        }

        public void TongDoanhThu_TungLoaiXe(DateTime ngayCanTinh)
        {
            double sumXeMay = 0.0d;
            double sumXeOTo = 0.0d;
            double sumXeOToTai = 0.0d;

            foreach (ChuyenXeCuaKhach cx in ListChuyenXe)
            {
                if (cx.TaiXe is XeMay && cx.NgayDi == ngayCanTinh)
                {
                    sumXeMay += cx.TinhThanhTienChuyenXe();
                }

                else if (cx.TaiXe is XeOTo && cx.NgayDi == ngayCanTinh)
                {
                    sumXeOTo += cx.TinhThanhTienChuyenXe();
                }

                else if (cx.TaiXe is XeOToTai && cx.NgayDi == ngayCanTinh)
                {
                    sumXeOToTai += cx.TinhThanhTienChuyenXe();
                }

                else
                    continue;
            }

            Console.WriteLine($"Tong doanh thu xe may: {sumXeMay}");
            Console.WriteLine($"Tong doanh thu xe o to: {sumXeOTo}");
            Console.WriteLine($"Tong doanh thu xe o to tai: {sumXeOToTai}");
        }

        public ChuyenXeCuaKhach XuatChuyenXeNhieuCuocNhat_XeMay()
        {
            double max = -1;
            ChuyenXeCuaKhach maxCuoc = null;

            foreach (ChuyenXeCuaKhach cx in ListChuyenXe)
            {
                if(cx.TaiXe is XeMay && cx.TinhThanhTienChuyenXe() > max)
                {
                    max = cx.TinhThanhTienChuyenXe();
                    maxCuoc = cx;
                }
            }

            return maxCuoc;
        }

        public ChuyenXeCuaKhach XuatChuyenXeNhieuCuocNhat_XeOTo()
        {
            double max = -1;
            ChuyenXeCuaKhach maxCuoc = null;

            foreach (ChuyenXeCuaKhach cx in ListChuyenXe)
            {
                if (cx.TaiXe is XeOTo && cx.TinhThanhTienChuyenXe() > max)
                {
                    max = cx.TinhThanhTienChuyenXe();
                    maxCuoc = cx;
                }
            }

            return maxCuoc;
        }

        public ChuyenXeCuaKhach XuatChuyenXeNhieuCuocNhat_XeOToTai()
        {
            double max = -1;
            ChuyenXeCuaKhach maxCuoc = null;

            foreach (ChuyenXeCuaKhach cx in ListChuyenXe)
            {
                if (cx.TaiXe is XeOToTai && cx.TinhThanhTienChuyenXe() > max)
                {
                    max = cx.TinhThanhTienChuyenXe();
                    maxCuoc = cx;
                }
            }

            return maxCuoc;
        }

        public void SapXepTangDan()
        {
            List<ChuyenXeCuaKhach> dsMoi = new List<ChuyenXeCuaKhach>(ListChuyenXe);

            for (int i = 0; i < dsMoi.Count - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < dsMoi.Count; j++)
                {
                    if (dsMoi[j].TinhThanhTienChuyenXe() < dsMoi[min].TinhThanhTienChuyenXe())
                    {
                        min = j;
                    }

                    else if (dsMoi[j].TinhThanhTienChuyenXe() == dsMoi[min].TinhThanhTienChuyenXe())
                    {
                        if (string.Compare(dsMoi[min].TaiXe.MaSo, dsMoi[j].TaiXe.MaSo) > 0)
                            min = j;
                    }
                }

                if(min != i)
                {
                    ChuyenXeCuaKhach temp = dsMoi[i];
                    dsMoi[i] = dsMoi[min];
                    dsMoi[min] = temp;
                }
            }

            foreach (ChuyenXeCuaKhach cx in dsMoi)
            {
                cx.XuatChuyenXe();
            }
        }

        public void Xuat_KhachVip()
        {
            bool flag = false;

            foreach (TaiKhoanKhachHang kh in ListKH)
            {
                if (string.Equals(kh.LoaiKhach, "vip", StringComparison.OrdinalIgnoreCase))
                {
                    kh.Xuat();
                    flag = true;
                }
            }

            if (flag == false)
                Console.WriteLine("Khong co khach hang Vip trong he thong!");
        }

        public TaiKhoanKhachHang KhachHangDiNhieuNhat()
        {
            TaiKhoanKhachHang khachHangMax = null;
            int maxSoChuyen = -1;

            foreach (TaiKhoanKhachHang kh in ListKH)
            {
                int soChuyen = 0;

                foreach (ChuyenXeCuaKhach cx in ListChuyenXe)
                {
                    if (cx.KhachHang.UserName == kh.UserName)
                    {
                        soChuyen++;
                    }
                }

                if(soChuyen > maxSoChuyen)
                {
                    maxSoChuyen = soChuyen;
                    khachHangMax = kh;
                }
            }

            return khachHangMax;
        }

        public TaiKhoanTaiXe TaiXe_MaxDoanhThu()
        {
            double max = -1;
            TaiKhoanTaiXe txMax = null;

            foreach (TaiKhoanTaiXe tx in ListTX)
            {
                double dt = 0.0d;

                foreach (ChuyenXeCuaKhach cx in ListChuyenXe)
                {
                    if (cx.TaiXe.MaSo == tx.MaSo)
                        dt += cx.TinhThanhTienChuyenXe();
                }

                if (dt > max)
                {
                    max = dt;
                    txMax = tx;
                }
            }

            return txMax;
        }

        public double TinhDoanhThuTrongNgay(DateTime ngay, string userTX)
        {
            double doanhThu = 0.0d;

            foreach (ChuyenXeCuaKhach cx in ListChuyenXe)
            {
                if (cx.NgayDi == ngay && cx.TaiXe.UserName == userTX)
                    doanhThu += cx.TinhThanhTienChuyenXe();
            }

            return doanhThu;
        }
   
        public void XuatTaiXe_OToDuocThuong()
        {
            bool duocthuong = false;

            foreach (TaiKhoanTaiXe tx in ListTX)
            {
                if(tx is XeOTo oto)
                {
                    foreach (ChuyenXeCuaKhach cx in ListChuyenXe)
                    {
                        if(cx.TaiXe == oto)
                        {
                            double doanhthu = TinhDoanhThuTrongNgay(cx.NgayDi, tx.UserName);

                            if(oto.TinhThuongNgay(doanhthu) > 0)
                            {
                                Console.WriteLine($"Ma so tai xe: {cx.TaiXe.MaSo}");
                                Console.WriteLine($"Username: {cx.TaiXe.UserName}");
                                duocthuong = true;
                                break;
                            }
                        }
                    }
                }
            }

            if (duocthuong == false)
                Console.WriteLine("Khong co tai xe o to nao duoc thuong!");
        }

        public void XuatTaiXe_OToTaiDuocThuong()
        {
            bool duocthuong = false;

            foreach (TaiKhoanTaiXe tx in ListTX)
            {
                if (tx is XeOToTai ototai)
                {
                    foreach (ChuyenXeCuaKhach cx in ListChuyenXe)
                    {
                        if (cx.TaiXe == ototai)
                        {
                            double doanhthu = TinhDoanhThuTrongNgay(cx.NgayDi, tx.UserName);

                            if (ototai.TinhThuongNgay(doanhthu) > 0)
                            {
                                Console.WriteLine($"Ma so tai xe: {cx.TaiXe.MaSo}");
                                Console.WriteLine($"Username: {cx.TaiXe.UserName}");
                                duocthuong = true;
                                break;
                            }
                        }
                    }
                }
            }

            if (duocthuong == false)
                Console.WriteLine("Khong co tai xe o to nao duoc thuong!");
        }
    }
}
