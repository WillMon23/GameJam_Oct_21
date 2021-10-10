using System;
using System.Collections.Generic;
using System.Text;

namespace GameJam_Oct_21
{
    class MiniBoss : Entity
    {
        private int _totalMinons;
        private string _dialog;
        private Entity _minion;

        public int TotalMinons { get { return _totalMinons; } }
        
        public string Dialog { get { return _dialog; } }


        public MiniBoss(string dialoag, int totalMinons,string name, float health, float defense,  Abilitie[] abilities):base(name, health, defense, abilities)
        {
            _totalMinons = totalMinons;
            _dialog = dialoag;


        }

        public Entity[] BossMinions()
        {
            Entity[] minionHord = new Entity[_totalMinons];
            for (int i = 0; i < minionHord.Length; i++)
                minionHord[i] = new Entity(Name + " Minion Rank #" + (i + 1), (Health / 3), (Defense * 0), Abilities);

            return minionHord;
        }


    }
}
