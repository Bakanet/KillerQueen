__license__ = 'Nathalie (c) EPITA'
__docformat__ = 'reStructuredText'
__revision__ = '$Id: heap.py 2018-02-13'

"""
Heap homework
2018
@author: login
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
    if not isEmpty(H):
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




def __posMin(H):
    min = H[0]
    for i in range(1, len(H)):
        if min < H[i]:
            min = H[i]
    return i

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
    #FIXME

heap = heapPush([None, (2, 'G'), (2, 'I'), (8, 'F'), (5, 'B'), (9, 'J'), (20, 'A'), (10, 'C'), (6, 'H'), (12, 'D'), (15, 'E')], 'lol', 14)
heap2 = [None, (1,'B'), (3, 'K'), (4, 'N')]
heap3 = [None, (2, 'G'), (2, 'I'), (8, 'F'), (5, 'B'), (9, 'J'), (20, 'A'), (10, 'C'), (6, 'H'), (12, 'D'), (15, 'E')]
heap4 = heapPush(heapPush(heapPush(heapPush(heapPush(newHeap(),'A',6),'B',4),'C',5),'D',7),'E',3)
print(isHeap(heap))
print(heap4)