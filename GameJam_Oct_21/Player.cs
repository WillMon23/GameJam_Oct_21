using System;
using System.Collections.Generic;
using System.Text;

namespace GameJam_Oct_21
{
    class Player : Entity
    {
        private int _healingPotion;

        public int HealingPotion { get { return _healingPotion; } set { _healingPotion = value; } }

        public Player(int healingPotion, string name, float health, float defense, Abilitie[] abilities): base(name, health, defense, abilities)
        {
            _healingPotion = healingPotion;
        }

        public bool EarnPotion(Entity entity)
        {
            bool response = true;
            if (entity.Alive)
            {
                _healingPotion++;
                response = false;
            }
            return response;
        } 

        
    }
}
