// beatTheSpread.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include <fstream>
#include <cmath>
#include <iostream>

using namespace std;

int main()
{
	int i, j;
	int n;
	cin >> n;
	int k = 0;
	while (k < n) {
		cin >> i;
		cin >> j;
		cout << i << " " << j << endl;
		bool solved = false;
		if (i < j) {
			cout << "impossible" << endl;
		}
		else {
			int a = 0;
			int b = i;
			while (solved == false && b>=a) {
				if (a + b == i && abs(a - b) == j) {
					cout << b << " " << a << endl;
					solved = true;
				}
				else {
					a++;
					b--;
				}
			}
			if (solved == false) {
				cout << "impossible" << endl;
			}
		}
		k++;
	}
    return 0;
}
