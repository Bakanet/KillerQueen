using System;

namespace WestWorldTycoon
{
    public abstract class Building
    {
        public enum BuildingType
        {
            NONE, ATTRACTION, HOUSE, SHOP
        }


        protected BuildingType type;
        
        
        public BuildingType Type
        {
            get { return type; }
        }


    }
}