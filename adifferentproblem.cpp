// adifferentproblem.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <iostream>

using namespace std;
int main()
{
	// take two long longs and while we are inputing 
	long long i, j;
	while (cin >> i >> j) {
		// if i is less than j than j minus i else i - j
		if (i <= j) {
			cout << j - i << endl;
		}
		else {
			cout << i - j << endl;
		}

	}
    return 0;
}

