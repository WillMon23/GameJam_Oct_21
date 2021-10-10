using System;
using System.Collections.Generic;
using System.Text;

namespace GameJam_Oct_21
{
    
    class Plot
    {
        public enum Scene
        {
            STARTMENU,
            PROLAGUE,
            MAINMENU,
            BATTLE,
            FINALBOSS,
            TRYAGINMENU,
            GAMEOVER,

        }

        Scene _currentScene;
        string _draw;

        Player _player;
        Abilitie[] _playerAbilities;

        MiniBoss _currentMiniBoss;
        MiniBoss[] _miniBoss;

        Entity _currentMinion;
        Entity[] _minions;

        int _index;
        bool _gameOver = false;

        public void Start()
        {
            _currentScene = Scene.STARTMENU;
            InitializePlayerAbilies();
            SeaHorseBoss();

            _draw =
                @"         ______
                         .´      `.
                   /.   /          \
                   `.`.:            : 
                   _.:'|   ,--------| 
                   `-·´|  | v     v:
                       :  \_.-- -`-.|
                    __  \           ;
                 ·-´\_\  :         /
                     \_\ :  ` . _.´
                      \ (        :
                 __.-- -´          `--._
                ´                      '";

        }

        public void Draw()
        {
            Console.WriteLine(_draw);
        }

        public void Update()
        { 
            SceneTransitions();
        }

        public void End()
        {

        }

        public void SceneTransitions()
        {
            switch (_currentScene)
            {
                case Scene.STARTMENU:
                    StartingScene();
                    break;
                case Scene.PROLAGUE:
                    Prolague();
                    break;
                case Scene.MAINMENU:
                      MainMenuScene();
                    break;
                case Scene.BATTLE:
                    FirstFloor();
                    break;
                case Scene.FINALBOSS:
                    FinalBossScene();
                    break;
                case Scene.TRYAGINMENU:
                    TryAgainMenu();
                    break;
                case Scene.GAMEOVER:
                    _gameOver = true;
                    break;
            }
        }
        private void Prolague()
        {
            int choice = 1;
            while (choice != 0)
            {
                Console.Write("Back in 1990, there was a SSS+ Tier assassin, named . . . \nEnter Your players name \n> ");
                _player.Name = Console.ReadLine();

                choice = Engine.GetInput("Your player will be named " + _player.Name + " This Okay?", "Yes", "No");
            }
            Console.WriteLine("Until one faithful night, " + _player.Name + " arrived to home base from a resent mission. To find all of there fellow assassin brethren slaughtered.");
            Console.ReadKey();
            Console.WriteLine("This angered the skilled assassins and drove them into a furious rage that no man can control not even " + _player.Name);
            Console.ReadKey();
            Console.WriteLine("At the final peak "+ _player.Name + " anger, they let out a long gasping shout. AAAAAAAGH!!!");
            Console.ReadKey();
            Console.WriteLine("Moments later a inner light was showing within the lowly assassin. Once the blinding light cleared all you saw was a fish. . . *Gloop!? \n" +
            "Close to the brink of suffocating the assassin now a fish found themselves a drain and fell to the sewer where he lived the rest of his life as a fish.");
            Console.Write(". . .");
            //Console.Clear();

            Console.WriteLine("That's what you though But The Game Has Just Started! ");
            _draw = @"      
                      /`·.¸
                     /¸...¸`:·
                 ¸.·´  ¸   `·.¸.·´)
                : © ):´;      ¸  {
                 `·.¸ `·  ¸.·´\`·¸)
                     `\\´´\¸.·´";
            _currentScene = Scene.MAINMENU;

        }
        
        private void StartingScene()
        {

            int choice = Engine.GetInput("Main Menu", "Start Prolauge", "End Game", "Start Game But Skip Prolague");
            switch (choice)
            {
                case 0:
                    _currentScene = Scene.PROLAGUE;
                    break;
                case 1:
                    _currentScene = Scene.MAINMENU;
                    break;
                case 2:
                    _currentScene = Scene.GAMEOVER;
                    break;
            }
        }

