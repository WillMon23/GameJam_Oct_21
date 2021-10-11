using System;

/*
 * Overall your code looks pretty decent. 
 * 
 * There aren't a lot of hard and fast rules in coding, 
 *  and at the end of the day as long as your code 
 *  compiles and can be read by other people you're doing great.
 * 
 * I pointed out a few bits where you did something good 
 *  or where you might consider doing something different. 
 *  If I pointed out something that's only the way it is because 
 *  jam's are crazy and there's no time, ignore it lol I totally get it.
 *  Nobody expects good clean code in a jam, it's a miracle if it even runs XD.
 * 
 * Some nit picky things that stood out to me:
 * - More comments! I can read code pretty well, 
 *    but there we a few spots where I had to lean forward in my chair a 
 *    little and figure out what was happening because it wasn't commented. 
 *    It's a jam, I know, stop booing me XD, but still. 
 *    I like to comment as I go because lets face it nobody wants to go back 
 *    through a file after and try to comment the whole thing at once.
 *    
 * - The scene enum is good stuff.
 *    That sort of thing helps make your code so much more readable and 
 *    at the end of the day that's what separates good code from great code.
 *    
 * - Good use of inheritance with the Entity class.
 * 
 * - Check your spelling :P
 */
namespace GameJam_Oct_21
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();

            engine.Run();
        }
    }
}
