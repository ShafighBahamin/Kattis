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
