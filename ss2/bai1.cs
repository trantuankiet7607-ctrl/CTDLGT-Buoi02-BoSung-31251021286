using System;
using System.Collections.Generic;
using System.Text;

namespace ss2
{
    public class bai1
    {
        static void bai_1()
        {
            //nhap vao so luong phan tu bang for
            Console.WriteLine("nhap vao so luong phan tu cua mang: ");
            int n = int.Parse(Console.ReadLine());
            if (n > 1 && n < 100_000)
            {
                int[] a = new int[n];
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"Nhap phan tu thu {i + 1}: ");
                    a[i] = int.Parse(Console.ReadLine());
                }

                // tao cac bien chua gia tri de so sanh va chua ket qua
                long tong = 0;
                int min = a[0];
                int max = a[0];
                int demduong = 0;
                int demam = 0;
                int dem0 = 0;

                // dung foreach de duyet mang
                foreach (int i in a)
                {
                    tong += i;
                    if (i < min)
                    {
                        min = i;
                    }
                    if (max < i)
                    {
                        max = i;
                    }
                    if (i > 0)
                    {
                        demduong++;
                    }
                    if (i < 0)
                    {
                        demam++;
                    }
                    if (i == 0)
                    {
                        dem0++;
                    }
                }

                // khoi tao bien index de dao vi tri
                int left = 0;
                int right = n - 1;
                int tam = 0;
                //dung bien tam de luu gia tri ben trai roi cho gia tri ben trai bang ben phai roi gia tri phai bang tam
                while (left < right)
                {
                    tam = a[left];
                    a[left] = a[right];
                    a[right] = tam;      // da sua: truoc day la a[right] = a[left]
                    left++;
                    right--;
                }

                double tbc = tong / a.Length;
                Console.WriteLine($"Tong la: {tong}");
                Console.WriteLine($"max la: {max}");
                Console.WriteLine($"min la: {min}");
                Console.WriteLine($"trung binh cong la: {tbc:F2}");
                //dung vong lap de duyet mang va in ra
                foreach (int k in a)
                {
                    Console.Write(k + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        public static void Main2(string[] args)
        {
            bai_1();
        }
    }
}
