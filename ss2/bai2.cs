public class bai2
{
    static void Insert(int[] data, ref int count, int index, int value)
    {
        if (index < 0 || index > count)
        {
            Console.WriteLine("Loi: index khong hop le");
            return;
        }
        if (count >= data.Length)
        {
            Console.WriteLine("Loi: mang da day");
            return;
        }

        // Dich tu PHAI sang TRAI
        for (int i = count; i > index; i--)
            data[i] = data[i - 1];

        data[index] = value;
        count++;
    }

    static void RemoveAt(int[] data, ref int count, int index)
    {
        if (index < 0 || index >= count)
        {
            Console.WriteLine("Loi: index khong hop le");
            return;
        }

        // Dich tu TRAI sang PHAI
        for (int i = index; i < count - 1; i++)
            data[i] = data[i + 1];

        count--;
    }

    static void Print(int[] data, int count)
    {
        Console.Write("count=" + count + ": ");
        for (int i = 0; i < count; i++)
            Console.Write(data[i] + " ");
        Console.WriteLine();
    }
    public static void Main22(string[] args)
    {
        // Nhap kich thuoc mang (suc chua)
        Console.Write("Nhap kich thuoc mang (data.Length): ");
        int size = int.Parse(Console.ReadLine());
        int[] data = new int[size];

        // Nhap so phan tu ban dau
        Console.Write("Nhap so phan tu ban dau (count <= " + size + "): ");
        int count = int.Parse(Console.ReadLine());
        if (count < 0 || count > size)
        {
            Console.WriteLine("Loi: count khong hop le");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            Console.Write("Nhap phan tu thu " + (i + 1) + ": ");
            data[i] = int.Parse(Console.ReadLine());
        }

        //Console.Write("Nhap index can chen: ");
        //int index = int.Parse(Console.ReadLine());
        //Console.Write("Nhap gia tri can chen: ");
        //int value = int.Parse(Console.ReadLine());
        //Insert(data, ref count, index, value);
        Console.Write("Nhap index can xoa: ");
        int index = int.Parse(Console.ReadLine());
        RemoveAt(data, ref count, index);
        Print(data, count);
    }
}