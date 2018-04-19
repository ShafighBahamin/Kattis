# -*- coding: utf-8 -*-
"""
Created on Tue Apr 17 12:29:49 2018

@author: bahamin
"""
import sys

def main():
    
    a = 0
    ans = 0
    arr = []
    num = 0    
    for line in sys.stdin:
        if(a>0):
            arr.append(int(line)) 
        else:
            num = int(line)
            a+=1

    list.sort(arr)
    rem = num % 3
    for i in range(num-1, rem, -3):
        ans = ans + arr[i] + arr[i-1]
    if(rem == 1):
        ans = ans + arr[0]
    elif(rem == 2):
        ans = ans + arr[0] + arr[1]
    
    print(ans) 
    #for i in range(1, 1000000000):
        #solve(i)
if __name__ == "__main__":
    main()
    
    
    
