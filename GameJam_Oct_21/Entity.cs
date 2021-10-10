using System;
using System.Collections.Generic;
using System.Text;

namespace GameJam_Oct_21
{
    public struct Abilitie
    {
        public string Name;
        public string Discription;
        public float OutPutDamage;
        public float HitChance;
    }

    class Entity
    {
        private string _name;
        private float _health;
        private float _healthCap;
        private float _defense;

        private bool _alive;

        private Abilitie[] _abilities;

        public string Name { get { return _name; } set { _name = value; } }
        public float Health { get { return _health; } }
        public float HealthCap { get { return _healthCap; } }
        public float Defense { get { return _defense; } }

        public Abilitie[] Abilities {get { return _abilities; } }
        public bool Alive { get { return _alive; } set { _alive = value; } }





        public Entity(string name, float health, float defense, Abilitie[] abilities, bool alive = false)
        {
            _name = name;
            _health = health;
            _healthCap = health; 
            _defense = defense;
            _abilities = abilities;
            _alive = alive;
        }

        /// <summary>
        /// Calculates the damage out puting from the entities through the defense 
        /// to the health 
        /// </summary>
        /// <param name="abilitie"> Ability being utalized to attack player</param>
        /// <returns>returns thr damage delt</returns>
        public float DamageTaken(Abilitie abilitie)
        {
            if (_defense >= abilitie.OutPutDamage)
                return 0;
            _health -= abilitie.OutPutDamage - _defense;

            return abilitie.OutPutDamage - _defense;
        }

        /// <summary>
        /// Takes ablilites names and separtes them to a array of strings 
        /// </summary>
        /// <param name="abilities">Abilities being read from</param>
        /// <returns>returns an array of strings</returns>
        public string[] ReadName() 
        {
            string[] weaponNames = new string[_abilities.Length]; 
            for(int i = 0; i < _abilities.Length; i++)
                weaponNames[i] = _abilities[i].Name +  " - Deals: " + _abilities[i].OutPutDamage + " Attack Damage";

            return weaponNames;
        }

        public float Healing(float healthGain)
        {

            if ((_health + healthGain) >= HealthCap)
            {
                _health += (healthGain - HealthCap);
                return (healthGain - HealthCap);
            }
            else
                _health += healthGain;

            return healthGain;
        }
    }
}
