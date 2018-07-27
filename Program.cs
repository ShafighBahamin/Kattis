using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\shafigh.bahamin\\Desktop\\samples\\shopaholic.in");
        long num = 0;
        string[] str_arr;
        string line = "";
        //while ((line = file.ReadLine()) != null)
        //{
        //    Console.WriteLine(line);
        //}
        //Console.ReadLine();
        line = file.ReadLine();
        line = file.ReadLine();
        Int64.TryParse(line, out num);
        int[] num_arr = new int[num];
        
        str_arr = file.ReadLine().Split(' ');
        int shafigh_is_an_idiot = 0;
        for (int i = 0; i < num; i++)
        {
            Int32.TryParse(str_arr[i], out shafigh_is_an_idiot);
            num_arr[i] = shafigh_is_an_idiot;
        }
        mergeSort(num_arr, 0, num_arr.Length-1);
        int count = 0;
        num = 0;
        if (num_arr.Length > 2)
        {
            for (int i = num_arr.Length - 1; i >= 0; i--)
            {
                count++;
                if (count == 3)
                {
                    num += num_arr[i];
                    count = 0;
                }
            }
        }
        Console.WriteLine(num);
        Console.ReadLine();
    }

    private static void mergeSort(int[] nums, int l, int r)
    {
        if (r > l)
        {
            int mid = (l + r) / 2;
            mergeSort(nums, l, mid);
            mergeSort(nums, mid + 1, r);
            merge(nums, l, mid, r);
        }
    }

    private static void merge(int[] nums, int l, int mid, int r)
    {
        int j = 0;
        int k = 0;
        int idx = 0;
        int r_idx = mid + 1;


        int left_length = mid - l + 1;
        int right_length = r - mid;

        int[] left_arr = new int[left_length];
        int[] right_arr = new int[right_length];

        for (int i = 0; i < left_length; i++)
        {
            left_arr[i] = nums[l + i];
        }
        j = 0;
        for (int i = 0; i < right_length; i++)
        {
            right_arr[i] = nums[i + mid + 1];
        }

        j = 0;
        k = 0;
        idx = l;

        while (j < left_length && k < right_length)
        {
            if (left_arr[j] <= right_arr[k])
            {
                nums[idx] = left_arr[j];
                j++;
                idx++;
            }
            else
            {
                nums[idx] = right_arr[k];
                k++;
                idx++;
            }
        }
        while (j < left_length)
        {
            nums[idx++] = left_arr[j++];
        }
        while (k < right_length)
        {
            nums[idx++] = right_arr[k++];
        }
    }
}

