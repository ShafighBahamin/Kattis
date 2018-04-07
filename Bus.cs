using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        int T = 0;
        T = Int32.Parse(Console.ReadLine());

        for (int i = 0; i < T; i++)
        {
            int num = Int32.Parse(Console.ReadLine());
            int ans = 1;
            for (int j = 0; j < num; j++)
            {
                ans = ans * 2;
            }
            Console.WriteLine(ans-1);
        }
    }
}
