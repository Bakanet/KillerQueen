# -*- coding: utf-8 -*-
"""
Created on Sept. 2016

@author: nb, gd
"""

class TreeAsBin:
    """
    Simple class for (General) Trees 
    represented as Binary Trees (first child - right sibling)
    """

    def __init__(self, key, child=None, sibling=None):
        """
        Init Tree
        """
        self.key = key
        self.child = child
        self.sibling = sibling


def tutoEx1():
    C1 = TreeAsBin(3, TreeAsBin(-6, None, TreeAsBin(10)))
    C2 = TreeAsBin(8, TreeAsBin(11, TreeAsBin(0, None, TreeAsBin(4)), 
                                TreeAsBin(2, None, TreeAsBin(5))))
    C3 = TreeAsBin(9)
    C1.sibling = C2
    C2.sibling = C3
    return TreeAsBin(15, C1, None)
    
# measures
#------------------------------------------------------------------------------

def size(B):
    s = 1
    C = B.child
    while C:
        s += size(C)
        C = C.sibling
    return s
    
def size2(B):
    if B == None:
        return 0
    else:
        return 1 + size2(B.child) + size2(B.sibling)


# height
    
def height(B):
    h = -1
    C = B.child
    while C:
        h = max(h, height(C))
        C = C.sibling
    return h + 1

def height2(B):
    if B == None:
        return -1
    else:
        return max(1 + height2(B.child), height2(B.sibling))

# External Path Length


def epl(B, h=0):
    if B.child:
        length = 0
        C = B.child
        while C:
            length += epl(C, h+1)
            C = C.sibling
        return length
    else:
        return h


def __loadtree(s, typelt, i=0): 
    if i < len(s) and s[i] == '(':
        i = i + 1 # to pass the '('
        key = ""
        while not (s[i] in "()"):
            key = key + s[i]
            i += 1
        B = TreeAsBin(typelt(key))
        (B.child, i) = __loadtree(s, typelt, i)
        i = i + 1   # to pass the ')'
        (B.sibling, i) = __loadtree(s, typelt, i)
        return (B, i)
    else:
        return (None, i)


def loadtree(path, typelt=int):
    # Open file and get full content
    file = open(path, 'r')
    content = file.read()
    # Remove all whitespace characters for easier parsing
    content = content.replace('\n', '').replace('\r', '') \
                     .replace('\t', '').replace(' ', '')
    file.close()
    # Parse content and return tree
    (T, _) = __loadtree(content, typelt)
    return T


def dot(ref):
    """Write down dot format of tree.

    Args:
        ref (TreeAsBin).

    Returns:
        str: String storing dot format of tree.

    """

    s = "graph {\n"
    s += "node [shape=circle, fixedsize=true, height=0.5, width=0.5]\n"
    q = Queue()
    q.enqueue(ref)
    while not q.isempty():
        ref = q.dequeue()
        child = ref.child
        while child:
            s = s + "   " + str(ref.key) + " -- " + str(child.key) + "\n"
            q.enqueue(child)
            child = child.sibling
    s += "}"
    return s


def display(ref, filename='temp'):
    """Render a tree to SVG format.

    *Warning:* Made for use within IPython/Jupyter only.

    Args:
        ref (Tree).
        filename (str): Temporary filename to store SVG output.

    Returns:
        SVG: IPython SVG wrapper object for tree.

    """

    # Ensure all modules are available
    try:
        from graphviz import Graph
        from IPython.display import SVG
    except:
        raise Exception("Missing module: graphviz and/or IPython.")
    # Traverse tree and generate temporary Graph object
    output_format = 'svg'
    graph = Graph(filename, format=output_format)
    q = Queue()
    q.enqueue(ref)
    while not q.isempty():
        ref = q.dequeue()
        graph.node(str(id(ref)), label=str(ref.key))
        child = ref.child
        while child:
            graph.edge(str(id(ref)), str(id(child)))
            q.enqueue(child)
            child = child.sibling
    # Render to temporary file and SVG object
    graph.render(filename=filename, cleanup=True)
    return SVG(filename + '.' + output_format)


#------------------------------------------------------------------------------

def __nodeToDot(T):
    s = str(id(T)) 
    if T.key != '':
        s += '[label="' + str(T.key) + '"] '
    else:
        s += '[label=""] '
    return s
    
def __linkToDot(A, B, highlight=''):
    return "   " + str(id(A)) + " -- " + str(id(B)) + highlight + ";\n"


def __toDot(T):
    links = ""
    nodes = ""
    q = Queue()
    q.enqueue(T)
    q.enqueue(None)
    while not q.isempty():
        T = q.dequeue()
        if T:
            child = T.child
            first = True
            while child:
                nodes += __nodeToDot(child)
                if first:
                    links += __linkToDot(T, child, ' [constraint="false", color="red", style="bold"]')
                    first = False
                else:
                    links += __linkToDot(T, child)
                if child.sibling:
                    links += __linkToDot(child, child.sibling, ' [constraint="false", color="blue", style="bold"]')
                q.enqueue(child)
                child = child.sibling
        else:
            nodes += '\n'
            if not q.isempty():
                q.enqueue(None)
    return nodes + links

def todotfordisplay(T):
    if T:
        s = "graph {\n"
        s += "node [shape = circle, width=.5];\n"
        s += __nodeToDot(T)
        return s + __toDot(T) + '}'

def display_reallinks(B):
    try:
        from IPython.display import display
        from graphviz import Graph, Source
    except:
        raise Exception("Missing module: graphviz and/or IPython.")
    display(Source(todotfordisplay(B)))