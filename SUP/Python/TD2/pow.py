def pow(x,n):
    if n == 0:
        return 1
    else:
        x2 = x
        while n > 1:
            x2 *= x
            n -= 1
        return x2

print("Give x and n")
print(pow(int(input()), int(input())))
