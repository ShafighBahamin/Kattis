// SumofOthers.cpp : Defines the entry point for the console application.
//


#include "stdafx.h"
#include <stdio.h>
#include <iostream>
#include <sstream>
#include <string>

using namespace std;
int main()
{
	string line;
	//ifstream f;
	//f.open("C:\\Users\\baham\\OneDrive\\Desktop\\sample.in");
	while (getline(cin, line))
	{
		stringstream ss(line);
		int nums[30] = { 0 };
		int i = 0;
		while (ss.good()) {
			ss >> nums[i];
			i++;
		}
		
		for (i = 0; i < 30; i++)
		{
			int ans = nums[i];
			int sum = 0;
			for (size_t j = 0; j < 30; j++)
			{
				if (j != i) {
					sum += nums[j];
				}
			}
			if (sum == ans) {
				cout << ans << "\n";
				break;
			}
		}
		int a = 0;
	}
}

/*
*/

