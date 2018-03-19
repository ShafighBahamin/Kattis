using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static double[] dist;
    public static int numOfV;
    static void Main(string[] args)
    {
        //System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\Shafigh\\Desktop\\myTest3.in");
        
        int numOfE;
        int start;
        int dest;
        KeyValuePair<double, int> a;
        KeyValuePair<double, int> b;
        double factor;
        string[] line;
        while((line = Console.ReadLine().Split(' ')) != null)
        {
           
           
            Int32.TryParse(line[0], out numOfV);
            Int32.TryParse(line[1], out numOfE);
            if (numOfV == 0 && numOfE == 0) { break; }
            List<List<KeyValuePair<double, int>>> neighbors = new List<List<KeyValuePair<double, int>>>(numOfV);
            for(int i = 0; i < numOfV; i++)
            {
                List<KeyValuePair<double, int>> list = new List<KeyValuePair<double, int>>();
                neighbors.Add(list);
            }
            while (numOfE > 0)
            {
                line = Console.ReadLine().Split(' ');
                Int32.TryParse(line[0], out start);
                Int32.TryParse(line[1], out dest);
                double.TryParse(line[2], out factor);
                a = new KeyValuePair<double, int>(factor, start);
                b = new KeyValuePair<double, int>(factor, dest);
                neighbors[start].Add(b);
                neighbors[dest].Add(a);
                numOfE--;
            }

            start = 0;

            dist = Enumerable.Repeat(0.0, numOfV).ToArray();

            dist[start] = 1;


            bool[] visited = Enumerable.Repeat(false, numOfV).ToArray();

            BinaryHeap PQ = new BinaryHeap();
            KeyValuePair<double, int> beg = new KeyValuePair<double, int>(dist[start], start);
            PQ.add(beg);

            while(PQ.isEmpty() == false)
            {
                beg = PQ.deleteMin();

                foreach(KeyValuePair<double, int> node in neighbors[beg.Value])
                {
                    if(visited[beg.Value] == false)
                    {
                        if(dist[beg.Value] * node.Key > dist[node.Value])
                        {
                            dist[node.Value] = dist[beg.Value] * node.Key;
                        }
                        KeyValuePair<double, int> nde = new KeyValuePair<double, int>(dist[node.Value], node.Value);
                        PQ.add(nde);
                    }
                }

                visited[beg.Value] = true;
            }
            string k = string.Format("{0:N4}", dist[numOfV - 1]);
            Console.WriteLine(k);
        }
    }
}

class BinaryHeap
{
    private List<KeyValuePair<double, int>> minHeap;
    public BinaryHeap()
    {
        minHeap = new List<KeyValuePair<double, int>>();
        KeyValuePair<double, int> a = new KeyValuePair<double, int>(0, 0);
        minHeap.Add(a);
    }
    internal void add(KeyValuePair<double, int> node)
    {
        minHeap.Add(node);
        int i = minHeap.Count - 1;
        while (i > 1 && (minHeap[i / 2].Key <= minHeap[i].Key))
        {
            KeyValuePair<double, int> temp = minHeap[i];
            minHeap[i] = minHeap[i / 2];
            minHeap[i / 2] = temp;
            i = i / 2;

        }
    }
    internal bool isEmpty()
    {
        if (minHeap.Count > 1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    internal KeyValuePair<double, int> deleteMin()
    {
        KeyValuePair<double, int> max = minHeap[1];
        minHeap[1] = minHeap[minHeap.Count - 1];
        minHeap.RemoveAt(minHeap.Count - 1);
        int i = 1;
        int root;
        while (i <= minHeap.Count / 2)
        {
            if (2 * i + 1 < minHeap.Count - 1 && (minHeap[2 * i].Key < minHeap[2 * i + 1].Key))
            {
                root = 2 * i + 1;
            }
            else
            {
                root = 2 * i;
            }
            if (root < minHeap.Count - 1 && (minHeap[i].Key < minHeap[root].Key))
            {
                KeyValuePair<double, int> temp = minHeap[i];
                minHeap[i] = minHeap[root];
                minHeap[root] = temp;
                i = root;
            }
            else
            {
                break;
            }
        }
        return max;
    }
}
