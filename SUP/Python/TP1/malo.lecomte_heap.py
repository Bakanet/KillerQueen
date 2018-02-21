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
    H[1], H[length - 1] = H[length - 1], H[1]
    elt = H.pop()[1]
    i, length2 = 1, length // 2                 # length // 2 to avoid computing it more than one time in the while loop

    while i < length2:
        if i + 1 < length2 and H[2 * i + 1] < H[2 * i] and H[i] > H[2 * i + 1]:
            H[i], H[2 * i + 1] = H[2 * i + 1], H[i]
            i = 2 * i + 1
        elif H[i] > H[2 * i]:
            H[i], H[2 * i] = H[2 * i], H[i]
            i = 2 * i

    return elt

#---------------------------------------------------------------
def isHeap(T):
    """ tests whether T is a heap
    
       :param T: list (a complete tree)
       :rtype: bool
    
    """
    length = len(T) // 2
    i = 1
    while i < length and T[i] <= T[2 * i] and (i + 1 >= length or T[i] <= T[2 * i + 1]):
        i += 1
    return i >= length
    
def heapify(H):
    """ makes H a heap (in place) - returns H modified
    
      :param H: list (a complete tree)
      :rtype: list (a heap)
    """
    # Heap sort method
    if not isHeap(H):
        length = len(H)
        c = 1
        while c < length // 2 - 1:                                                  # we need to iterate only on half of the list (2 * i, 2 * i + 1)
            for i in range(1, length):
                if H[i] != None:
                    minimum, posLeftChild, posRightChild = i, 2 * i, 2 * i + 1
                    if posLeftChild < length and H[posLeftChild][0] < H[minimum][0]:      # search minimum between root and left child
                        minimum = posLeftChild
                    if posRightChild < length and H[posRightChild][0] < H[minimum][0]:    # search minimum between root and right child
                        minimum = posRightChild
                    if minimum != i:                                                # if root is minimum, we don't have to swap
                        H[i], H[minimum] = H[minimum], H[i]
            c += 1
    
    return H

T = [None, (20, 'A'), (5, 'B'), (10, 'C'), (12, 'D'), (15, 'E'), (8, 'F'), (2, 'G'), (6, 'H'), (2, 'I'), (9, 'J')]
print(isHeap(T))
print(heapify(T))
print(isHeap(T))
print(isHeap([None]))
print(heapPop(T))
print(isHeap(T))