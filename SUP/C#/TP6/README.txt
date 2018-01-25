Dans MyBot, j'ai cree un array d'entiers, UpgradeArr qui permet de sauvegarder les types des batiments et leur niveau a leur position sur la map. (La position d'un element dans l'array
est la meme que sur la map).

La methode IsBuildable de la classe Tile permet de verifier si on peut construire sur une Tile ou non.

La liste BuildableList permet de recuperer des cases (de la classe Point) sur lesquels il est possible de construire. Ces coordonnees seront utiles pour savoir sur quelles cases on
peut construire des batiments.