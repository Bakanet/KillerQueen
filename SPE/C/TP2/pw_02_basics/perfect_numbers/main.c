#include <stdio.h>
#include <stdlib.h>
#include <err.h>
#include "is_perfect_number.h"

int main(int argc, char** argv) {
    unsigned long param = strtoul(argv[1], NULL, 10);
    
    if (argc != 2 || param == 0)
        errx(1, "Error");

    for (unsigned long i = 0; i <= param; i++) {
        if (is_perfect_number(i))
            printf("%lu\n", i);
    }

    return 0;
}
