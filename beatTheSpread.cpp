// beatTheSpread.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"


#include <iostream>
#include <stdio.h>

using namespace std;

void beat_s(int i, int j) {


	if (i >= 0) {
		int a = i / 2 + j / 2;
		cout << a << " " << a-j << endl;
	}
	else {
		cout << "impossible" << endl;
	}
}



int main()
{
	int i, j;
	long n;
	//i = 28;
	//j = 8;
	//beat_s(i, j);
	cin >> n;

	long k = 0;
	while (k < n) {
		cin >> i, j;
		int a = ( i+ j )/ 2;
		int b = a - j;
		if (2*a == i+j && b >= 0) {
			cout << a << " " << a - j << endl;
		}
		else {
			cout << "impossible" << endl;
		}
		k++;
	}
    return 0;
}

