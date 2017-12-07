def mirror(n):
    x = 0
    while n != 0:
        x = x * 10 + n % 10
        n //= 10
    return x

print("Give a positive number")
print(mirror(int(input())))
        
