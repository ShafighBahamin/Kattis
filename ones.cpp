// ones.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include <iostream>

#include <string>

using namespace std;
int main()
{
	int n;
	unsigned long long answer, multi;

	//n = 1173;
	//cin >> n;
	while (cin >> n) {
		multi = 1;
		answer = 1;
			while (multi % n != 0) {
				multi *= 10;
				multi++;
				multi = multi % n;
				answer ++;
			
		}
			cout << answer << endl;
	}
	return 0;
}