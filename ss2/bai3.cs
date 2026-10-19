using System;
using System.Collections.Generic;
using System.Text;

namespace ss2
{

    public class Student
    {

        public string Id { get; set; } = "";
        public string FullName { get; set; } = "";
        public double Score { get; set; }

    }
    public class Program
    {
        // Tạo danh sách sinh viên dùng chung cho cả chương trình
        static List<Student> danhSach = new List<Student>();

        public static void Main12()
        {
            // Thêm sẵn một vài sinh viên để dễ test
            danhSach.Add(new Student { Id = "SV01", FullName = "Nguyen Van A", Score = 8.5 });
            danhSach.Add(new Student { Id = "SV02", FullName = "Tran Thi B", Score = 4.0 });

            int chon = 0;
            while (chon != 6)
            {
                Console.WriteLine("\n=== QUAN LY SINH VIEN ===");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Cap nhat thong tin");
                Console.WriteLine("3. Xoa sinh vien");
                Console.WriteLine("4. Tim kiem theo ten");
                Console.WriteLine("5. Hien thi danh sach & Thong ke");
                Console.WriteLine("6. Thoat");
                Console.Write("Chon chuc nang (1-6): ");

                chon = int.Parse(Console.ReadLine());

                if (chon == 1) ThemSinhVien();
                else if (chon == 2) CapNhatSinhVien();
                else if (chon == 3) XoaSinhVien();
                else if (chon == 4) TimKiem();
                else if (chon == 5) HienThi();
            }

        }
        // --- 1. HÀM THÊM SINH VIÊN ---
        static void ThemSinhVien()
        {
            Console.Write("Nhap ma SV: ");
            string id = Console.ReadLine();

            // Kiểm tra trùng mã
            foreach (Student sv in danhSach)
            {
                if (sv.Id == id)
                {
                    Console.WriteLine("Loi: Ma sinh vien da ton tai!");
                    return; // Dừng hàm, không cho thêm
                }
            }

            Console.Write("Nhap ho ten: ");
            string ten = Console.ReadLine();

            Console.Write("Nhap diem (0 - 10): ");
            double diem = double.Parse(Console.ReadLine());

            // Kiểm tra điểm hợp lệ
            if (diem < 0 || diem > 10)
            {
                Console.WriteLine("Loi: Diem phai tu 0 den 10!");
                return; // Dừng hàm
            }

            // Tạo đối tượng mới và lưu vào List
            Student svMoi = new Student();
            svMoi.Id = id;
            svMoi.FullName = ten;
            svMoi.Score = diem;

            danhSach.Add(svMoi);
            Console.WriteLine("Them thanh cong!");
        }
        // --- 2. HÀM CẬP NHẬT ---
        static void CapNhatSinhVien()
        {
            Console.Write("Nhap ma SV can cap nhat: ");
            string id = Console.ReadLine();

            foreach (Student sv in danhSach)
            {
                if (sv.Id == id)
                {
                    Console.Write("Nhap ten moi: ");
                    sv.FullName = Console.ReadLine();

                    Console.Write("Nhap diem moi: ");
                    double diemMoi = double.Parse(Console.ReadLine());

                    if (diemMoi >= 0 && diemMoi <= 10)
                    {
                        sv.Score = diemMoi;
                        Console.WriteLine("Cap nhat thanh cong!");
                    }
                    else
                    {
                        Console.WriteLine("Loi: Diem khong hop le!");
                    }
                    return; // Cập nhật xong thì thoát hàm
                }
            }
            Console.WriteLine("Khong tim thay sinh vien co ma: " + id);
        }
        // --- 3. HÀM XÓA ---
        static void XoaSinhVien()
        {
            Console.Write("Nhap ma SV can xoa: ");
            string id = Console.ReadLine();

            Student svCanXoa = null; // Biến tạm để nhớ người cần xóa

            foreach (Student sv in danhSach)
            {
                if (sv.Id == id)
                {
                    svCanXoa = sv;
                    break; // Tìm thấy thì dừng vòng lặp
                }
            }

            if (svCanXoa != null)
            {
                danhSach.Remove(svCanXoa);
                Console.WriteLine("Da xoa thanh cong!");
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien co ma: " + id);
            }
        }
        // --- 4. HÀM TÌM KIẾM ---
        static void TimKiem()
        {
            Console.Write("Nhap ten can tim: ");
            string tuKhoa = Console.ReadLine().ToLower(); // Chuyển thành chữ thường để dễ so sánh

            bool coTimThay = false;

            Console.WriteLine("--- Ket qua tim kiem ---");
            foreach (Student sv in danhSach)
            {
                string tenSV = sv.FullName.ToLower(); // Chuyển tên SV trong danh sách thành chữ thường

                // Hàm Contains dùng để kiểm tra chuỗi có chứa từ khóa không (Không dùng LINQ)
                if (tenSV.Contains(tuKhoa))
                {
                    Console.WriteLine($"Ma: {sv.Id}, Ten: {sv.FullName}, Diem: {sv.Score}");
                    coTimThay = true;
                }
            }

            if (coTimThay == false)
            {
                Console.WriteLine("Khong tim thay ai phu hop!");
            }
        }
        // --- 5. HÀM HIỂN THỊ VÀ THỐNG KÊ ---
        static void HienThi()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sach dang trong!");
                return;
            }

            double tongDiem = 0;
            int demQuaMon = 0;

            Console.WriteLine("--- Danh sach sinh vien ---");
            foreach (Student sv in danhSach)
            {
                Console.WriteLine($"Ma: {sv.Id}, Ten: {sv.FullName}, Diem: {sv.Score}");

                tongDiem = tongDiem + sv.Score;
                if (sv.Score >= 5)
                {
                    demQuaMon++;
                }
            }

            double diemTrungBinh = tongDiem / danhSach.Count;

            Console.WriteLine("---------------------------");
            Console.WriteLine($"Diem trung binh ca lop: {diemTrungBinh:F2}");
            Console.WriteLine($"So sinh vien diem >= 5: {demQuaMon}");
        }

    }
}