def two_pow(p):
    n = 2
    while p > 1:
        n *= 2
        p -= 1
    return n

def integer_to_twoscomp(n, p):
    result = ""
    while n > 0:
        if n - two_pow(p) > 0:
            result += "1"
            n -= two_pow(p)
        else:
            result += "0"
        p -= 1
    return result

print(integer_to_twoscomp(42, 8))
