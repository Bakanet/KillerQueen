def fibo(n):
    x, i, j, k = 0, 1, 1, 0
    while x <= n:
        i = j
        j = k
        k = i + j
        x += 1
    return k

print("Give n")
print(fibo(int(input())))
