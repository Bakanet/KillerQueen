using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.Serialization;
using System.Security;

namespace miniPokemon
{
    
    public class Move
    {
        #region Constructor

        private string name;

        private Dictionary<string, Tuple<int, int, State, string, Poketype>> attack;
        
        
        // damage, accuracy, effect, phy/spe, type
            

        public Move(string name)
        {
            this.name = name;
        }

        #endregion

        #region Methods



        #endregion
    }
}