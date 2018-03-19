using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static List<int> distances;
    public static int[,] twoD;
    public static int m;
    static void Main(string[] args)
    {
        //System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\Shafigh\\Desktop\\spiderman.in");

        int numOfTests;
        int numOfClimbs;
        int dis;

        string line = Console.ReadLine();
        string[] strVec = line.Split(' ');
        Int32.TryParse(strVec[0], out numOfTests);

        for(int i = 0; i < numOfTests; i++)
        {
            strVec = Console.ReadLine().Split(' ');
            Int32.TryParse(strVec[0], out numOfClimbs);
            m = numOfClimbs;
            for(int j = 0; j < 1; j++)
            {
                //test = new List<int>();
                //cache = new Dictionary<string, int>();
                distances = new List<int>();
                
                strVec = Console.ReadLine().Split(' ');
                for(int k = 0; k < strVec.Length; k++)
                {
                    Int32.TryParse(strVec[k], out dis);
                    distances.Add(dis);
                }
                //test.Add(0);
                //pathFinder(1,0);
                //cache.Remove(cache.Last().Key);
                solve();
                //int maxHeight = cache.Last().Value;
            }
        }
    }

    private static void solve()
    {
        int hi = 1000;
        int lo = 0;
        int mid;
        while (hi > lo + 1)
        {
            mid = (hi + lo) / 2;
            if (spidyClimb(mid))
            {
                hi = mid;
            }
            else
            {
                lo = mid;
            }
        }
        if (spidyClimb(hi))
        {
            printSol();
        }
        else
        {
            Console.WriteLine("IMPOSSIBLE");
        }
    }

    private static void printSol()
    {
        int h = 0;
        string answer = "";
        int step;
        for(step = 1; step <= m; step++)
        {
            if(h-distances[step-1] >= 0 && twoD[step, h-distances[step-1]] == 1)
            {
                answer += "D";
                h -= distances[step-1];
            }
            else
            {
                answer += "U";
                h += distances[step-1];
            }
        }
        Console.WriteLine(answer);
    }

    private static bool spidyClimb(int maxH)
    {
        twoD = new int[41, 1001];
        twoD[m, 0] = 1;
        for(int i = m; i > 0; i--)
        {
            for(int h = 0; h <= maxH; h++)
            {
                if(twoD[i,h] == 1)
                {
                    if (h - distances[i-1] >= 0)
                    {
                        twoD[i - 1, h - distances[i-1]] = 1;
                    }
                    if (h + distances[i-1] <= maxH)
                    {
                        twoD[i - 1, h + distances[i-1]] = 1;
                    }
                }
            }
        }
        if(twoD[0,0] == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

