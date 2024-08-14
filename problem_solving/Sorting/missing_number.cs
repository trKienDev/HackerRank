using System;
using System.Collections.Generic;

class Program
{
    // * Solution 1: using List * //
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

    // ---------------------------------------------------------------------------------- //
    
    // * Solution 2: using Dictionary and Map * // 

    public static List<int> missingNumbers2(List<int> arr, List<int> brr)
    {
        // Dictionary to store frequency of elements in brr
        Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
    
        // Populate the frequency map with elements from brr
        foreach (int num in brr)
        {
            if (frequencyMap.ContainsKey(num))
            {
                frequencyMap[num]++;
            }
            else
            {
                frequencyMap[num] = 1;
            }
        }
    
        // Subtract the frequency of elements found in arr
        foreach (int num in arr)
        {
            if (frequencyMap.ContainsKey(num))
            {
                frequencyMap[num]--;
                // Remove the key if its frequency is zero
                if (frequencyMap[num] == 0)
                {
                    frequencyMap.Remove(num);
                }
            }
        }
    
        // Extract the keys (missing numbers) and sort them
        List<int> missingNumbers = new List<int>(frequencyMap.Keys);
        missingNumbers.Sort();
    
        return missingNumbers;
    }
    // ---------------------------------------------------------------------------------- //
    static void Main(string[] args)
    {
        List<int> arr = new List<int> { 3695, 3696, 3697, 3698 };
        List<int> brr = new List<int> { 3695, 3696, 3696, 3697, 3698, 3698, 3699 };

        List<int> result = missingNumbers(arr, brr);

        Console.WriteLine("Missing numbers: " + string.Join(", ", result));
    }
}





