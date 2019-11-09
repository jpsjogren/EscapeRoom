using System;
namespace EscapeRoom
{ 
    public class Feed
    {

        public Feed(Inventory i)
        {
            inventory = i;
        }
        private Inventory inventory;
        
        public int Room4(int characterType)
           
           
        {
         


            string youdied = @"
__   __                _ _          _ 
\ \ / /               | (_)        | |
 \ V /___  _   _    __| |_  ___  __| |
  \ // _ \| | | |  / _` | |/ _ \/ _` |
  | | (_) | |_| | | (_| | |  __/ (_| |
  \_/\___/ \__,_|  \__,_|_|\___|\__,_|
                                      
                                      
";

            string fish = @"     
      /`·.¸
     /¸...¸`:·
 ¸.·´  ¸   `·.¸.·´)
: © ):´;      ¸  {
 `·.¸ `·  ¸.·´\`·¸)
     `\\´´\¸.·´";

            string choice = "";

            Console.Clear();
            Console.WriteLine("Du gick till höger och möter en björn\nVill du skjuta, mata björnen , trädgården");
            choice = Console.ReadLine().ToLower();

            do
            {


                switch (choice)
                {

                    // mata för att komma till stationen
                    case "mata":
                        {
                            if (inventory.hasSalmon)
                            {
                              
                                Console.WriteLine("***************************************\n");
                                Console.WriteLine(fish);
                                Console.WriteLine("Du gav björnen en fin Röd Lax och kunde smita förbi till Centralstationen");
                                Console.WriteLine("Tryck Enter för att fortsätta");
                                Console.ReadKey();

                                return 5;
                             }

                            else if (!inventory.hasSalmon)
                            {
                                Console.WriteLine("***************************************\n");
                                Console.WriteLine("Du behöver gå tillbaka till huset och leta mera");
                                Console.WriteLine("Tryck Enter för att fortsätta");
                                Console.ReadKey();
                                Console.Clear();
                                return 1;
                            }
                            break;

                        }





                    //om du använder vapen DÖR du
                    case "skjuta":
                        {
                            if (inventory.hasGun)
                            {
                                Console.WriteLine("***************************************\n");
                                Console.WriteLine("Björnen blev arg och dödade dig");
                                Console.WriteLine("Tryck Enter för att fortsätta");
                                Console.ReadKey();


                                for (int i = 0; i < 4; i++)
                                {

                                    foreach (ConsoleColor c in Enum.GetValues(typeof(ConsoleColor)))
                                    {

                                        Console.ForegroundColor = c;
                                        Console.WriteLine(youdied);
                                        System.Threading.Thread.Sleep(100); // 1 sec. deley
                                        Console.Clear();

                                    }



                                }
                                return 1;
                            }

                            // Om du inte har vapen
                            else if (!inventory.hasGun)
                            {
                                Console.WriteLine("***************************************\n");
                                Console.WriteLine("Har du ett vapen för att skjuta björnen om inte \nHoppas du har en Lax för att locka bort den\n");
                                Console.WriteLine("Tryck Enter för att fortsätta");
                                Console.ReadLine();

                                return 2;
                            }
                            break;
                        }



                }


                //fel input  på val av att göra
                if (choice != "mata" && choice != "skjuta")
                {
                    Console.WriteLine("Du använder fel input använd 'mata' skjuta'");
                    choice = Console.ReadLine();
                    Console.Clear();
                }

            } while (choice != "mata");
            return 1;

        }
    }

}