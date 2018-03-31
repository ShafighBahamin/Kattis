# -*- coding: utf-8 -*-
"""
Created on Sat Mar 31 11:08:05 2018

@author: baham
"""

import sys
import math

def solve(num):
    s = 1
    a = math.ceil(math.sqrt(num))
    for i in range(2, a):
        if(num % i == 0):
            j = num / i
            s+=i
            if(i!=j):
                s+=j
    if(a*a == num):
        s+=a
    if(num + 2 == s or num - 2 == s or num + 1 == s or num - 1 == s):
        print(str(num) + " almost perfect")
    elif(s == num):
        print(str(num) + " perfect")
        
    else:
        print(str(num) + " not perfect")


def main():
    #f = open("C:\\Users\\baham\\OneDrive\\Desktop\\sample.in", "r")
    for i in sys.stdin:
        solve(int(i))

    #for i in range(1, 1000000000):
        #solve(i)
if __name__ == "__main__":
    main()