__license__ = 'Nathalie (c) EPITA'
__docformat__ = 'reStructuredText'
__revision__ = '$Id: heap.py 2018-02-13'

"""
Heap homework
2018
@author: malo.lecomte
"""

#given function

def newHeap():
    """ returns a fresh new empty heap
    
       :rtype: list (heap)
    """
    return [None]
    
#---------------------------------------------------------------
    
def isEmpty(H):
    """ tests if H is empty
    
       :param H: the heap
       :rtype: bool
    """
    return len(H) == 1

def heapPush(H, elt, val):
    """ adds the pair (val, elt) to heap H and returns the heap modified
    
       :param H: The heap
       :param elt: The element to add
       :param val: The value associated to elt
       :rtype: list  (heap)
    """
    H.append((val, elt))
    posChild = len(H) - 1
    posParent = posChild // 2

    while posParent > 0 and H[posChild][0] < H[posParent][0]:
        H[posChild], H[posParent] = H[posParent], H[posChild]
        posChild = posParent
        posParent //= 2
    return H

    
def heapPop(H):
    """ returns and deletes the element of smallest value
    
       :param H: The heap
       :rtype: any (the removed element)
    
    """
    if isEmpty(H):
        raise Exception("Heap is empty")
    length = len(H)
    H[0], H[length - 1] = H[length - 1], H[0]
    elt = H.pop()
    posChild = length - 2
    posParent = posChild // 2
    
    #version non opti (on repete juste la meme chose que dans push donc la complexite est plus grande)
    #future version : 2i et 2i+1

    while posParent > 0 and H[posChild][0] < H[posParent][0]:
        H[posChild], H[posParent] = H[posParent], H[posChild]
        posChild = posParent
        posParent //= 2

    return elt

#---------------------------------------------------------------
def isHeap(T):
    """ tests whether T is a heap
    
       :param T: list (a complete tree)
       :rtype: bool
    
    """
    length = len(T) / 2 - 1
    i = 1
    while i < length and T[i][0] <= T[2*i][0] and T[i][0] <= T[2*i + 1][0]:
        i += 1
    return i >= length - 1
    
def heapify(H):
    """ makes H a heap (in place) - returns H modified
    
      :param H: list (a complete tree)
      :rtype: list (a heap)
    """    
    if not isHeap(H):
        length = len(H)
        for j in range(1, length // 2 - 1):
            for i in range(1, length):
                if H[i] != None:
                    minimum = i
                    posLeftChild = 2 * i
                    posRightChild = 2 * i + 1
                    if posLeftChild < length and H[posLeftChild] < H[minimum]:
                        minimum = posLeftChild
                    if posRightChild < length and H[posRightChild] < H[minimum]:
                        minimum = posRightChild
                    if minimum != i:
                        H[i], H[minimum] = H[minimum], H[i]
    
    return H

heap = heapPush([None, (2, 'G'), (2, 'I'), (8, 'F'), (5, 'B'), (9, 'J'), (20, 'A'), (10, 'C'), (6, 'H'), (12, 'D'), (15, 'E')], 'lol', 14)
heap2 = [None, (1,'B'), (3, 'K'), (4, 'N')]
heap3 = [None, (2, 'G'), (2, 'I'), (8, 'F'), (5, 'B'), (9, 'J'), (20, 'A'), (10, 'C'), (6, 'H'), (12, 'D'), (15, 'E')]
heap4 = heapPush(heapPush(heapPush(heapPush(heapPush(newHeap(),'A',6),'B',4),'C',5),'D',7),'E',3)
heap5 = [None, (2, 'I'), (5, 'B'), (8, 'F'), (6, 'H'), (9, 'J'), (20, 'A'), (10, 'C'), (15, 'E'), (12, 'D')]
heap6 = [None, (2, 'G'), (2, 'I'), (8, 'F'), (5, 'B'), (9, 'J'), (20, 'A'), (10, 'C'), (6, 'H'), (12, 'D'), (15, 'E')]
heap7 = [None, (1, 'A'), (3, 'B'), (2, 'C')]
heap8 = [None, (1, 'A'), (3, 'B'), (2, 'C'), (7, 'D'), (6, 'E'), (5, 'F'), (4, 'G')]
heap9 = [None, (20, 'A'), (5, 'B'), (10, 'C'), (12, 'D'), (15, 'E'), (8, 'F'), (2, 'G'), (6, 'H'), (2, 'I'), (9, 'J')]
print(isHeap(heap))
print(heap4)
print(isHeap(heap4))
print(isHeap(heap5))
print(heap6)
heapPop(heap6)
print(heap6)
print(isHeap(heap6))
isHeap(heap8)
heapPop(heap8)
print(heap8)
print(isHeap(heap8))
print(heap9)
heap10 = heapify(heap9)
print(heap10)
print(isHeap(heap10))