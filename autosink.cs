using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class Program
{
    static Dictionary<string, int> travelCost = new Dictionary<string, int>();
    static int a = 0;
    static Dictionary<string, int> travelCostPast = new Dictionary<string, int>();

    static void Main(string[] args)
    {
        //System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\Shafigh\\Desktop\\test1.in");
        Dictionary<string, City> city = new Dictionary<string, City>();

        Dictionary<City, bool> visited = new Dictionary<City, bool>();

        int numCity;
        string line;
        string[] stringArr;
        line = Console.ReadLine();

        //System.Console.WriteLine(line);
        Int32.TryParse(line, out numCity);
        int cost;
        while (numCity > 0)
        {

            line = Console.ReadLine();

            stringArr = line.Split(' ');
            Int32.TryParse(stringArr[1], out cost);
            City a = new City("a", 1);
            a.name = stringArr[0];
            a.cost = cost;
            city.Add(stringArr[0], a);
            travelCost.Add(stringArr[0], -1);
            visited.Add(a, false);
            numCity--;
        }


        line = Console.ReadLine();

        Int32.TryParse(line, out numCity);
        while (numCity > 0)
        {

            line = Console.ReadLine();
            stringArr = line.Split(' ');

            city[stringArr[0]].childs.Add(stringArr[1]);
            numCity--;
        }

        List<string> sortList = new List<string>();

        foreach (string node in city.Keys)
        {
            explore(node, visited, sortList, city);
        }

        sortList.Reverse();

        List<string> questions = new List<string>();

        line = Console.ReadLine();

        Int32.TryParse(line, out numCity);
        while (numCity > 0)
        {
            line = Console.ReadLine();
            stringArr = line.Split(' ');
            string answer = findLowestCost(stringArr, city, sortList);
            //Console.WriteLine(question);
            if (answer == "NO" || answer == "-1")
            {
                Console.WriteLine("NO");
            }
            else
            {
                int j;
                Int32.TryParse(answer, out j);
                Console.WriteLine(j);
            }
            foreach (string s in sortList)
            {
                travelCost[s] = -1;
            }
            numCity--;
        }
    }

    private static string findLowestCost(string[] trip, Dictionary<string, City> city, List<string> sortList)
    {
        if (trip[0] == trip[1])
        {
            return "0";
        }

        travelCost[trip[0]] = 0;

        int firsTown=0;
        int secondTown=0;

        for (int town = 0; town < sortList.Count; town++)
        {
            if(sortList[town] == trip[0])
            {
                firsTown = town;
            }
            else if(sortList[town]== trip[1])
            {
                secondTown = town;
            }
        }
        if (secondTown < firsTown)
        {
            return "NO";
        }
        else
        {
            for(int town = firsTown; town<=secondTown; town++)
            {
                if (travelCost[sortList[town]] != -1)
                {
                    if (city[sortList[town]].childs.Count > 0)
                    {
                        for (int i = 0; i < city[sortList[town]].childs.Count; i++)
                        {
                            if (travelCost[city[sortList[town]].childs[i]] == -1)
                            {
                                travelCost[city[sortList[town]].childs[i]] = travelCost[sortList[town]] + city[city[sortList[town]].childs[i]].cost;
                            }
                            else
                            {
                                if (travelCost[city[sortList[town]].childs[i]] > travelCost[sortList[town]] + city[city[sortList[town]].childs[i]].cost)
                                {
                                    travelCost[city[sortList[town]].childs[i]] = travelCost[sortList[town]] + city[city[sortList[town]].childs[i]].cost;
                                }

                            }
                        }
                    }
                }
            }
            return travelCost[trip[1]].ToString();
        }
    }

    private static void explore(string node, Dictionary<City, bool> visited, List<string> sortList, Dictionary<string, City> city)
    {

        bool check = visited[city[node]];
        if (check == true)
        {
            if (sortList.Contains(node) == true) { }
            else
            {
                visited[city[node]] = true;
                sortList.Add(node);
                
            }
        }
        else
        {
            visited[city[node]] = true;
            if (city.ContainsKey(node) == true)
            {
                if (city[node].childs != null)
                {
                    foreach (string name in city[node].childs)
                    {
                        explore(name, visited, sortList, city);
                    }
                }
            }
            if (sortList.Contains(node) == false)
            {
                visited[city[node]] = true;
                sortList.Add(node);
                a++;
            }
        }
    }

}

class City
{
    public string name;
    public int cost;
    public List<string> childs;
    public City(string Name, int Cost)
    {
        name = Name;
        cost = Cost;
        childs = new List<string>();
    }
}









        

      