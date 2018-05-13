__license__ = 'GolluM & Junior (c) EPITA'
__docformat__ = 'reStructuredText'
__revision__ = '$Id: huffman.py 2018-04-24'

"""
Huffman homework
2018
@author: malo.lecomte
"""

from algopy import bintree
from algopy import heap
from algopy import prettyPrint



################################################################################
## COMPRESSION

def buildfrequencylist(dataIN):
    l = []
    for c in dataIN:
        b, i, length = True, 0, len(l)
        while i < length and b:                 #parcours de la liste
            if l[i][1] == c:
                l[i] = (l[i][0] + 1, l[i][1])
                b = False
            i += 1
        if (b):
            l.append((1, c))
    return l
    
def __bubbleSort(inputList):
    for i in range(len(inputList) - 1, 0, -1):
        for j in range(i):
            if inputList[j] < inputList[j + 1]:
                inputList[j], inputList[j + 1] = inputList[j + 1], inputList[j]
    return inputList

def buildHuffmantree(inputList):
    """
    Processes the frequency list into a Huffman tree according to the algorithm.
    """
    l = __bubbleSort(inputList)
    tree = []
    length = len(l) - 1
    for i in range(length + 1):
        tree.append((l[i][0], bintree.BinTree(l[i][1], None, None)))
    while length > 0:
        B = bintree.BinTree(None, tree[length - 1][1], tree[length][1])
        key =  tree[length][0] + tree[length - 1][0]
        tree.pop()
        tree.pop()
        tree.append((key, B))
        length -= 1
        temp = tree[length]
        j = length
        while j > 0 and key > tree[j - 1][0]:
            tree[j] = tree[j - 1]
            j -= 1
        tree[j] = temp
    return tree[0][1]

def __binList(B, binString, char, l):
    if B.key != None:
        if B.key == char:
            l.append((char, binString))
    
    else:
        __binList(B.left, binString + "0", char, l)
        __binList(B.right, binString + "1", char, l)

def encodedata(huffmanTree, dataIN):
    """
    Encodes the input string to its binary string representation.
    """
    result = ""
    l = []
    for char in dataIN:                             #build list of chars and their representation
        i, length = 0, len(l)
        while i < length and l[i][0] != char:
            i += 1
        if (i >= length):
            __binList(huffmanTree, "", char, l)
        result += l[i][1]
    return result



def encodetree(huffmanTree):
    """
    Encodes a huffman tree to its binary representation using a preOrder traversal:
        * each leaf key is encoded into its binary representation on 8 bits preceded by '1'
        * each time we go left we add a '0' to the result
    """
    if huffmanTree.key != None:
        binary = ""
        value = ord(huffmanTree.key)

        while value > 0:
            if value % 2 == 0:
                binary = '0' + binary
            else:
                binary = '1' + binary
            value //= 2
        
        length = len(binary)
        while length < 8:
            binary = '0' + binary
            length += 1
        
        return '1' + binary
    
    else:
        left = '0' + encodetree(huffmanTree.left)
        right = encodetree(huffmanTree.right)
        return left + right


def tobinary(dataIN):
    """
    Compresses a string containing binary code to its real binary value.
    """
    length, i = len(dataIN), 0
    align = 8 - (length % 8)
    result = ""
    while i < length - (8 - align):
        binary = "0b"
        for j in range(8):
            binary += dataIN[i + j]
        result += chr(int(binary, 2))
        i += 8
    
    for j in range(8 - align):
        binary += dataIN[i + j]
    result += chr(int(binary, 2))

    return (result, align)



def compress(dataIn):
    """
    The main function that makes the whole compression process.
    """
    freqList = buildfrequencylist(dataIn)
    HT = buildHuffmantree(freqList)
    returnData = encodedata(HT, dataIn)
    returnTree = encodetree(HT)

    return (tobinary(returnData), tobinary(returnTree))

    
################################################################################
## DECOMPRESSION
def decodedata(huffmanTree, dataIN):
    """
    Decode a string using the corresponding huffman tree into something more readable.
    """
    i, length, result, HT, b = 0, len(dataIN), "", huffmanTree, True

    while i < length + 1 and b:
        if HT.key != None:
            result += HT.key
            HT = huffmanTree
            if i == length:
                b = False
        elif dataIN[i] == '0':
            HT = HT.left
            i += 1
        else:
            HT = HT.right
            i += 1
    
    return result

def __parse(dataIN, index):
    result = ""
    for i in range(8):
        result += dataIN[index + i]
    return chr(int(result, 2))

def __construct(dataIN, i = 0):
    B = bintree.BinTree(None, None, None)
    if dataIN[i] == '1':
        B.key = __parse(dataIN, i + 1)
        return (B, i + 8)   
    else:
        (B.left, i) = __construct(dataIN, i + 1)
        (B.right, i) = __construct(dataIN, i + 1)
        return (B, i)

def decodetree(dataIN):
    """
    Decodes a huffman tree from its binary representation:
        * a '0' means we add a new internal node and go to its left node
        * a '1' means the next 8 values are the encoded character of the current leaf         
    """
    (B, i) = __construct(dataIN)
    return B

def frombinary(dataIN, align):
    """
    Retrieve a string containing binary code from its real binary value (inverse of :func:`toBinary`).
    """
    i, length, result = 0, len(dataIN), ""
    while i < length - 1:
        value, binary = ord(dataIN[i]), ""
        while value > 0:
            if value % 2 == 0:
                binary = '0' + binary
            else:
                binary = '1' + binary
            value //= 2

        length2 = len(binary)
        while length2 < 8:
            binary = '0' + binary
            length2 += 1

        result += binary
        i += 1
    
    value, binary = ord(dataIN[length - 1]), ""
    for j in range(8 - align):
        if value % 2 == 0:
            binary = '0' + binary
        else:
            binary = '1' + binary
        value //= 2

    result += binary
    return result

def decompress(data, dataAlign, tree, treeAlign):
    """
    The whole decompression process.
    """
    treeBin = frombinary(tree, treeAlign)
    dataBin = frombinary(data, dataAlign)
    HT = decodetree(treeBin)
    return decodedata(HT, dataBin)