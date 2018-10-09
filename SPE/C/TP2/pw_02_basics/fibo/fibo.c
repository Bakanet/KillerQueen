unsigned long fibo(unsigned long n) {
    unsigned int a = 0, b = 1;
    while (n > 1) {
        a += b;
        b += a;
        n -= 2;
    }
    return (n % 2 == 0) ? a : b;
}
