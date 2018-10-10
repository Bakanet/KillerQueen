unsigned long divisor_sum(unsigned long n) {
    if (n == 1)
        return 0;

    unsigned long result = 0;
    for (unsigned long i = 2; i*i <= n; ++i) {
        if (n % i == 0) {
            if (i == n/i)
                result += i;
            else
                result += i + n/i;
        }
    }
    
    return result + 1;
}
