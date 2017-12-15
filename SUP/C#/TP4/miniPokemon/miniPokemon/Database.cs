using System;

namespace miniPokemon
{
    public enum Poketype
    {
        None,
        NORMAL = 0,
        FIRE = 1,
        WATER = 2,
        GRASS = 3,
        ELECTRIK = 4,
        ICE = 5,
        FIGHT = 6,
        POISON = 7,
        GROUND = 8,
        FLYING = 9,
        PSYCHIC = 10,
        INSECT = 11,
        ROCK = 12,
        GHOST = 13,
        DRAGON = 14,
        DARK = 15,
        STEEL = 16,
        FAIRY = 17,
    }

    public enum Pomon
    {
        AlakazamMega, Bisharp, Blacephalon, Celesteela, Chansey, CharizardMegaX,
        CharizardMegaY, Clefable, DiancieMega, Dragonite, Excadrill, Ferrothorn,
        Garchomp, GarchompMega, Gengar, Greninja, GreninjaAsh, Hawlucha, Heatran,
        Jirachi, Kartana, Keldeo, Kingdra, KyuremBlack, LandorusTherian, Latios, 
        LatiosMega, LopunnyMega, LycanrocDusk, Magearna, Magnezone, Manaphy, MarowakAlola,
        MawileMega, MedichamMega, Mew, Mimikyu, NinetalesAlola, Pelipper, PinsirMega,
        SableyeMega, ScizorMega, Skarmory, Skakataka, SwampertMega, Tangrowth, TapuBulu,
        TapuLele, Toxapex, Tyranitar, TyranitarMega, VenusaurMega, Victini, Volcarona,
        Zapdos, Zygarde
    }
    
    public enum State
    {
        None, SLP, BRN, FRZ, PAR, PSN, TXC, Confusion, Flinch, LeechSeed, 
        lowAtk, lowDef, lowPrc, lowDdg, lowSpA, lowSpD, upAtk, upDef, upPrc, UpDdg, upSpA
    }

    public class TypeTable
    {
        private int[,] table;
        public int[,] Table { get; set; }
        private int lol;

        public TypeTable()
        {
            table = new int[,]
            {
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 / 2, 0, 1, 1, 1 / 2, 1},

            };
            lol = table[(int) Poketype.NORMAL, (int) Poketype.FIRE];
        }

        public void Affinity(Poketype atkType, Poketype defType)
            {
                Console.WriteLine(lol);

            }
    }
}
    