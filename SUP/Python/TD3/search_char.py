def search_char(c,s):
    i = len(s) - 1
    while c != s[i] and i >= 0:
        i -= 1
    return i

def search_char2(c,s):
    b = -1
    for i in s:
        if i == c:
            b = i
    return b
