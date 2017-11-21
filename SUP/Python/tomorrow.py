def is_leap(y):
    return (y % 4 == 0 and y % 100 != 0) or y % 400 == 0

def days_in_month(m,y):
    if m == 2:
        if is_leap(y):
            return 29
        else:
            return 28
    else:
        return 30 + (m - m//8) % 2

def is_valid(d,m,y):
    if m < 1 or m > 12:
        return False
    else:
        return d <= days_in_month(m,y)

def tomorrow(d,m,y):
    if is_valid(d,m,y):
        d = d + 1
        if d + 1 > days_in_month(m,y):
            m = m + 1
            d = 1
        if m + 1 > 12:
            y = y + 1
            m = 1
        print("Tomorrow is ", m,"/", d,"/", y)
    else:
        print("The given date doesn't exists")

