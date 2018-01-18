using System;
using System.Runtime.Remoting.Messaging;

namespace WestWorldTycoon
{
    public class Game
    {
        private long score;
        private long money;
        private int nbRound;
        private int round;
        private Map map;
        
        public Game(string name, int nbRound, long initialMoney)
        {
            TycoonIO.GameInit(name, nbRound, initialMoney);
            map = new Map(name);
            this.nbRound = nbRound;
            money = initialMoney;
        }


        public long Launch(Bot bot)
        {
            bot.Start(this);
            for (int i = 0; i < nbRound; ++i)
            {
                bot.Update(this);
                ++round;
            }
            bot.End(this);

            return score;
        }
        
        
        public void Update()
        {
            long income = map.GetIncome(map.GetPopulation());
            score += income;
            money += income;
            TycoonIO.GameUpdate();
        }


        public bool Build(int i, int j, Building.BuildingType type)
        {
            if (!map.Build(i, j, ref money, type)) 
                return false;
            
            TycoonIO.GameBuild(i, j, type);
            return true;

        }


        public bool Destroy(int i, int j)
        {
            throw new NotImplementedException();
        }
        
        public bool Upgrade(int i, int j)
        {
            if (!map.Upgrade(i, j, ref money)) 
                return false;
            
            TycoonIO.GameUpgrade(i, j);
            return true;

        }
        
        
        public long Score
        {
            get { return score; }
        }
        
        
        public long Money
        {
            get { return money; }
        }
        
        
        public int NbRound
        {
            get { return nbRound; }
        }


        public int Round
        {
            get { return round; }
        }

        public Map Map
        {
            get { return map; }
        }
    }
}