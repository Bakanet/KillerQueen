using System;

namespace WestWorldTycoon
{
    public class Game
    {
        public Game(string name, int nbRound, long initialMoney)
        {
            TycoonIO.GameInit(name, nbRound, initialMoney);
            throw new NotImplementedException();
        }


        public long Launch(Bot bot)
        {
            throw new NotImplementedException();
        }
        
        
        public void Update()
        {
            throw new NotImplementedException();
            TycoonIO.GameUpdate();
        }


        public bool Build(int i, int j, Building.BuildingType type)
        {
            throw new NotImplementedException();
        }


        public bool Destroy(int i, int j)
        {
            throw new NotImplementedException();
        }
        
        public bool Upgrade(int i, int j)
        {
            throw new NotImplementedException();
        }
        
        
        public long Score
        {
            get { throw new NotImplementedException(); }
        }
        
        
        public long Money
        {
            get { throw new NotImplementedException(); }
        }
        
        
        public int NbRound
        {
            get { throw new NotImplementedException(); }
        }


        public int Round
        {
            get { throw new NotImplementedException(); }
        }

        public Map Map
        {
            get { throw new NotImplementedException(); }
        }
    }
}