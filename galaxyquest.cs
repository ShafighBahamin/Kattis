using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
    class Program
    {
        public static long max = 0;
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            long distance = 0;
            long starCount = 0;
            string line;
            //System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\Owner\\Desktop\\test1.in");

            line = Console.ReadLine();
            string[] str = line.Split(' ');
            bool firstBool = Int64.TryParse(str[0], out distance);
            bool secBool = Int64.TryParse(str[1], out starCount);
            distance = distance * distance;
            while ((line = Console.ReadLine()) != null)
            {
                list.Add(line);
            }
            if(list.Count > 1)
            {
                string num = majority(list.ToArray(), distance, list.Count);
            }
            else if (list.Count == 1)
            {
                max = 1;
            }
            if (max == 0 || max <= starCount/2)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine(max);
            }
        }

        private static string majority(string[] list, long distance, long starCount)
        {
            long left_X;
            long left_Y;
            long right_X;
            long right_Y;
            if (list.Length == 0)
            {
                return "NO";
            }
            else if (list.Length == 1)
            {
                return list[0];
            }

            else
            {
                List<string> majlist = new List<string>();
                List<string> oddList = new List<string>();
                int i = 0;
                for (i = 0; i < list.Length; i = i + 2)
                {
                    if (i < list.Length && i + 1 < list.Length)
                    {
                        string[] lineOne = list[i].Split(' ');
                        bool firstBool = Int64.TryParse(lineOne[0], out left_X);
                        bool secBool = Int64.TryParse(lineOne[1], out left_Y);
                        string[] lineTwo = list[i + 1].Split(' ');
                        bool thirdBool = Int64.TryParse(lineTwo[0], out right_X);
                        bool fourthBool = Int64.TryParse(lineTwo[1], out right_Y);
                        long answer = (((left_X - right_X) * (left_X - right_X)) + ((left_Y - right_Y) * (left_Y - right_Y)));
                        if (answer <= distance)
                        {
                            majlist.Add(list[i]);
                        }
                    }
                    else
                    {
                        oddList.Add(list[i]);
                    }
                }

                string x = majority(majlist.ToArray(), distance, majlist.Count);



                if(x== "NO")
                {
                    if(list.Length % 2 !=0)
                    {
                        for (int j = 0; j < oddList.Count; j++)
                        {
                            i = 0;
                            string[] lineOne = oddList[j].Split(' ');
                            bool firstBool = Int64.TryParse(lineOne[0], out left_X);
                            bool secBool = Int64.TryParse(lineOne[1], out left_Y);
                            for (int k = 0; k < list.Length; k++)
                            {
                                string[] lineTwo = list[k].Split(' ');
                                bool thirdBool = Int64.TryParse(lineTwo[0], out right_X);
                                bool fourthBool = Int64.TryParse(lineTwo[1], out right_Y);
                                if (left_X != right_X || left_Y != right_Y)
                                {
                                    long answer = (((left_X - right_X) * (left_X - right_X)) + ((left_Y - right_Y) * (left_Y - right_Y)));
                                    if (answer <= distance)
                                    {
                                        i++;
                                    }
                                }
                            }
                            i++;
                            if (i > max)
                            {
                                max = i;
                            }
                        }
                        if (max > starCount / 2)
                        {
                            return oddList[0];
                        }
                        else
                        {
                            return "NO";
                        }
                    }
                }


                else
                {
                        i = 0;
                        string[] lineOne = x.Split(' ');
                        bool firstBool = Int64.TryParse(lineOne[0], out left_X);
                        bool secBool = Int64.TryParse(lineOne[1], out left_Y);
                        for (int k = 0; k < list.Length; k++)
                        {
                            string[] lineTwo = list[k].Split(' ');
                            bool thirdBool = Int64.TryParse(lineTwo[0], out right_X);
                            bool fourthBool = Int64.TryParse(lineTwo[1], out right_Y);
                            if (left_X != right_X || left_Y != right_Y)
                            {
                                long answer = (((left_X - right_X) * (left_X - right_X)) + ((left_Y - right_Y) * (left_Y - right_Y)));
                                if (answer <= distance)
                                {
                                    i++;
                                }
                            }
                        }
                        i++;
                        if (i > max)
                        {
                            max = i;
                        }
                    
                    if (max > starCount / 2)
                    {
                        return x;
                    }
                    else
                    {
                        return "NO";
                    }
                }
                return max.ToString();
            }
        }
    }
}