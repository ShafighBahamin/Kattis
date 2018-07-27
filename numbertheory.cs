using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static Dictionary<BigInteger, int> carNums = new Dictionary<BigInteger, int>() { { 561, 0 }, { 1105, 0 }, { 1729, 0 }, { 2465, 0 }, { 2821, 0 }, { 6601, 0 }, { 8911, 0 }, { 10585, 0 }, { 15841, 0 }, { 29341, 0 }, { 41041, 0 }, { 46657, 0 }, { 52633, 0 }, { 62745, 0 }, { 63973, 0 }, { 75361, 0 }, { 101101, 0 }, { 115921, 0 }, { 126217, 0 }, { 162401, 0 }, { 172081, 0 }, { 188461, 0 }, { 252601, 0 }, { 278545, 0 }, { 294409, 0 }, { 314821, 0 }, { 334153, 0 }, { 1, 0 } };
    static void Main(string[] args)
    {
        //System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\Shafigh\\Desktop\\test2.in");
        string line;
        System.Numerics.BigInteger a;
        System.Numerics.BigInteger b;
        System.Numerics.BigInteger c;
        while ((line = Console.ReadLine()) != null)
        {
            string[] strVec = line.Split(' ');
            if (strVec[0] == "gcd")
            {
                BigInteger.TryParse(strVec[1], out a);
                BigInteger.TryParse(strVec[2], out b);
                a = gcd(a, b);
                Console.WriteLine(a);
            }
            else if (strVec[0] == "exp")
            {
                System.Numerics.BigInteger.TryParse(strVec[1], out a);
                System.Numerics.BigInteger.TryParse(strVec[2], out b);
                System.Numerics.BigInteger.TryParse(strVec[3], out c);
                a = exp(a, b, c);
                Console.WriteLine(a);
            }
            else if (strVec[0] == "inverse")
            {
                System.Numerics.BigInteger.TryParse(strVec[1], out a);
                System.Numerics.BigInteger.TryParse(strVec[2], out b);
                a = inverse(a, b);
                if (a > -1)
                {
                    Console.WriteLine(a);
                }
                else
                {
                    Console.WriteLine("none");
                }
            }
            else if (strVec[0] == "isprime")
            {
                System.Numerics.BigInteger.TryParse(strVec[1], out a);
                isPrime(a);
            }
            else if (strVec[0] == "key")
            {
                System.Numerics.BigInteger.TryParse(strVec[1], out a);
                System.Numerics.BigInteger.TryParse(strVec[2], out b);
                key(a, b);
            }
        }
    }

    private static void key(System.Numerics.BigInteger p, System.Numerics.BigInteger q)
    {
        System.Numerics.BigInteger N = p * q;
        Console.WriteLine(N);
        System.Numerics.BigInteger phi = (p - 1) * (q - 1);
        System.Numerics.BigInteger e = 0;
        for (System.Numerics.BigInteger i = 2; i < phi; i++)
        {
            if (gcd(i, phi) == 1)
            {
                Console.WriteLine(i);
                e = i;
                break;
            }
        }
        Console.WriteLine(inverse(e, phi));
    }

    private static void isPrime(System.Numerics.BigInteger a)
    {
        int count = 0;
        System.Numerics.BigInteger[] nums = new System.Numerics.BigInteger[3];
        nums[0] = 2;
        nums[1] = 3;
        nums[2] = 5;
        foreach (BigInteger num in nums)
        {
            if (BigInteger.ModPow(num, a-1, a) == 1)
            {
                count++;
            }
        }
        if (count == 3 && !carNums.ContainsKey(a))
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
    
    private static System.Numerics.BigInteger inverse(System.Numerics.BigInteger a, System.Numerics.BigInteger N)
    {
        System.Numerics.BigInteger[] nums = new System.Numerics.BigInteger[3];
        nums = ee(a, N, nums);
        if(nums[2] == 1)
        {
            while (nums[0] < 0)
            {
                nums[0] =nums[0] + N;
            }
            return(nums[0] % N);
        }
        else
        {
            return -1;
        }
    }

    private static System.Numerics.BigInteger[] ee(System.Numerics.BigInteger a, System.Numerics.BigInteger b, System.Numerics.BigInteger[] nums)
    {
        if(b == 0)
        {
            nums[0] = 1;
            nums[1] = 0;
            nums[2] = a;
            return nums;
        }
        else
        {
            nums = ee(b, a % b, nums);
            System.Numerics.BigInteger x = nums[0];
            nums[0] = nums[1];
            nums[1] = x - (a / b) * nums[1];
            return nums;
        }
    }

    private static System.Numerics.BigInteger exp(System.Numerics.BigInteger x, System.Numerics.BigInteger y, System.Numerics.BigInteger N)
    {
        System.Numerics.BigInteger z;
        if (y == 0)
        {
            return 1;
        }
        else
        {
            z = exp(x, y / 2, N);
            if(y%2 == 0)
            {
                return (z * z) % N;
            }
            else
            {
                return (x * z * z) % N;
            }
        }
    }

    private static System.Numerics.BigInteger gcd(System.Numerics.BigInteger a, System.Numerics.BigInteger b)
    {
        if (b == 0)
        {
            return a;
        }
        else
        {
            return gcd(b, a % b);
        }
    }
}

