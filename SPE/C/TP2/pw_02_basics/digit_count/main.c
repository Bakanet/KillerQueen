#include <stdio.h>
#include "digit_count.h"

int main() {
    for (int n = 0; n < 64; n++) {
        unsigned long arg = (unsigned long) (1) << n;
        printf("digit_count(%lu) = %i\n", arg, digit_count(arg));
    }
    
    return 0;
}
