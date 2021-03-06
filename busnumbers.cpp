#include <iostream>
#include <random>
#include <string>
using namespace std;

void solver(int n, int* nums) {
	int i = 0;

	while (i < n) {
		int min = nums[i];
		while ((i + 1 < n && nums[i] == nums[i + 1] - 1) || (nums[i] == nums[i + 1])) {
			i++;
		}
		int next = nums[i];
		if (next == min) {
			//a += "-" + to_string(min);
			if (i == n - 1) {
				cout << min << endl;
			}
			else
			{
				cout << min << " ";
			}
		}
		else if (min == next - 1) {
			if (i == n - 1) {
				cout << min << " " << next << endl;
			}
			else {
				cout << min << " " << next << " ";
			}
		}
		else
		{
			if (i == n - 1) {
				cout << min << "-" << next << endl;
			}
			else {
				cout << min << "-" << next << " ";
			}
		}
		i++;
	}
}

void merge(int* nums, int l, int m, int r) {

	int i = l;
	int k = l;
	int j = m + 1;

	int b[1000];

	while (i <= m && j <= r) {
		if (nums[i] <= nums[j]) {
			b[k++] = nums[i++];
		}
		else {
			b[k++] = nums[j++];
		}
	}

	while (i <= m) {
		b[k++] = nums[i++];
	}

	while (j <= r) {
		b[k++] = nums[j++];
	}

	i = l;
	for (i = l; i <= r; i++)
	{
		nums[i] = b[i];
	}
}
void mergesort(int* nums, int l, int r) {
	if (r > l) {
		int m = (l + r) / 2;
		mergesort(nums, l, m);
		mergesort(nums, m + 1, r);
		merge(nums, l, m, r);
	}
}
int main()
{
	int n;
	//n = 30;
	cin >> n;
	int* nums = (int*)malloc(n * sizeof(int));
	int i = 0;

	while (i < n) {
		cin >> nums[i++];
	}


	/*int k = 0;
	while (k < n) {
	nums[k++] = (rand() % 86) + 1;
	}*/

	mergesort(nums, 0, n - 1);

	/*k = 0;
	while (k < n) {
	cout << nums[k++] << endl;
	}
	*/

	solver(n, nums);

	return 0;
}