using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static List<string> allNames = new List<string>();
    static void Main(string[] args)
    {
        //System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\Shafigh\\Desktop\\mytest.in");

        Dictionary<string, Node> friendsList = new Dictionary<string, Node>();
        Dictionary<string, bool> hasHeard = new Dictionary<string, bool>();

        int num;
        string line;
        string[] stringArr;
        line = Console.ReadLine();

        Int32.TryParse(line, out num);
        while (num > 0)
        {
            line = Console.ReadLine();
            Node a = new Node(line);
            friendsList.Add(line, a);
            hasHeard.Add(line, false);
            num--;
        }
        line = Console.ReadLine();
        Int32.TryParse(line, out num);
        while (num > 0)
        {
            line = Console.ReadLine();
            stringArr = line.Split(' ');
            friendsList[stringArr[0]].friends.Add(stringArr[1]);
            friendsList[stringArr[1]].friends.Add(stringArr[0]);
            num--;
        }


        line = Console.ReadLine();

        //System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
        //watch.Start();
        Int32.TryParse(line, out num);
        while (num > 0)
        {
            List<string> list = new List<string>();
            string name = "";
            line = Console.ReadLine();

            name += line;
            BFS(friendsList[line], friendsList, hasHeard);
            list = hasHeard.Keys.ToList();
            hasHeard.Add(line, false);
            list.Sort();
            allNames.AddRange(list);

            for (int i = 0; i < allNames.Count; i++)
            {
                name += " " + allNames[i];
                if (!hasHeard.ContainsKey(allNames[i]))
                {
                    hasHeard.Add(allNames[i], false);
                }
            }
            Console.WriteLine(name);
            allNames = new List<string>();

            num--;
        }
        //watch.Stop();
        //Console.WriteLine(watch.ElapsedMilliseconds);
    }
    private static void BFS(Node starter, Dictionary<string, Node> friendsList, Dictionary<string, bool> hasHeard)
    {
        Dictionary<int, List<string>> distance = new Dictionary<int, List<string>>();
        hasHeard.Remove(starter.name);
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(starter);
        while (q.Count > 0)
        {
            Node a = q.Dequeue();
            for (int i = 0; i < a.friends.Count; i++)
            {
                if (hasHeard.ContainsKey(a.friends[i]))
                {
                    q.Enqueue(friendsList[a.friends[i]]);
                    friendsList[a.friends[i]].dist = a.dist + 1;
                    if (distance.ContainsKey(friendsList[a.friends[i]].dist))
                    {
                        distance[friendsList[a.friends[i]].dist].Add(a.friends[i]);
                    }
                    else
                    {
                        List<string> list = new List<string>();
                        distance.Add(friendsList[a.friends[i]].dist, list);
                        distance[friendsList[a.friends[i]].dist].Add(a.friends[i]);
                    }
                    hasHeard.Remove(a.friends[i]);
                }
            }
        }
        sorter(distance);
    }

    private static void sorter(Dictionary<int, List<string>> distance)
    {
        foreach(KeyValuePair<int, List<string>> a in distance)
        {
            if (a.Value.Count > 0)
            {
                a.Value.Sort();
                allNames.AddRange(a.Value);
            }
        }
    }
}


class Node
{
    public string name;
    public List<string> friends;
    public bool print;
    public int dist;
    public Node(string Name)
    {
        name = Name;
        friends = new List<string>();
        print = false;
        dist = 0;
    }
}