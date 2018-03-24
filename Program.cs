using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 1,2,3,4,5,5, 6, 8, 2, 3, 4, 7, 1, 9, 0 };
        int sum = 16;
        Tuple<int, int> ans;
        ans = find(arr, sum);
    }

    static Tuple<int, int> find(int[] arr, int sum)
    {
        Tuple<int, int> ans;
        MergeSort(arr, 0, arr.Length-1);
        int mid = (arr.Length / 2);
        int i = 0;
        int j = arr.Length - 1;
        while(i < j && j > i)
        {
            if(arr[i] + arr[j] == sum)
            {
                ans = new Tuple<int, int>(arr[i], arr[j]);
                return ans;
            }
            else if(arr[i] + arr[j] > sum)
            {
                j--;
            }
            else
            {
                i++;
            }
        }
        ans = new Tuple<int, int>(-1, -1);
        return ans;
    }
    private static void MergeSort(int[] nums, int beg, int end)
    {
        if (beg < end)
        {
            int mid = (beg + end) / 2;
            MergeSort(nums, beg, mid);
            MergeSort(nums, mid + 1, end);
            Merge(nums, beg, mid, end);
        }
    }

    private static void Merge(int[] nums, int beg, int mid, int end)
    {
        int i = 0;
        int f_idx = beg;
        int s_idx = mid + 1;
        int[] list = new int[end - beg + 1];
        while (f_idx <= mid && s_idx <= end)
        {
            if (nums[f_idx] <= nums[s_idx])
            {
                list[i] = nums[f_idx];
                i++;
                f_idx++;
            }
            else
            {
                list[i] = nums[s_idx];
                i++;
                s_idx++;
            }
        }
        while (s_idx <= end)
        {
            list[i] = nums[s_idx];
            i++;
            s_idx++;
        }
        while (f_idx <= mid)
        {
            list[i] = nums[f_idx];
            i++;
            f_idx++;
        }
        int k = 0;
        for (i = beg; i <= end; i++)
        {
            nums[i] = list[k];
            k++;
        }
    }
}

