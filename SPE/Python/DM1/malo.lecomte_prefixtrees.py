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
        if T.key[1]:
            nbwords = 1
            lenwords *= 2
        else:
            nbwords = 0

        lenwsum = 0
        for child in T.children:
            (lenw, nbw) = _averagelength(child, lenwords + 1)
            lenwsum += lenw
            nbwords += nbw
        return (lenwsum, nbwords)

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
    word = word.lower()
    b = False
    for child in T.children:
        b = b or _searchword(child, word, len(word))
    return b


def _searchword(T, word, length, height=0):
    if T.key[0] != word[height]:
        return False
    elif length-1 == height:
        return T.key[1]
    else:
        b = False
        for child in T.children:
            b = b or _searchword(child, word, length, height + 1)
        return b

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

    l = []
    _wordlist(T, l)
    return l

def _wordlist(T, l, str=""):
    if T.key[1]:
        l.append(str + T.key[0])
    for child in T.children:
        _wordlist(child, l, str + T.key[0])

wordlist(pt.Tree1)

def longestwords(T):
    """ search for the longest words in dictionary

    :param T: The prefix tree
    :rtype: list
    :examples: # order in result does not matter
    >>> longestwords(Tree1)
    ['castle', 'circle', 'famous']
    """

    maxsize = tree.height(T)
    l = []
    _longestwords(T, maxsize, l)
    return l

def _longestwords(T, maxsize, l, str="", height=0):
    if height == maxsize:
        l.append(str + T.key[0])
    else:
        for child in T.children:
            _longestwords(child, maxsize, l, str + T.key[0], height + 1)

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

    if filename != '':
        f = open(filename, 'w')
        for word in wordlist(T):
            f.write(word + '\n')
        f.close()

###############################################################################
## Build Tree

def addword(T, word):
    """ add a word in dictionary

    :param T: The prefix tree
    :param word: The word to add
    """

    length = len(word)
    if length > 0:
        word = word.lower()
        _addword(T, word, length)

def _addword(T, word, length, height=0):
    if height < length:
        if T.nbchildren > 0:
            i = 0
            nb = T.nbchildren
            children = []
            while i < nb and word[height] > T.children[i].key[0]:
                children.append(T.children[i])
                i += 1
            if i == nb:
                B = tree.Tree((word[height], height == length - 1))
                children.append(B)
                _addword(B, word, length, height + 1)
            else:
                if T.children[i].key[0] == word[height]:
                    if height == length - 1:
                        T.children[i].key = (T.children[i].key[0], True)
                    _addword(T.children[i], word, length, height + 1)
                else:
                    B = tree.Tree((word[height], height == length - 1))
                    children.append(B)
                    _addword(B, word, length, height + 1)
                while i < nb:
                    children.append(T.children[i])
                    i += 1
            T.children = children
        else:
            B = tree.Tree((word[height], height == length - 1))
            T.children.append(B)
            _addword(B, word, length, height + 1)

def treefromfile(filename):
    """ build the prefix tree from a file of words

    :param filename: The file name
    :rtype: Tree
    """

    f = open(filename, 'r')
    str, i = f.read(), 0
    length = len(str)
    str2 = ""
    B = tree.Tree(('', False))

    while i < length:
        if str[i] == '\n':
            addword(B, str2)
            str2 = ""
        elif i == length - 1:
            addword(B, str2 + str[i])
        else:
            str2 += str[i]
        i += 1

    return B
