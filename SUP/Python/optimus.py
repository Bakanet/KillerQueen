def is_prime(x):
    if x <= 1:
        raise Exception("is_prime: invalid argument")
    else:
        i = 2
        n = True
        while i*i < x:
            if x % i == 0:
                n = False
            i += 1
        return n

print(is_prime(11))
