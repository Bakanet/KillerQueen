def search_char(c,s):
    i = len(s)
    while c != s[i]:
        i -= 1
    return i

print(search_char("h", "chat"))
