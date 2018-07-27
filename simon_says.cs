using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        
        //System.IO.StreamReader file = new StreamReader("C:\\Users\\shafigh.bahamin\\Desktop\\sample.in");
        string first = Console.ReadLine();
        int T;
        Int32.TryParse(first.ToString(), out T);
        for (int i = 0; i < T; i++)
        {
            string[] str_arr = Console.ReadLine().Split(' ');
            
            if (str_arr.Length>2&&(str_arr[0] == "simon" && str_arr[1] == "says"))
            {
                str_arr = str_arr.Skip(1).ToArray();
                str_arr = str_arr.Skip(1).ToArray();
                Console.WriteLine(string.Join(" ", str_arr));
            }
            else
            {
                Console.WriteLine(' ');
            }
        }

    }

}
