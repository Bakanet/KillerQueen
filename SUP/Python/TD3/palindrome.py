def pal0(s):
    l, i = len(s) - 1, 0
    while i < l and s[i] == s[l-i]:
        i += 1
    return i >= l

def pal1(s):
    l, i, string = len(s) - 1, 0, ""
    while i < l + 1:
        if s[i] != " ":
            string += s[i]
        i += 1
    return pal0(string)

def accents(c):
    if c in ('à','â','ä'):
        return 'a'
    elif c in ('é','è','ê','ë'):
        return 'e'
    elif c in ('ô','ö'):
        return 'o'
    elif c in ('î','ï'):
        return 'i'

def punctuation(s):
    l, i, string = len(s) - 1, 0, ""
    while i < l + 1:
        if s[i] != (" ", "'", ".", "!", "?", ",", ";", ":"):
            string += s[i]
        i += 1
    return string.lower()

def pal3(s):
    

print(pal3("Tu l'as trop écrasé César, ce port salut."))
    
