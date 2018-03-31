# -*- coding: utf-8 -*-
"""
Created on Wed Mar 28 22:15:07 2018

@author: baham
"""

import sys

def solve(line, y):
    ans = ""
    ans = ''.join(reversed(line))
    print(ans)

def main():
    
  
    numTests = int(sys.stdin.readline())
    
    
    for j in range(numTests):
        xBYy = sys.stdin.readline().split(' ')
        arr = []
        x = int(xBYy[0])
        y = int(xBYy[1])
        print("Test " + str(j+1))
        for lines in range(x):
            line = sys.stdin.readline();
            arr.append(line)
        for idx in range(x-1, -1, -1):
            solve(arr[idx], y)
          
           
if __name__ == "__main__":
    main()
            
