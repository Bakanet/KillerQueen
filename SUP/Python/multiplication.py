def multpos_n(x,y):
    n = 0
    while y != 0:
        n += x
        y -= 1
    return n

print("Give x and y")
print(multpos_n(int(input()), int(input())))

def multZ(x,y):
    if x == 0:
        return 0
    elif x == 1:
        return y
    elif x == -1:
        return -y
    else:
        if y < 0:
            x,y = -x, -y
        n = x
        while y > 1:
            n += x
            y -= 1
        return n

print("Give x and y")
print(multZ(int(input()), int(input())))
