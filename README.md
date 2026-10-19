# ss2
Họ và tên: Trần Tuấn Kiệt
MSSV: 31251021286
BÁO CÁO BÀI TẬP - CHƯƠNG 2: MẢNG VÀ MẢNG ĐỘNG
Môn học: Cấu trúc dữ liệu và Giải thuật



--------------------------------------------------

1. CÁCH CHẠY CHƯƠNG TRÌNH



- Môi trường: Visual Studio 2022 (hoặc bất kỳ IDE hỗ trợ C# nào) / .NET SDK.

- Cách chạy:

  1. Tải/Copy các đoạn mã nguồn (file .cs) vào dự án (Project) Console App (C#).

  2. Mỗi bài tập được viết thành các phương thức riêng biệt. Để chạy thử bài nào, gọi phương thức tương ứng của bài đó trong hàm Main.

  3. Bấm F5 hoặc nút Start trên Visual Studio để biên dịch và chạy.

  4. Nhập dữ liệu từ bàn phím theo các hướng dẫn in trên màn hình (Console).





--------------------------------------------------

2. CHI TIẾT CÁC BÀI TẬP



BÀI 1: THỐNG KÊ VÀ ĐẢO MẢNG TẠI CHỖ



- Mô tả thuật toán:

  + Thống kê: Khởi tạo min = a[0], max = a[0] và duyệt mảng 1 lần bằng vòng lặp foreach để tìm max, min, đếm số âm/dương/0 và tính tổng (dùng biến long).

  + Đảo mảng: Dùng kỹ thuật 2 con trỏ (left = 0 và right = n - 1). Dùng biến "tam" để hoán đổi (swap) vị trí 2 phần tử, sau đó tịnh tiến left và right vào giữa cho đến khi chúng gặp nhau (left < right).



- Độ phức tạp:

  + Thời gian (Time Complexity): O(n) do chỉ phải duyệt qua mảng.

  + Bộ nhớ phụ (Space Complexity): O(1) vì thao tác hoán đổi diễn ra trực tiếp trên mảng gốc, chỉ tốn 1 biến tạm.



- Các ca kiểm thử (Test cases):

  + Mảng có 1 phần tử (VD: [5]).

  + Mảng có số âm, dương và số 0 (VD: [-3, 0, 5, 2, -1]).





BÀI 2: CHÈN VÀ XÓA TRÊN MẢNG



- Mô tả thuật toán:

  + Insert: Kiểm tra ngoại lệ. Dùng vòng lặp for lùi (từ count về index) để dịch các phần tử sang phải 1 bước, tạo khoảng trống rồi gán giá trị mới và tăng count.

  + RemoveAt: Kiểm tra ngoại lệ. Dùng vòng lặp for tiến (từ index đến count - 1) để kéo phần tử phía sau sang trái lấp "lỗ hổng", sau đó giảm count.



- Độ phức tạp:

  + Thời gian: O(n) trong trường hợp xấu nhất (chèn/xóa ở index 0).

  + Bộ nhớ: O(1) vì thao tác trực tiếp trên mảng truyền vào.



- Các ca kiểm thử (Test cases):

  + Bắt buộc: Từ mảng [4, 7, 2, 9, 5], gọi Insert(..., 2, 99), rồi gọi RemoveAt(..., 1).

  + Ngoại lệ: Gọi Insert với index âm (-1), xóa khi index == count, và chèn khi mảng đã đầy (count == data.Length).





BÀI 3: QUẢN LÝ LIST STUDENT



- Mô tả thuật toán: 

  + Dùng List<Student> để lưu đối tượng. Các chức năng Thêm, Xóa, Cập nhật, Tìm kiếm đều dùng vòng lặp foreach để rà soát toàn bộ danh sách. Hàm thêm có kiểm tra trùng mã ID bằng cách duyệt tìm trước khi lưu.



- Độ phức tạp:

  + Thêm mới: O(1) khấu hao.

  + Tìm kiếm, Cập nhật, Thống kê: O(n).

  + Xóa (Remove): O(n) vì sau khi tìm thấy, List tự động dịch các phần tử phía sau lên để lấp hổng.



- Các ca kiểm thử (Test cases):

  + Thêm 5 sinh viên hợp lệ.

  + Thêm sinh viên bị trùng mã ID (Chương trình từ chối).

  + Cập nhật thông tin sinh viên có thực và cập nhật mã sai (Báo không tìm thấy).

  + Tìm kiếm theo cụm từ viết hoa/viết thường (Không phân biệt hoa/thường).

  + Xóa một sinh viên và in lại danh sách thống kê.





BÀI 4: MẢNG ĐỘNG (DYNAMIC ARRAY)



- Mô tả thuật toán: 

  + Xây dựng Class mô phỏng List<T>. Lớp chứa một mảng nội bộ T[] items và biến Count. Khi gọi hàm Add(), gọi hàm EnsureCapacity(). Nếu Count == Capacity, tạo một mảng mới có kích thước gấp đôi, chép toàn bộ dữ liệu từ mảng cũ sang mảng mới bằng vòng lặp for, rồi mới thêm phần tử.



- Độ phức tạp:

  + Truy cập bằng Indexer (arr[i]): O(1).

  + Thêm (Add): O(1) khấu hao. Nếu mảng bị đầy, lần chèn đó tốn O(n) do phải sao chép mảng.



- Các ca kiểm thử (Test cases):

  + Vòng lặp for chèn 10 số liên tiếp.

  + Kiểm tra màn hình in ra thấy Capacity tăng từ 4 -> 8 -> 16 trong khi Count tăng từng đơn vị một.

  + Đọc và ghi đè giá trị bằng Indexer (arr[2] = 99).

  + Cố tình truy cập arr[-1] và arr[Count] để hệ thống bắn lỗi IndexOutOfRangeException.
