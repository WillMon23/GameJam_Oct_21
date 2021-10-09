using System;
using System.Collections.Generic;
using System.Text;

namespace GameJam_Oct_21
{
    
    class Engine
    {
        enum Scene
        {
            STARTMENU,
            MAINMENU,
            BATTLE,
            FINALBOSS,
            TRYAGINMENU,
            GAMEOVER

        }
        Entity _player;
        Abilitie[] _playerAbilities;

        Entity _currentMinion;
        Entity[] _minions;

        Entity _boss;

        bool gameOver = false;
        public void Run()
        {
            Start();

            while (!gameOver)
            {
                Draw();
                Update();
            }
            End();
        }

        private void Start()
        {
            InitializePlayerAbilies();
        }

        private void Draw()
        {

        }

        private void Update()
        {

        }

        private void End()
        {

        }

        private void SceneTransitions()
        {

        }

        private void StartingScene()
        {

        }

        private void InitializePlayerAbilies()
        {
            Abilitie seaStarAtt = new Abilitie { Name = "Sea-Star-Shuriken", OutPutDamage = 15f };
            Abilitie eelAtt = new Abilitie { Name = "Electric Eel Whip", OutPutDamage = 20f };
            Abilitie pufferAtt = new Abilitie { Name = "Puffer-Fish-Grenade", OutPutDamage = 25f };

            _playerAbilities = new Abilitie[] { seaStarAtt, eelAtt, pufferAtt };

            _player = new Entity("Takoyaki", 1000, 15, _playerAbilities);

        }

        private void InitializeEnemiessAbilities()
        {

            

            Entity SeaHorseTroop = new Entity("Sea-Horse-Trooper", 100,10,)
                
                _currentMinion = _minions[0];
        }
    }

}
