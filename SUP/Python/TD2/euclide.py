def euclide(a,b):
    while b != 0:
        if a < b:
            a, b = b, a
        a, b = b, a%b
    return a

print("Give a and b")
print(euclide(int(input()), int(input())))
