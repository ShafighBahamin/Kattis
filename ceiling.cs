using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {

        List<Node> nodeList = new List<Node>();
        Dictionary<int, string> unique = new Dictionary<int, string>();
        int a = 0;
        string line;
        Console.ReadLine();
        while ((line = Console.ReadLine()) != null)
        {
            string[] integers = line.Split(new char[] { ' ' }, StringSplitOptions.None);
            numOfUniqueCielings(nodeList, unique, integers);
        }
        Console.WriteLine(unique.Count());
        Console.ReadLine();
    }
    private static void numOfUniqueCielings(List<Node> list, Dictionary<int, string> uniDic, string[] nums)
    {
        bool notMatch = true;
        int key;
        long firstNUM;
        long number;
        Int64.TryParse(nums[0], out firstNUM);
        string value = "";
        Node head = new Node(firstNUM);
        Node current = head;
        for (int i = 1; i < nums.Length; i++)
        {
            Int64.TryParse(nums[i], out number);
            current = head;
            while (current != null)
            {
                if (number <= current.number && current.left != null)
                {
                    current = current.left;
                    value = value + "0";
                }
                else if (number <= current.number && current.left == null)
                {
                    current.left = new Node(number);
                    value = value + "0";
                    break;
                }
                else if (number > current.number && current.right != null)
                {
                    current = current.right;
                    value = value + "1";
                }
                else if (number > current.number && current.right == null)
                {
                    current.right = new Node(number);
                    value = value + "1";
                    break;
                }
            }
        }
        if (list.Count > 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (sameTree(list[i], head) == true)
                {
                    notMatch = false;
                    break;
                }
                else
                {
                    notMatch = true;
                }
            }
        }
        list.Add(head);
        if (notMatch == true)
        {
            key = value.GetHashCode();
            uniDic.Add(key, value);
        }
    }

    private static bool sameTree(Node node1, Node node2)
    {
        if (node1 == null && node2 == null)
        {
            return true;
        }
        if ((node1 != null && node2 == null) || (node1 == null && node2 != null))
        {
            return false;
        }
        return sameTree(node1.left, node2.left) && sameTree(node1.right, node2.right);
    }

    static string numVal;
    public static string postOrder(Node node)
    {
        if(node == null)
        {
            return numVal;
        }
        if (node.left != null)
        {
            numVal = numVal + "0";
        }
        if (node.right != null)
        {
            numVal = numVal + "1";
        }
        if (node.left != null)
        {
            postOrder(node.left);
        }
        if (node.right != null)
        {
            postOrder(node.right);
        }
        return numVal;
    }
}

class Node
{
    public Node left;
    public long number;
    public Node right;

    public Node(long num)
    {
        number = num;
        this.left = null;
        this.right = null;
    }
}
