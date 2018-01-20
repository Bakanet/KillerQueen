#!/usr/bin/env python3
from sys import argv
from pathlib import Path
from enum import Enum
from copy import deepcopy
import tkinter as tk

SIZE = 50
HOUSE_B = 250
HOUSE_U = (750, 3000, 10000)
HOUSING = (300, 500, 650, 750)
SHOP_B = 300
SHOP_U = (2500, 10000, 50000)
INCOME = (7, 8, 9, 10)
ATTRACTION_B = 10000
ATTRACTION_U = (5000, 10000, 45000)
ATTRACTIVITY = (500, 1000, 1300, 1500)

class Biome(Enum):
    SEA = 0
    MOUNTAIN = 1
    PLAIN = 2

class Building(Enum):
    NONE = 0
    ATTRACTION = 1
    HOUSE = 2
    SHOP = 3


class Tile:
    def __init__(self, biome):
        self.biome = biome
        self.building = Building.NONE
        self.lvl = 0

class Viewer(tk.Frame):

    def resize_pic(self, array, path, sub=True):
        array.append(tk.PhotoImage(file=path))
        if (sub):
          array[-1] = array[-1].subsample(5, 5)

    def __init__(self, master=None, states=[]):
        super().__init__(master)
        self.states = states
        path = str(Path(__file__).parents[0].resolve()) + "/"

        self.house_pic = []
        self.resize_pic(self.house_pic, path + "house0.png")
        self.resize_pic(self.house_pic, path + "house1.png")
        self.resize_pic(self.house_pic, path + "house2.png")
        self.resize_pic(self.house_pic, path + "house3.png")

        self.shop_pic = []
        self.resize_pic(self.shop_pic, path + "shop0.png")
        self.resize_pic(self.shop_pic, path + "shop1.png")
        self.resize_pic(self.shop_pic, path + "shop2.png")
        self.resize_pic(self.shop_pic, path + "shop3.png")

        self.attraction_pic = []
        self.resize_pic(self.attraction_pic, path + "attraction0.png")
        self.resize_pic(self.attraction_pic, path + "attraction1.png")
        self.resize_pic(self.attraction_pic, path + "attraction2.png")
        self.resize_pic(self.attraction_pic, path + "attraction3.png")

        self.bioms = []
        self.resize_pic(self.bioms, path + "sea.png", False)
        self.resize_pic(self.bioms, path + "mountain.png", False)
        self.resize_pic(self.bioms, path + "land.png", False)

        self.round = 0
        self.draw(0)
        self.pack()


    def display(self, i, j, canvas, tile):
        img = self.bioms[2]
        if (tile.biome == Biome.SEA):
          img = self.bioms[0]
        canvas.create_rectangle(i * SIZE, j * SIZE, (i+1) * SIZE, \
                               (j+1) * SIZE)
        canvas.create_image(i * SIZE + 25, j * SIZE + 25, image = img)
        if (tile.biome == Biome.MOUNTAIN):
          img = self.bioms[1]
          canvas.create_image(i * SIZE + 25, j * SIZE + 25, image = img)
        if (tile.building == Building.HOUSE):
            canvas.create_image(i * SIZE + 25, j * SIZE + 25, \
                                image = self.house_pic[tile.lvl])
        elif (tile.building == Building.SHOP):
            canvas.create_image(i * SIZE + 25, j * SIZE + 25, \
                                image = self.shop_pic[tile.lvl])
        elif (tile.building == Building.ATTRACTION):
            canvas.create_image(i * SIZE + 25, j * SIZE + 25, \
                                image = self.attraction_pic[tile.lvl])

    def draw(self, r):
        for widget in self.winfo_children():
            widget.grid_forget()
        carte = self.states[r][1]
        (cur_h, cur_a) = (housing(carte), attractivity(carte))
        tk.Label(self, text="WestWorldTycoon", font=("Courier", 34)).grid(row=0, column=1, columnspan=3)
        tk.Label(self, text="Score: " + str(self.states[r][2]), font=("Courier", 24)).grid(row=1, column=0, sticky='w')
        tk.Label(self, text="Money: $" + str(self.states[r][0]), font=("Courier", 24)).grid(row=2, column=0, sticky='w')
        tk.Label(self, text="Income: $" + str(income(min(cur_h, cur_a), carte)), font=("Courier", 24)).grid(row=3, column=0, sticky='w')
        tk.Label(self, text="Population: " + str(min(cur_h, cur_a)), font=("Courier", 24)).grid(row=4, column=0, sticky='w')
        tk.Label(self, text="Housing: " + str(cur_h), font=("Courier", 24)).grid(row=5, column=0, sticky='w')
        tk.Label(self, text="Attractiveness: " + str(cur_a), font=("Courier", 24)).grid(row=6, column=0, sticky='w')
        canvas = tk.Canvas(self, width = SIZE * len(carte[0]), \
                           height = SIZE * len(carte))
        canvas.coords(0, SIZE * len(carte[0]))
        for i, row in enumerate(carte):
            for j, tile in enumerate(row):
                self.display(j, i, canvas, tile)
        canvas.grid(row=1, column=1, rowspan=12, columnspan=3)
        tk.Button(self, text="<", command=self.back).grid(row=42, column=1)
        tk.Label(self, text="Round " + str(self.round), font=("Courier", 20)).grid(row=42, column=2)
        tk.Button(self, text=">", command=self.foward).grid(row=42, column=3)

    def back(self):
        if self.round:
            self.round -= 1
            self.draw(self.round)

    def foward(self):
        if self.round < len(self.states) - 1:
            self.round += 1
            self.draw(self.round)


