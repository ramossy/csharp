using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Understanding of CLR (.NET Framework): 
 *  The .NET framework is a super awesome collection of resources and programs that are included with the C sharp package. With it, 
 *  you get to take advantage of a plethora of useful things. One thing I used was the garbage collector algorithm, which was very 
 *  nice because it allowed me to allocate memory to the same variable without having to worry about deleting it afterwards. It's 
 *  very helpful and many many many programs use some version of .NET Framework because of the resources that it provides. As well 
 *  as all that, it lets you write windows applications, web applications, and utilize web services and can be used for many 
 *  popular languages, such as C++ and Javascript. You typically use Visual Studios to utilize it. The specific jargon for the 
 *  resources it provides are called application programming interfaces. It also provides a runtime environment that lets you 
 *  compile in machine code at runtime, which helps with execution. 
 */

/* Understanding of Object Oriented Programming: 
 *  I like to think of OOP as the creation of nouns. That noun could be any sort of object, like an animal, a player, or a car.
 *  That noun can then do certain things - verbs, otherwise called methods. Those verbs can describe different actions that 
 *  the noun can perform and do. It has members - adjectives that are properties describing how that noun is, as well.
 *  Staying with this analogy, those nouns can interact with other nouns or itself, changing itself and thereby modifying its 
 *  properties (members). More technically speaking, constructors and destructors create and destroy objects respectively. They 
 *  can be mass-created and are powerful because of how flexible they are - you can modify how they interact with each other with 
 *  an assignment overload. It also practices encapsulation - the practice of protecting created variables by declaring them as 
 *  private, and then accessing them through methods instead. This prevents any bad errors that could occur. It also uses function 
 *  overloading, the practice of using the same function name multiple times but with different parameters. They also use inheritance, 
 *  the making of a child class that has some of the same properties as its parent class but also with some different ones. Then there 
 *  are abstract base classes that aren't declared but are the framework for other child classes. Overall, OOP is a staple of computer 
 *  programming and is a powerful way to convey information that is different from typical kinds of code. 
 */
namespace ConsoleApplication1
{
    class Player //This is a class with defined member and methods. 
    {
        private int health; //The fact that these are private is a practice of Encapsulation. 
        private string name;
        public Player() //Default Constructor
        {
            health = 100;
            name = "";
        }
        public Player(string n) //this is a non-default constructor that will set player's name to the passed string.
        {
            health = 100;
            name = n;
        }
        public void health_change(int change) //I change my members using functions
        {
            health -= change;
        }
        public void name_change(string n) //All of these public functions means that it can be used elsewhere within the scope.
        {
            name = n;
        }
        public string get_name() //I access my members using functions
        {
            return name;
        }
        public int get_health()
        {
            return health;
        }
    }
    abstract class Enemy //This is an abstract class that is never initialized but is the framework for child classes
    {
        protected int health; //protected allows it to be used by child classes.
        protected string name;
    }
    class Rat : Enemy //Child class of the enemy
    {
        public Rat() //Default Constructor, name is set to "Rat" right away
        {
            health = 25;
            name = "Rat";
        }
        public void health_change(int change)
        {
            health -= change;
        }
        public int get_health() //similar as the player
        {
            return health;
        }
        public string get_name()
        {
            return name;
        }
    }
    class Goblin : Enemy //Child class of the enemy
    {
        public Goblin()
        {
            health = 50;
            name = "Goblin"; 
        }
        public void health_change(int change)
        {
            health -= change;
        }
        public int get_health()
        {
            return health;
        }
        public string get_name()
        {
            return name;
        }
    }

