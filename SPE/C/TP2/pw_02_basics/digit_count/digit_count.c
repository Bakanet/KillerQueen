unsigned char digit_count(unsigned long n) {
    unsigned char i = 0;
    for (; n > 0; n /= 10) {
        i++;
    }

    return i;
}
