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
        System.IO.StreamReader file = new StreamReader("C:\\Users\\shafigh.bahamin\\Desktop\\samples\\sample.in");
        Dictionary<string, int> words_to_num = new Dictionary<string, int>();
        Dictionary<int, string> num_to_words = new Dictionary<int, string>();
        string line;
        int num;
        string[] str_arr;
        while ((line = file.ReadLine()) != null)
        {
            if (line.Contains("def"))
            {
                str_arr = line.Split(' ');
                Int32.TryParse(str_arr[2], out num);
                if (words_to_num.ContainsKey(str_arr[1]))
                {
                    num_to_words.Remove(words_to_num[str_arr[1]]);
                    words_to_num.Remove(str_arr[1]);
                }
                words_to_num.Add(str_arr[1], num);
                num_to_words.Add(num, str_arr[1]);
            }
            else if (line.Contains("calc"))
            {
                bool unknown = false;
                int ans = 0;
                int multi = 1;
                str_arr = line.Split(' ');
                for (int i = 1; i < str_arr.Length; i++)
                {
                    if(str_arr[i] == "+")
                    {
                        multi = 1;
                    }
                    else if(str_arr[i] == "-")
                    {
                        multi = -1;
                    }
                    else if(str_arr[i] == "=")
                    {
                        break;
                    }
                    else if (words_to_num.ContainsKey(str_arr[i]))
                    {
                        ans += words_to_num[str_arr[i]] * multi;
                    }
                    else
                    {
                        unknown = true;
                        break;
                    }
                }
                if (unknown || !num_to_words.ContainsKey(ans))
                {
                    line = line.Substring(5);
                    line += " " + "unknown";
                    Console.WriteLine(line);
                }
                else
                {
                    line = line.Substring(5);
                    line += " " + num_to_words[ans];
                    Console.WriteLine(line);
                }
            }
            else if (line.Contains("clear"))
            {
                Console.ReadLine();
                words_to_num = new Dictionary<string, int>();
                num_to_words = new Dictionary<int, string>();
            }
        }
    }
}

