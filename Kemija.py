# -*- coding: utf-8 -*-
"""
Created on Tue Mar 27 20:53:49 2018

@author: baham
"""
import sys

def solve(s):
    ans = ''
    l = len(s)
    i = 0
    while(i < l):
        if((s[i] == 'a' or s[i] == 'e' or s[i] == 'i' or s[i] == 'o' or s[i] == 'u') and i<l-2):
            if(s[i+1] == 'p' and s[i+2] == s[i]):
                ans=ans+s[i]
                i += 3
        else:
            ans=ans+s[i]
            i += 1
    return ans
def main():
    
    #i = 'zepelepenapa papapripikapa'
    #print(solve(i))
    
    for i in sys.stdin:
        print(solve(i))
    
if __name__ == "__main__":
    main()