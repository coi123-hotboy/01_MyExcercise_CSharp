using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT5_106_THOOP
{
    public abstract class TaiKhoan
    {
        protected string userName;
        protected string password;
        protected string phoneNumber;
        protected string status; // online or offline

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && (value.Length == 10 || value.Length == 11) && value.StartsWith("0"))
                    phoneNumber = value;
                else
                    phoneNumber = "Khong xac dinh";
            }
        }

        public string Status
        {
            get { return status; }
            set
            {
                if (string.Equals(value, "online", StringComparison.OrdinalIgnoreCase) || string.Equals(value, "offline", StringComparison.OrdinalIgnoreCase))
                    status = value;
                else
                    status = "Offline";
            }
        }

        public TaiKhoan() { }

        public TaiKhoan(string userName, string password, string phoneNumber, string status)
        {
            UserName = userName;
            Password = password;
            PhoneNumber = phoneNumber;
            Status = status;
        }

        public void DangNhap()
        {
            Status = "Online";
        }

        public void DangXuat()
        {
            Status = "Offline";
        }

        public int LayToaDo()
        {
            Random rd = new Random(); // tạo một đối tượng sinh số ngẫu nhiên

            return rd.Next(1000); // random số nguyên không âm ngẫu nhiên từ 0-999
        }

        public virtual void Xuat()
        {
            Console.WriteLine($"UserName: {UserName}");
            Console.WriteLine($"Password: {Password}");
            Console.WriteLine($"PhoneNumber: {PhoneNumber}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"aaaa: {userName}, makh: {status}");

        }
    }
}
