using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        //System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\Shafigh\\Desktop\\bank-02.in");
        string line;
        line = Console.ReadLine();
        string[] strVec;
        strVec = line.Split(' ');
        int numPeople;
        int amount;
        int place = 0;
        int numLoops;
        Int32.TryParse(strVec[0], out numPeople);
        Int32.TryParse(strVec[1], out numLoops);
        person[] peoples = new person[numPeople];
        while((line = Console.ReadLine()) != null)
        {
            strVec = line.Split(' ');
            Int32.TryParse(strVec[0], out amount);
            Int32.TryParse(strVec[1], out numPeople);
            person a = new person(amount, numPeople);
            peoples[place] = a;
            place++;

        }
        int answer = 0;
        for(int a=numLoops; a>=0; a--)
        {
            int removeIndex = -1;
            int max = 0;
            for(int b = 0; b<peoples.Length; b++)
            {
                if (peoples[b].cash >= max && peoples[b].left == false && peoples[b].time>=a)
                {
                    max = peoples[b].cash;
                    removeIndex = b;
                }
            }
            if (removeIndex == -1)
            {

            }
            else
            {
                answer += max;
                peoples[removeIndex].left = true;
            }
        }
        Console.WriteLine(answer);
    }
}
//private static void adder()
//{
//    Random rand = new Random();
//    Random bigInt = new Random();
//    PriorityQueue heap = new PriorityQueue(48);
//    for (int i = 0; i < 100001; i++)
//    {
//        heap.add(rand.Next(0, 47), rand.Next(1, 5555555));
//    }
//    heap.printer();
//}
//class PriorityQueue
//{
//    private List<int>[] money;
//    public PriorityQueue(int numPQ)
//    {
//        money = new List<int>[numPQ];
//        for(int i = 0; i< money.Length; i++)
//        {
//            money[i] = new List<int>();
//        }
//    }
//    public void add(int index, int num)
//    {
//        money[index].Add(num);
//        int place = money[index].Count-1;
//        while (money[index].Count-1 > 1 && money[index][place] > money[index][place/2])
//        {
//            int temp = money[index][place];
//            money[index][place] = money[index][place / 2];
//            money[index][place / 2] = temp;
//            place = place / 2;
//        }
//    }
//    public int deleteMin(int index)
//    {
//        int root;
//        int num = money[index][money[index].Count-1];
//        money[index][0] = money[index][money[index].Count-1];
//        money[index].RemoveAt(money[index].Count-1);
//        int f = 0;
//        while (f < money[index].Count / 2)
//        {
//            if(2*f+2 < money[index].Count-1 && money[index][2*f+1] < money[index][2 * f + 2])
//            {
//                root = 2 * f + 2;
//            }
//            else
//            {
//                root = 2 * f + 1;
//            }
//            if(root < money[index].Count-1 && money[index][f] < money[index][root])
//            {
//                int temp = money[index][f];
//                money[index][f] = money[index][root];
//                money[index][root] = temp;
//                f = root;
//            }
//            else
//            {
//                break;
//            }
//        }
//        return num;
//    }

//    internal void answer()
//    {
//        int max = 0;
//        for(int a = money.Length-1; a>=0; a--)
//        {
//            int index = a;
//            for(int j=a; j < money.Length; j++)
//            {
//                if(money[j].Count != 0)
//                {
//                    if(money[index].Count == 0 || money[j][0] > money[index][0])
//                    {
//                        index = j;
//                    }
//                }
//            }
//            if (money[index].Count != 0)
//            {
//                max += money[index][0];
//                deleteMin(index);
//            }
//        }
//        Console.WriteLine(max);
//    }

//    internal void printer()
//    {
//        for(int a=0; a < 1; a++)
//        {
//            for(int b = 0; b<money[a].Count;b++)
//            {
//                Console.WriteLine(money[a][b]);
//                deleteMin(a);
//            }
//        }
//    }
//}
class person
{
    public int cash;
    public int time;
    public bool left;
    public person(int Cash, int Time)
    {
        cash = Cash;
        time = Time;
        left = false;
    }
}