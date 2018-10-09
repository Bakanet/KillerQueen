#include <stdio.h>
#include "facto.h"

int main() {
	for(int i = 0; i <= 20; i++) {
		printf("facto(%d) = %lu\n",i, facto(i));
	}
	return 0;
}
