using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static List<List<int>> distances;
    public static List<int> hotels;
    public static int a = 0;
    static void Main(string[] args)
    {
        hotels = new List<int>();
        distances = new List<List<int>>();

        //System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\Shafigh\\Desktop\\test2.in");

        string line;
        int numberOfHotels;
        int distance;
        

        line = Console.ReadLine();
        Int32.TryParse(line, out numberOfHotels);

        while (numberOfHotels + 1 > 0)
        {
            distances.Add(new List<int>());
            line = Console.ReadLine();
            Int32.TryParse(line, out distance);
            hotels.Add(distance);
            numberOfHotels--;
        }
        distances[hotels.Count - 1].Add(0);
        distance = computePenalty(hotels.Count-1);
        Console.WriteLine(distances[0][0]);
    }

    private static int computePenalty(int location)
    {
        if(location == hotels.Count)
        {
            return 0;
        }
        if (distances[location].Count > 0 && a!= 0)
        {
            return distances[location][0];
        }
        a = 1;
        int b = 0;
        for (int i = location; i >=0; i--)
        {
            for (int j = i; j >=0; j--)
            {
                if (i == 0)
                {
                }
                b = ((400 - (hotels[i] - hotels[j])) * (400 - (hotels[i] - hotels[j])) + computePenalty(i));
                //Console.WriteLine(b);
                if (distances[j].Count > 0)
                {
                    if (b < distances[j][0])
                    {
                        distances[j][0] = b;
                    }
                }
                else
                {
                    distances[j].Add(b);
                }
            }
        }
        if (location == hotels.Count - 1)
        {
            return 0;
        }
        else
        {
            return distances[location][0];
        }
    }
}

