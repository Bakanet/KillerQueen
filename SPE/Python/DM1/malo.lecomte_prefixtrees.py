__license__ = 'Nathalie (c) EPITA'
__docformat__ = 'reStructuredText'
__revision__ = '$Id: prefixTrees.py 2018-02-14'

"""
Prefix Trees homework
2018
@author: malo.lecomte
"""


from algopy import tree
import prefixtreesexample as pt


################################################################################
## MEASURES
                        
def countwords(T):
    """ count words in dictionnary T
    
    :param T: The prefix tree
    :rtype: int
    :Example:
    >>> countwords(Tree1)
    11
    """
    
    nb = 1 if T.key[1] else 0
    for child in T.children:
        nb += countwords(child)
    return nb

def longestwordlength(T):
    """ longest word length
    
    :param T: The prefix tree
    :rtype: int
    :Example:
    >>> longestwordlength(Tree1)
    6
    """
    
    return tree.height(T)

def averagelength(T):
    """ average word length
    
    :param T: The prefix tree
    :rtype: float
    :Example:
    >>> averagelength(Tree1)
    4.636363636363637
    """
    
    (lenw, nbw) = _averagelength(T)
    return  lenw/nbw

def _averagelength(T, lenwords=0):
    if T.key[1] and not T.children:
        return (lenwords, 1)
    else:
        nbwords = 1 if T.key[1] else 0
        lenwsum = 0
        for child in T.children:
            (lenw, nbw) = _averagelength(child, lenwords + 1)
            lenwsum += lenw
            nbwords += nbw
        return (lenwsum, nbwords)
    
print(_averagelength(pt.Tree1)) 

###############################################################################
## Researches


def searchword(T, word):
    """ search for a word in dictionary
    
    :param T: The prefix tree
    :param word: The word to search for
    :rtype: bool
    :examples:
    >>> searchword(Tree1, "fabulous")
    False
    >>> searchword(Tree1, "Famous")
    True
    """
    
    # FIXME
    return None

###############################################################################
## Lists

def wordlist(T):
    """ generate the word list
    
    :param T: The prefix tree
    :rtype: list
    :example:
    >>> print(wordlist(Tree1))
    ['case', 'cast', 'castle', 'circle', 'city', 'come', 'could', 'fame', 'famous', 'fan', 'fancy']
    """
    
   # FIXME
    return None

def longestwords(T):
    """ search for the longest words in dictionary
    
    :param T: The prefix tree
    :rtype: list
    :examples: # order in result does not matter
    >>> longestwords(Tree1)
    ['castle', 'circle', 'famous']
    """
    
    # FIXME
    return None
    
def completion(T, prefix):
    """ generate the list of words with a common prefix
    
    :param T: The prefix tree
    :param pref: the prefix
    :rtype: list
    :examples: # result elements can have different case...
    >>> completion(Tree1, "Fan")
    ['Fan', 'Fancy']
    >>> completion(Tree1, "CI")
    ['Circle', 'City']
    >>> completion(Tree1, "what")
    []
    """
    
    # FIXME
    return None

def treetofile(T, filename):
    """ save the dictionary in a file
    
    :param T: The prefix tree
    :param filename: the file name
    :example:
    >>> treeToFile(Tree1, "test.txt")
    # give the same file as "textFiles/wordList1.txt" but in alphabetic order
    """
    
    # FIXME


###############################################################################
## Build Tree

def addword(T, word):
    """ add a word in dictionary
    
    :param T: The prefix tree
    :param word: The word to add
    """
    
    # FIXME

def treefromfile(filename):
    """ build the prefix tree from a file of words
    
    :param filename: The file name
    :rtype: Tree
    """
    
    # FIXME
    return None
