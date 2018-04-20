// CD.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

const int MAX_SIZE = 1000100;

using namespace std;
int main()
{
	int done = 1;
	int first[MAX_SIZE];
	int sec[MAX_SIZE];
	int ja, ji, i, ans, j;
	scanf("%d%d", &ja, &ji);

	while (done) {
		i = j = ans = 0;
		for (int i = 0; i < ja; i++)
		{
			scanf("%d", &first[i]);
		}
		for (int i = 0; i < ji; i++)
		{
			scanf("%d", &sec[i]);
		}

		while (i < ja && j < ji) {

			if (first[i] == sec[j]) {
				ans++;
				i++;
				j++;
			}
			else if (first[i] < sec[j]) {
				i++;
			}
			else {
				j++;
			}

		}
		cout << ans << endl;
		scanf("%d%d", &ja, &ji);
		if (ja == 0 && ji == 0) {
			done = 0;
		}
	}
	return 0;
}


//ifstream infile("C:\\Users\\baham\\OneDrive\\Desktop\\TestData\\cd\\a.in");
