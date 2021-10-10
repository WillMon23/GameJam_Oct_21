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
            PROLOGUE,
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

        int _minionTallie;


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
            Console.WriteLine("Thanks For Playing");
            Engine.gameOver = true;
        }

        public void SceneTransitions()
        {
            switch (_currentScene)
            {
                case Scene.STARTMENU:
                    StartingScene();
                    break;
                case Scene.PROLOGUE:
                    Prologue();
                    break;
                case Scene.MAINMENU:
                      MainMenuScene();
                    break;
                case Scene.BATTLE:
                    FirstFloor();
                    BattleResalts();
                    break;
                case Scene.FINALBOSS:
                    FinalBossScene();
                    FinalBattleResults();
                    break;
                case Scene.TRYAGINMENU:
                    TryAgainMenu();
                    break;
                case Scene.GAMEOVER:
                    End();
                        break;
            }
        }
        private void Prologue()
        {
            
                Console.Write("Back in 1990, there was a SSS+ Tier assassin, named . . . \nEnter Your players name \n> ");
            
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

            int choice = Engine.GetInput("Main Menu", "Start Prolauge", "Start Game But Skip Prolague", "End Game");
            switch (choice)
            {
                case 0:
                    _draw =
               @"          ______
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
                    _currentScene = Scene.PROLOGUE;
                    break;
                case 1:
                    _draw = @"      
                      /`·.¸
                     /¸...¸`:·
                 ¸.·´  ¸   `·.¸.·´)
                : © ):´;      ¸  {
                 `·.¸ `·  ¸.·´\`·¸)
                     `\\´´\¸.·´";
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
                                 '-.-'";
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
            Random rng = new Random();

            Random rngability = new Random();
            _currentMinion = _minions[_minionTallie];

            PrintStats(_player);
            Console.WriteLine();
            PrintStats(_currentMinion);


            Console.WriteLine("You been encountred by " + _currentMinion.Name);
            int choice = Engine.GetInput("What Your Next Move?", GetNameOptions(_player.ReadName()));

            switch (choice)
            {

                case 0:
                    Console.WriteLine(_player.Name + "Tried to use" + _player.Abilities[choice].Name);
                    if (rng.Next(1, 10) <= (int)_player.Abilities[choice].HitChance)
                    {
                        Console.WriteLine(_currentMinion.Name + " Took " + _currentMinion.DamageTaken(_player.Abilities[choice]));
                    }
                    else
                    {
                        Console.WriteLine(_player.Name + " Missed");
                    }


                    if (rng.Next(1, 10) <= (int)_currentMinion.Abilities[choice].HitChance)
                    {
                        Console.WriteLine(_player.Name + " was " + _currentMinion.Abilities[choice].Discription + " " + _player.DamageTaken(_currentMinion.Abilities[rngability.Next(0, 2)]));
                    }

                    else
                    {
                        Console.WriteLine(_currentMinion.Name + " Missed");
                    }

                    break;

                case 1:
                    Console.WriteLine(_player.Name + "Tried to use" + GetNameOptions(_player.ReadName()[choice]));
                    if (rng.Next(1, 10) <= (int)_player.Abilities[choice].HitChance)
                    { 
                        Console.WriteLine(_currentMinion.Name + " Took " + _currentMinion.DamageTaken(_player.Abilities[choice])); 
                    }

                    else
                    {
                        Console.WriteLine(_player.Name + " Missed");
                    }

                    if (rng.Next(1, 10) <= (int)_currentMinion.Abilities[choice].HitChance)
                    {
                        Console.WriteLine(_player.Name + " was " + _currentMinion.Abilities[choice].Discription + " " + _player.DamageTaken(_currentMinion.Abilities[rngability.Next(0, 2)]));
                    }

                    else
                    {
                        Console.WriteLine(_currentMinion.Name + " Missed");
                    }

                    break;

                case 2:
                    Console.WriteLine(_player.Name + "Tried to use" + _player.Abilities[choice].Name);
                    if (rng.Next(1, 10) <= (int)_player.Abilities[choice].HitChance)
                        Console.WriteLine(_currentMinion.Name + " Took " + _currentMinion.DamageTaken(_player.Abilities[choice]));
                    else
                    {
                        Console.WriteLine(_player.Name + " Missed");
                    }


                    if (rng.Next(1, 10) <= (int)_currentMinion.Abilities[choice].HitChance)
                    {
                        Console.WriteLine(_player.Name + " " +_currentMinion.Abilities[choice].Discription + " " + _player.DamageTaken(_currentMinion.Abilities[rngability.Next(0, 2)]));
                    }

                    else
                    {
                        Console.WriteLine(_currentMinion.Name + " Missed");
                    }
                    break;
                case 3:
                    if (_player.HealingPotion > 0)
                        _player.Healing(75);
                    break;

                case 4:
                    _currentScene = Scene.GAMEOVER;
                    break;
            }
            Console.ReadKey();
        }

        private void BattleResalts()
        {
            if (_player.Health <= 0)
            {
                Console.WriteLine("You Died");
                _player.Alive = true;
                _currentScene = Scene.TRYAGINMENU;
            }
            if (_currentMinion.Health <= 0)
            {
                Console.WriteLine(_currentMinion.Name + " has died");
                Console.ReadKey();
                _player.HealingPotion++;
                _minionTallie++;
                Console.WriteLine("You'll now fight: " + _currentMinion.Name);
            }
            if(_minionTallie >= _currentMiniBoss.TotalMinons)
            {
                Console.WriteLine("You Have Beaten All of the minions for" + _currentMiniBoss.Name + " Leader");
                Console.ReadLine();
                Console.WriteLine("Now You Most Defeat the Room Leader");
                _draw = @"
                     ,  ,
                     \:.|`._
                  /\/;.:':::;;;._
                 <  .'     ':::;(
                  < ' _      '::;>
                   \ (9)  _  :::;(
                   |     / \  \\:;`>
                   |    /  |  //:;(
                   |   (  <=-  .::;>
                   (  a) )=-  .::;(
                    '-' <=- _.::;>
                       )==.'_(::(  ,
                      <==- ~_ >(,-'(
                      )=- '._(:  _.~>
                     <==-    ':.' _(
                      <==-    .:'_ (
                       )==- .::'  '~>
                        <=- .:;(`'.(
                         `)  ':;>  `
                    .-.  <    :;(
                  <`.':\  )    :;>
                 < :/<_/  <  .:;>
                 <  `---'`  .::(`
                  <       .:;>'
                   `-..:::-'`";
                _currentScene = Scene.FINALBOSS;
            }
            if (_currentMiniBoss.Health <= 0)
            {
                Console.WriteLine("Congrats, You have cleared the first floor");
                Console.ReadLine();
                Console.WriteLine("Until Next Update, You Have Reached the End of " + _player.Name + " The Fishiest Assasin");
                _currentScene = Scene.TRYAGINMENU;
            }


        }

        private void FinalBossScene() 
        {
            Random rng = new Random();

            Random rngability = new Random();

            PrintStats(_player);
            Console.WriteLine();
            PrintStats(_currentMiniBoss);


            Console.WriteLine("You been encountred by " + _currentMiniBoss.Name);
            int choice = Engine.GetInput("What Your Next Move?", GetNameOptions(_player.ReadName()));

            switch (choice)
            {

                case 0:
                    Console.WriteLine(_player.Name + "Tried to use" + _player.Abilities[choice].Name);
                    if (rng.Next(1, 10) <= (int)_player.Abilities[choice].HitChance)
                    {
                        Console.WriteLine(_currentMiniBoss.Name + " Took " + _currentMiniBoss.DamageTaken(_player.Abilities[choice]));
                    }
                    else
                    {
                        Console.WriteLine(_player.Name + " Missed");
                    }


                    if (rng.Next(1, 10) <= (int)_currentMiniBoss.Abilities[choice].HitChance)
                    {
                        Console.WriteLine(_player.Name + " was " + _currentMiniBoss.Abilities[choice].Discription + " " + _player.DamageTaken(_currentMiniBoss.Abilities[rngability.Next(0, 2)]));
                    }

                    else
                    {
                        Console.WriteLine(_currentMiniBoss.Name + " Missed");
                    }

                    break;

                case 1:
                    Console.WriteLine(_player.Name + "Tried to use" + GetNameOptions(_player.ReadName()[choice]));
                    if (rng.Next(1, 10) <= (int)_player.Abilities[choice].HitChance)
                    {
                        Console.WriteLine(_currentMiniBoss.Name + " Took " + _currentMiniBoss.DamageTaken(_player.Abilities[choice]));
                    }

                    else
                    {
                        Console.WriteLine(_player.Name + " Missed");
                    }

                    if (rng.Next(1, 10) <= (int)_currentMiniBoss.Abilities[choice].HitChance)
                    {
                        Console.WriteLine(_player.Name + " was " + _currentMiniBoss.Abilities[choice].Discription + " " + _player.DamageTaken(_currentMiniBoss.Abilities[rngability.Next(0, 2)]));
                    }

                    else
                    {
                        Console.WriteLine(_currentMiniBoss.Name + " Missed");
                    }

                    break;

                case 2:
                    Console.WriteLine(_player.Name + "Tried to use" + _player.Abilities[choice].Name);
                    if (rng.Next(1, 10) <= (int)_player.Abilities[choice].HitChance)
                        Console.WriteLine(_currentMiniBoss.Name + " Took " + _currentMiniBoss.DamageTaken(_player.Abilities[choice]));
                    else
                    {
                        Console.WriteLine(_player.Name + " Missed");
                    }


                    if (rng.Next(1, 10) <= (int)_currentMiniBoss.Abilities[choice].HitChance)
                    {
                        Console.WriteLine(_player.Name + " " + _currentMiniBoss.Abilities[choice].Discription + " " + _player.DamageTaken(_currentMiniBoss.Abilities[rngability.Next(0, 2)]));
                    }

                    else
                    {
                        Console.WriteLine(_currentMiniBoss.Name + "Missed");
                    }
                    break;
                case 3:
                    if (_player.HealingPotion > 0)
                        _player.Healing(75);
                    break;

                case 4:
                    _currentScene = Scene.GAMEOVER;
                    break;
            }
            Console.ReadKey();
        }

        private void TryAgainMenu()
        {
            int choice = Engine.GetInput("Would You Like To Play Agin?", "Yes", "No");

            switch (choice) 
            {
                case 0:
                    _currentScene = Scene.STARTMENU;
                    InitializePlayerAbilies();
                    SeaHorseBoss();

                    _draw =
                        @" ______
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
                    break;
                case 1:
                    _currentScene = Scene.GAMEOVER;
                    break;

            }

        }

        private void FinalBattleResults()
        {
            if (_player.Health <= 0)
            {
                Console.WriteLine("You Died");
                _player.Alive = true;
                _currentScene = Scene.TRYAGINMENU;
            }
            
            if (_currentMiniBoss.Health <= 0)
            {
                Console.WriteLine("Congrats, You have cleared the first floor");
                Console.ReadLine();
                Console.WriteLine("Until Next Update, You Have Reached the End of " + _player.Name + " The Fishiest Assasin");
                _currentScene = Scene.TRYAGINMENU;
            }
        }
        private void InitializePlayerAbilies()
        {
            Abilitie seaStarAtt = new Abilitie { Name = "Sea-Star-Shuriken", OutPutDamage = 25f, HitChance = 9 };
            Abilitie eelAtt = new Abilitie { Name = "Electric Eel Whip", OutPutDamage = 30f, HitChance = 9 };
            Abilitie pufferAtt = new Abilitie { Name = "Puffer-Fish-Grenade", OutPutDamage = 37f, HitChance = 9 };


            _playerAbilities = new Abilitie[] { seaStarAtt, eelAtt, pufferAtt };

            _player = new Player(3,"Takoyaki", 1000, 15, _playerAbilities);
        }

        private MiniBoss SeaHorseBoss()
        {
            Abilitie ripTide = new Abilitie { Name = "Rip-Tide", OutPutDamage = 20, Discription = "A Under Water Tornado Sucked You In", HitChance = 3};
            Abilitie spout = new Abilitie { Name = "Water Spout", OutPutDamage = 30, Discription = "A Huge Luggy was Thrown right at you", HitChance = 3};
            Abilitie snout = new Abilitie { Name = "Snout Flap", OutPutDamage = 50, Discription = "Nose Extends Like a Whip and Lashs Across Your Face", HitChance = 2 };

            Abilitie[] horseAbilites  = new Abilitie[] { ripTide, spout, snout };


            MiniBoss SeaHorse = new MiniBoss("Welcome to Your Last Ride", 5, "SeaHorse", 500, 25, horseAbilites);

            _currentMiniBoss = SeaHorse;


            _minions = _currentMiniBoss.BossMinions();




            return SeaHorse;
        }

        private void PrintStats(Entity entity)
        {
            Console.WriteLine("Name: " + entity.Name + "\n" +
                "Health: " + (int)entity.Health + "\n" +
                "Defense: " + (int)entity.Defense);
        }

        private string[] GetNameOptions(params string[] names)
        {
            string[] options = new string[names.Length + 2];

            for (int i = 0; i < names.Length; i++)
                options[i] = names[i];
            options[names.Length] = "Healing Scalap";
            options[names.Length + 1] = "Quit";
            return options;
        }

    }

}
