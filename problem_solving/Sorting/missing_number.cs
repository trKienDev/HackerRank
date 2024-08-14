using System;
using System.Collections.Generic;

class Program
{
    public static List<int> missingNumbers(List<int> arr, List<int> brr)
    {
        // Tạo một danh sách để lưu kết quả các số bị thiếu
        List<int> missing = new List<int>();

        // Tạo một bản sao của brr để không làm thay đổi brr gốc
        List<int> brrCopy = new List<int>(brr);

        // Duyệt qua từng phần tử của arr và loại bỏ phần tử tương ứng trong brrCopy
        foreach (int num in arr)
        {
            brrCopy.Remove(num);
        }

        // Sau khi loại bỏ, brrCopy sẽ chứa các số bị thiếu
        // Ta sẽ đếm tần suất của từng số và thêm chúng vào danh sách kết quả
        foreach (int num in brrCopy)
        {
            if (!missing.Contains(num))
            {
                missing.Add(num);
            }
        }

        // Sắp xếp kết quả theo thứ tự tăng dần
        missing.Sort();

        return missing;
    }

    static void Main(string[] args)
    {
        List<int> arr = new List<int> { 3695, 3696, 3697, 3698 };
        List<int> brr = new List<int> { 3695, 3696, 3696, 3697, 3698, 3698, 3699 };

        List<int> result = missingNumbers(arr, brr);

        Console.WriteLine("Missing numbers: " + string.Join(", ", result));
    }
}
