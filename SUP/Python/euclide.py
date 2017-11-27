def euclide(a,b):
    if a < b:
        a, b = b, a
    while b != 0:
        a, b = a%b, a//b
    return a

print(euclide(89,1))
        
