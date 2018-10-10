#include "is_perfect_number.h"
#include "divisor_sum.h"

int is_perfect_number(unsigned long n) {
    return (n == perfect_number(n)) ? 1 : 0;
}