        private void MainMenuScene()
        {
            int choice = Engine.GetInput("Main Menu", "Start Game", "Quit");

            switch (choice)
            {
                case 0:
                    Console.WriteLine("Present Day!");
                    Console.ReadLine();
                    Console.WriteLine("Under The Sea");
                    Console.ReadLine();
                    Console.WriteLine(_player.Name + " Long Time Hate Only Fueled there bloodlust all these years");
                    Console.ReadLine();
                    Console.WriteLine(_player.Name + " is steps away from a 5 story building of who did this to them and his brothren ");

                    choice = Engine.GetInput("Would You Like To Continue?", "Yes", "No");
                    if (choice == 0)
                    {
                        Console.WriteLine(_player.Name + " Takes a breather then walks in the build as a FISH, *Glopp*");
                        Console.ReadLine();

                        _draw = @"  
                                  \/)/)
                                _'  oo(_.-. 
                              /'.     .---'
                            /'-./    (
                            )     ; __\
                            \_.'\ : __|
                                 )  _/
                                (  (,.
                              mrf'-.-'";
                        _currentScene = Scene.BATTLE;

                    }
                    else
                    {
                        Console.WriteLine("Game Over");
                        Console.ReadKey();
                        _currentScene = Scene.GAMEOVER;
                    }
                    break;


            }
        }

        private void FirstFloor()
        {

            Console.WriteLine("You been encountred by" + _currentMinion.Name);
            int choice = Engine.GetInput("What Your Next Move?", GetNameOptions(_player.ReadName()));

            while ( _index < _currentMiniBoss.BossMinions().Length)
            {
                switch (choice)
                {

                }
            }


        }

        private void BattleResalts()
        {
            if(_player.Health <= 0)
            {
                _player.Alive = true;
            }
            if(_currentMinion.Health <= 0)
            {
                _currentMinion.Alive = false;
                _currentMinion = 
            }
        }

        private void FinalBossScene() 
        { 

        }

        private void TryAgainMenu()
        {

        }

        private void InitializePlayerAbilies()
        {
            Abilitie seaStarAtt = new Abilitie { Name = "Sea-Star-Shuriken", OutPutDamage = 15f, HitChance = 9 };
            Abilitie eelAtt = new Abilitie { Name = "Electric Eel Whip", OutPutDamage = 20f, HitChance = 9 };
            Abilitie pufferAtt = new Abilitie { Name = "Puffer-Fish-Grenade", OutPutDamage = 25f, HitChance = 9 };


            _playerAbilities = new Abilitie[] { seaStarAtt, eelAtt, pufferAtt };

            _player = new Player(3,"Takoyaki", 100, 15, _playerAbilities);

            _index = 0;
        }

        private void InitializeEnemiessAbilities()
        {
                _currentMinion = _minions[0];
        }

        private MiniBoss SeaHorseBoss()
        {
            Abilitie ripTide = new Abilitie { Name = "Rip-Tide", OutPutDamage = 10, Discription = "A Under Water Tornado Sucked You In", HitChance = 3};
            Abilitie spout = new Abilitie { Name = "Water Spout", OutPutDamage = 15, Discription = "A Huge Luggy was Thrown right at you", HitChance = 3};
            Abilitie snout = new Abilitie { Name = "Snout Flap", OutPutDamage = 20, Discription = "Nose Extends Like a Whip and Lashs Across Your Face", HitChance = 2 };

            Abilitie[] horseAbilites  = new Abilitie[] { ripTide, spout, snout };


            MiniBoss SeaHorse = new MiniBoss("Welcome to Your Last Ride", 5, "SeaHorse ", 100, 25, horseAbilites);

            _currentMiniBoss = SeaHorse;


            _minions = _currentMiniBoss.BossMinions();


            return SeaHorse;
        }

        private string[] GetNameOptions(params string[] names)
        {
            string[] options = new string[names.Length + 1];

            for (int i = 0; i < names.Length; i++)
                options[i] = names[i];
            options[names.Length + 1] = "Quit";
            return options;
        }

    }

}
