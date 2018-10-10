#include <stdio.h>
#include "isqrt.h"

int main() {
    for (int i = 0; i <= 200; i += 8) {
        printf("isqrt(%d) = %lu\n", i, isqrt(i));
    }
    return 0;
}