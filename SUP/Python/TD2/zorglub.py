def zorglub(n):
    j, k, i = 1, 0, 1
    while i <= n:
        j *= i
        k += j
        i += 1
    return k

print("Give a positive number")
print(zorglub(int(input())))
