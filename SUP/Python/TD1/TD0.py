def test(n):
    if n >= 100 and n < 1000 :
        return True
    else :
        return False

def sum_digits(n):
    a = n//100 
    b = n//10%10
    c = n%10
    return a+b+c

def product_digits(n):
    a, b, c = n//100, n//10%10, n%10
    return a*b*c

def abs(n):
    if n > 0:
        return n
    else:
        return -n

def loop(n):
    n = abs(n)
    if sum_digits(n) == product_digits(n):
        return n
    else:
        return loop(n+1)