def parser(path):
    f = open(path, "r")
    (rounds, money, h, w) = map(int, f.readline().split())
    carte = [ [None] * w for i in range(h) ]
    for i in range(h):
        line = f.readline()
        for j in range(w):
            carte[i][j] = Tile(Biome(int(line[j])))
    actions = []
    for i in range(rounds):
        line = f.readline()
        cur = []
        for act in line.split('|')[:-1]:
            cur.append(act.split())
        actions.append(cur)
    f.close()
    return (rounds, money, carte, actions)

def build(i, j, t, carte, money):
    if (i < 0 or i >= len(carte) or j < 0 or j >= len(carte[0]) \
        or carte[i][j].biome != Biome.PLAIN or carte[i][j].building != Building.NONE):
        raise Exception("build failed")
    carte[i][j].building = t
    if t == Building.ATTRACTION:
        money -= ATTRACTION_B
    elif t == Building.HOUSE:
        money -= HOUSE_B
    else:
        money -= SHOP_B
    if money < 0:
        raise Exception("build failed")
    return money

def upgrade(i, j, carte, money):
    if (i < 0 or i >= len(carte) or j < 0 or j >= len(carte[0]) or carte[i][j].biome != Biome.PLAIN \
            or carte[i][j].building == Building.NONE or carte[i][j].lvl == 3):
        raise Exception("upgrade failed")
    lvl = carte[i][j].lvl
    t = carte[i][j].building
    if t == Building.ATTRACTION:
        money -= ATTRACTION_U[lvl]
    elif t == Building.HOUSE:
        money -= HOUSE_U[lvl]
    else:
        money -= SHOP_U[lvl]
    if money < 0:
        raise Exception("upgrade failed")
    carte[i][j].lvl += 1
    return money

def destroy(i, j, carte):
    if (i < 0 or i >= len(carte) or j < 0 or j >= len(carte[0]) \
            or carte[i][j].biome != Biome.PLAIN or carte[i][j].building != Building.NONE):
        raise Exception("destroy failed")
    carte[i][j].lvl = 0
    carte[i][j].building = Building.NONE

def housing(carte):
    h = 0
    for l in carte:
        for b in l:
            if b.building == Building.HOUSE:
                h += HOUSING[b.lvl]
    return h

def attractivity(carte):
    a = 0
    for l in carte:
        for b in l:
            if b.building == Building.ATTRACTION:
                a += ATTRACTIVITY[b.lvl]
    return a

def income(pop, carte):
    i = 0
    for l in carte:
        for b in l:
            if b.building == Building.SHOP:
                i += pop // 100 * INCOME[b.lvl]
    return i

def update(carte):
    return income(min(attractivity(carte), housing(carte)), carte)

def simulator(path):
    (rounds, money, carte, actions) = parser(path)
    score = 0
    states = [(money, carte, 0)]
    for i in range(len(actions)):
        carte = deepcopy(states[-1][1])
        for action in actions[i]:
            if action[0] == 'B':
                money = build(int(action[2]), int(action[3]), Building(int(action[1])), carte, money)
            elif action[0] == 'U':
                money = upgrade(int(action[1]), int(action[2]), carte, money)
            elif action[0] == 'D':
                destroy(int(action[1]), int(action[2]), carte)
        states.append((money, carte, score))
        income = update(carte)
        score += income
        money += income
    return states


if __name__ == '__main__':
    if len(argv) != 2:
        printf("Usage: {argv[0]} bot.out")
        exit(1)
    root = tk.Tk()
    root.title("WestWorldTycoon")
    try:
        states = simulator(argv[1])
    except:
        raise Exception("There is an error in your Game.\n"
                "You're allowing forbiden moves.")


    viewer = Viewer(root, states)
    viewer.mainloop()