    class Program //This class harbors the actual program, stuff that is going to be executed
    {
        public static Random R = new Random(); //Random number generator
        static void battle(Player p1, Rat []r, Goblin []g)
        {
            bool win = false; 
            Console.WriteLine("You have entered the dungeon and there are {0} Rat(s) and {1} Goblin(s)!", r.Length,g.Length);
            while(win == false){ //run everything within this loop while win is false or if we hit a break statement.
                if (p1.get_health() <= 0) //if statement performs if condition is true
                {
                    Console.WriteLine("Oh no! {0} died!", p1.get_name()); //Writing various things onto the console
                    Console.ReadKey();
                    Console.WriteLine("Game Over!!!");
                    Console.ReadKey();
                    break;
                }
                else if (r.Length == 0 && g.Length == 0) //checks this condition if first if statement if false
                {
                    Console.WriteLine("You have defeated all of the Rats and Goblins!");
                    Console.ReadKey(); //ReadKey() is used to pause the screen.
                    Console.WriteLine("Yayyyy!!!");
                    Console.ReadKey();
                    win = true;
                }
                else //if both if statements above are false, this set of statements run
                {
                    attack(p1, r, g);
                    Console.WriteLine("{0} health is: {1}", p1.get_name(), p1.get_health());
                    Console.ReadKey();
                    damage(p1, r.Length, g.Length); //Call the damage function
                    Console.WriteLine("There are currently {0} rats and {1} goblins...", r.Length, g.Length);
                }
            }

        }
        static void damage(Player P, int rdam, int gdam) //Static means that this function is one of a kind, void returns nothing.
        {
            double total = 0; 
            double r = (double)rdam; //type cast int rdam and int gdam into doubles.
            double g = (double)gdam;
            total += r * (3.8); //This makes it compatible to be manipulated with decimals/make the total more accurate.
            total += g * (7.2); //If we don't do this, it will round up and decimals won't be used.
            int t = (int)total; //Rounds up total to an int so that we can use it for the Next() function.
            int random_number = R.Next(0, t); //The t becomes the max random number in this round that could be selected.
            Console.WriteLine("{0} took {1} damage!", P.get_name(), random_number);
            P.health_change(random_number);
        }
        static void damage(Rat Ra, int pdam) //a practice of function overloading --> same name, but different parameters.
        {
            double total = 0;
            double p = (double)pdam; //same as the damage above.
            total += p * (10.3);
            int t = (int)total;
            int random_number = R.Next(0, t);
            Console.WriteLine("{0} took {1} damage!", Ra.get_name(), random_number);
            Ra.health_change(random_number);
        }

        static void damage(Goblin Go, int pdam) //some more function overloading.
        {
            double total = 0;
            double p = (double)pdam;
            total += p * (10.3);
            int t = (int)total;
            int random_number = R.Next(0, t);
            Console.WriteLine("{0} took {1} damage!", Go.get_name(), random_number);
            Go.health_change(random_number);
        }
        static void attack(Player P, Rat []Ra, Goblin []Go) 
        {
            Console.WriteLine("You attack!");
            Console.ReadKey();
            Console.WriteLine("You deal no damage...");
            Console.ReadKey();

        }
        static void set_up(string[] args, ref int n) //use ref to pass by reference. 
        {
            if (args.Length > 0) //If there was an argument in the command line...
            {
                if (Int32.TryParse(args[0], out n)) //if you can parse args[0] and turn it into an int32 and put it in n...
                {
                    Console.WriteLine("Command Line was parsed!");
                    Console.WriteLine("Num of rounds is set to {0}", n);
                }
                else //Else, error message and by default will have it set to 1.
                {
                    Console.WriteLine("String could not be parsed.");
                    Console.WriteLine("Default num of rounds is set to 1.");
                }
            }
            Console.ReadKey();
            Console.Clear();

        }
        static void Main(string[] args) //Takes in command line arguments
        {
            int num_rounds = 1;
            set_up(args, ref num_rounds);
            Console.WriteLine("Hello, Hero! Enter your name: ");
            string temp = Console.ReadLine(); //This reads user input
            Console.WriteLine("{0}? That's a terrible name! Your name shall be Jacob instead!!!", temp); //User input is not as good as the name Jacob
            Console.ReadKey();
            for (int i = 1; i < num_rounds+1; i++) //for loop that goes on until i increments enough times to be the same as num_rounds + 1
            {
                Console.WriteLine("Round {0}!", i);
                Console.ReadKey();
                Player p1 = new Player("Jacob"); //Create a new Player named Jacob, called the non-default constructor

                int random_number = R.Next(2, 7); //Random number of rats, goblins created. 
                Rat[] rats = new Rat[random_number];
                Goblin[] goblins = new Goblin[random_number / 2];

                battle(p1, rats, goblins); //call the battle function

                
            }

        }
    }
}
