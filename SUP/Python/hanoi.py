def deplace(s,d):
    print(s, " -> ", d)

def hanoi(n, source, destination):
    if n == 1:
        deplace(source, destination)
    else:
        intermediaire = 6 - source - destination
        return hanoi(n-1, source, destination), deplace(source, destination), hanoi(n-1, intermediaire, destination)
