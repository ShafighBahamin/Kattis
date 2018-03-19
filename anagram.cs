using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        List<string> wordList = new List<string>();
        string word;
        // I dont want the numbers, just the words
        Console.ReadLine();
        while((word = Console.ReadLine()) != null)
        {
            wordList.Add(word);
        }
        sorter(wordList);
    }

    private static void sorter(List<string> wordList)
    {
        // two dictionaries one for unique and one for non unique
        Dictionary<int, string> wordDic = new Dictionary<int, string>();
        Dictionary<int, string> repeats = new Dictionary<int, string>();
        int key;

        // iterate the argument list and check for anagrams
        for (int i = 0; i < wordList.Count; i++)
        {
            char[] letterArray = wordList[i].ToCharArray();

            //sort the letters into alphabatcal order
            Array.Sort(letterArray); 
            
            // put the letters back together
            string WORD = new string(letterArray);

            key = WORD.GetHashCode();

            // if the unique dictionary contains the word already, take the word out of unique put it into non unique
            if (wordDic.ContainsValue(WORD) == true)
            {
                repeats.Add(key, WORD);
                wordDic.Remove(key);
            }
            // if neither dictionaries contain the word place the word into unique dictionary
            if (wordDic.ContainsValue(WORD) == false && repeats.ContainsValue(WORD) == false)
            {
                wordDic.Add(key, WORD);
            }
        }
        Console.WriteLine(wordDic.Count);
    }
}

