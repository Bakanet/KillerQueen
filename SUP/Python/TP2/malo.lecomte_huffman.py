__license__ = 'GolluM & Junior (c) EPITA'
__docformat__ = 'reStructuredText'
__revision__ = '$Id: huffman.py 2018-04-24'

"""
Huffman homework
2018
@author: login
"""

from algopy import bintree
from algopy import heap



################################################################################
## COMPRESSION

def buildfrequencylist(dataIN):
    """
    Builds a tuple list of the character frequencies in the input.
    """
    # FIXME
    pass


def buildHuffmantree(inputList):
    """
    Processes the frequency list into a Huffman tree according to the algorithm.
    """
    # FIXME
    pass


def encodedata(huffmanTree, dataIN):
    """
    Encodes the input string to its binary string representation.
    """
    # FIXME
    pass


def encodetree(huffmanTree):
    """
    Encodes a huffman tree to its binary representation using a preOrder traversal:
        * each leaf key is encoded into its binary representation on 8 bits preceded by '1'
        * each time we go left we add a '0' to the result
    """
    # FIXME
    pass


def tobinary(dataIN):
    """
    Compresses a string containing binary code to its real binary value.
    """
    # FIXME
    pass


def compress(dataIn):
    """
    The main function that makes the whole compression process.
    """
    
    # FIXME
    pass

    
################################################################################
## DECOMPRESSION

def decodedata(huffmanTree, dataIN):
    """
    Decode a string using the corresponding huffman tree into something more readable.
    """
    # FIXME
    pass

    
def decodetree(dataIN):
    """
    Decodes a huffman tree from its binary representation:
        * a '0' means we add a new internal node and go to its left node
        * a '1' means the next 8 values are the encoded character of the current leaf         
    """
    # FIXME
    pass


def frombinary(dataIN, align):
    """
    Retrieve a string containing binary code from its real binary value (inverse of :func:`toBinary`).
    """
    # FIXME
    pass


def decompress(data, dataAlign, tree, treeAlign):
    """
    The whole decompression process.
    """
    # FIXME
    pass
