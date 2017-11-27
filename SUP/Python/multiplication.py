def multpos_n(x,y):
    n = 0
    while y != 0:
        n += x
        y -= 1
    return n

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
        c = 0
        while y > 1:
            n += x
            y -= 1
            c += 1
        print("S'effectue en", c, "boucles")
        return n

print("Give x and y")
print(multZ(int(input()), int(input())))


def mult_rec(x,y,acc,c):
    if y == 0:
        print("S'effectue en", c, "appels")
        return acc
    else:
        return mult_rec(x, y-1, acc + x, c+1)

print("Give x and y")
x, y = int(input()), int(input())

if y < 0:
    print(mult_rec (-x, -y, 0, 0))
else:
    print(mult_rec(x, y, 0, 0))
        
