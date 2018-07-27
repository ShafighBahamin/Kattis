using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        string first = Console.ReadLine();
        string second = Console.ReadLine();
        int len = 0;
        int a, b, e = 0, f = 0, t=0, r=0;
        string answer_one = "", answer_two = "";
        if (first.Length > second.Length)
        {
            t = 1;
            len = second.Length;
        }
        else
        {
            r = 1;
            len = first.Length;
        }
        for (int i = 0; i <len; i++)
        {
            if (t == 1)
            {
                Int32.TryParse(first[first.Length - second.Length + i].ToString(), out a);
                Int32.TryParse(second[i].ToString(), out b);
                if (a > b)
                {
                    e++;
                    answer_one += first[first.Length - second.Length + i];
                    answer_two += 'a';
                }
                else if (a < b)
                {
                    f++;
                    answer_two += second[i];
                    answer_one += 'a';
                }
                else
                {
                    answer_one += first[first.Length - second.Length + i];
                    answer_two += second[i];
                }
            }
            else
            {
                Int32.TryParse(first[i].ToString(), out a);
                Int32.TryParse(second[second.Length-first.Length+i].ToString(), out b);
                if (a > b)
                {
                    e++;
                    answer_one += first[i];
                    answer_two += 'a';
                }
                else if (a < b)
                {
                    f++;
                    answer_two += second[second.Length - first.Length + i];
                    answer_one += 'a';
                }
                else
                {
                    answer_one += first[i];
                    answer_two += second[second.Length - first.Length + i];
                }
            }
            
        }
        string c = "", d = "";
        if (first.Length > len)
        {
            for (int i = 0; i < first.Length-len; i++)
            {
                c += first[i];
            }
        }
        if (second.Length > len)
        {
            for (int i = 0; i < second.Length-len; i++)
            {
                d += second[i];
            }
        }
        answer_one = c + answer_one;
        answer_two = d + answer_two;
        c = "";
        d = "";
        for (int i = 0; i < answer_one.Length; i++)
        {
            if (answer_one[i] != 'a')
            {
                c += answer_one[i];
            }
        }
        for (int i = 0; i < answer_two.Length; i++)
        {
            if (answer_two[i] != 'a')
            {
                d += answer_two[i];
            }
        }
        if (e == len)
        {
            Console.WriteLine(c);
            Console.WriteLine("YODA");
        }
        else if (f == len)
        {
            Console.WriteLine("YODA");
            Console.WriteLine(d);
        }
        else
        {
            ulong x, y;
            ulong.TryParse(c, out x);
            ulong.TryParse(d, out y);
            Console.WriteLine(x);
            Console.WriteLine(y);
        }
    }
}
