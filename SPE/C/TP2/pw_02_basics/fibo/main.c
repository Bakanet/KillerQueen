#include <stdio.h>
#include "fibo.h"

int main() {
	for (int i = 0; i <= 90; i++) {
		printf("fibo(%d) = %lu\n", i, fibo(i));
	}
	return 0;
}
