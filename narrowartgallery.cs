using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static List<List<int>> artGalla;
    public static Dictionary<string, int> cost;
    public static int answer;
    public static string rdk;
    static void Main(string[] args)
    {
        //System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\Shafigh\\Desktop\\sample3.in");

        string line;
        int N;
        int k;

        artGalla = new List<List<int>>();
        cost = new Dictionary<string, int>();

        line = Console.ReadLine();

        string[] strVec = line.Split(' ');
        Int32.TryParse(strVec[0], out N);
        Int32.TryParse(strVec[1], out k);

        int duplicate = N;
        int zeroR;
        int oneR;

        while (duplicate > 0)
        {
            line = Console.ReadLine();
            strVec = line.Split(' ');
            Int32.TryParse(strVec[0], out zeroR);
            Int32.TryParse(strVec[1], out oneR);
            List<int> row = new List<int>();
            row.Add(zeroR);
            row.Add(oneR);
            artGalla.Add(row);
            duplicate--;
        }

        
        Console.WriteLine(optimalRoute(0, -1, k, N));
    }

    private static int optimalRoute(int r, int dontClose, int k, int N)
    {
        string rdk = r.ToString() + "/" + dontClose.ToString() + "/" + k.ToString();
        
        if (cost.ContainsKey(rdk))
        {
            //Console.WriteLine("haha");
            return cost[rdk];
        }
        answer = 0;
        if (k == N - r)
        {
            if (r < N)
            {
                if (dontClose == 1)
                {
                    answer = artGalla[r][1] + optimalRoute(r + 1, 1, k - 1, N);
                }
                else if (dontClose == 0)
                {
                    answer = artGalla[r][0] + optimalRoute(r + 1, 0, k - 1, N);
                }
                else
                {
                    answer = Math.Max(artGalla[r][0] + optimalRoute(r + 1, 0, k - 1, N), artGalla[r][1] + optimalRoute(r + 1, 1, k - 1, N));
                }
            }
        }
        else
        {
            if (r < N)
            {
                if (dontClose == 0)
                {
                    answer = Math.Max(artGalla[r][0] + optimalRoute(r + 1, 0, k - 1, N), artGalla[r][0] + artGalla[r][1] + optimalRoute(r + 1, -1, k, N));
                }
                else if (dontClose == 1)
                {
                    answer = Math.Max(artGalla[r][1] + optimalRoute(r + 1, 1, k - 1, N), artGalla[r][0] + artGalla[r][1] + optimalRoute(r + 1, -1, k, N));
                }
                else
                {
                    answer = Math.Max(artGalla[r][0] + optimalRoute(r + 1, 0, k - 1, N), Math.Max(artGalla[r][1] + optimalRoute(r + 1, 1, k - 1, N), artGalla[r][0] + artGalla[r][1] + optimalRoute(r + 1, -1, k, N)));
                }
            }
        }
        cost.Add(rdk, answer);
        return answer;
    }
}

