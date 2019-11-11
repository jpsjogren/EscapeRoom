using System;
namespace EscapeRoom
{

    public class Road
    {

        public Road(Inventory i)
        {
            inventory = i;
        }
        private Inventory inventory;
        public int Room3(int characterType, int fromLevel)
        {

            string crossing = @"
   
                                /         /  
                               /         /     
____________________          /         /
                    \        /         /    
                     \      /         /  
                      \    /         /
 ____________          \  /         /                
             \          \/         /                
              \                   /                
               \                 /
               |                |            
               |                |                
               |                |             
               |                |              
               |                |              
               |                |  ";


            string deadend = @"
______ _____  ___ ______      _____ _   _______                   
|  _  \  ___|/ _ \|  _  \    |  ___| \ | |  _  \                  
| | | | |__ / /_\ \ | | |    | |__ |  \| | | | |                  
| | | |  __||  _  | | | |    |  __|| . ` | | | |                  
| |/ /| |___| | | | |/ /     | |___| |\  | |/ /                   
|___/ \____/\_| |_/___/      \____/\_| \_/___/                    
 _____ _   _______ _   _      ___  ______ _____ _   _ _   _______ 
|_   _| | | | ___ \ \ | |    / _ \ | ___ \  _  | | | | \ | |  _  \
  | | | | | | |_/ /  \| |   / /_\ \| |_/ / | | | | | |  \| | | | |
  | | | | | |    /| . ` |   |  _  ||    /| | | | | | | . ` | | | |
  | | | |_| | |\ \| |\  |   | | | || |\ \\ \_/ / |_| | |\  | |/ / 
  \_/  \___/\_| \_\_| \_/   \_| |_/\_| \_|\___/ \___/\_| \_/___/  ";


         
            // Kommer till korsningen 
            Console.WriteLine("***************************************\n");
            Console.WriteLine(crossing);
            Console.WriteLine("Vill du gå åt höger eller vänster");
            string choice = Console.ReadLine().ToLower();
            Console.Clear();

            do
            {
                switch (choice)
                {

                    // gå åt vänster
                    case "vänster":

                        Console.WriteLine("***************************************\n");
                        Console.WriteLine("Du gick till vänster");
                        Console.WriteLine(deadend);
                        Console.WriteLine("***************************************\n");
                        Console.WriteLine("Gå tillbaka till korsningen?");
                        Console.WriteLine("tryck Enter för att fortsätta");
                        Console.ReadKey();
                        Console.Clear();

                        break;


                    // Tillbaka till korningen
                    case "korsningen":

                        Console.WriteLine("***************************************\n");
                        Console.WriteLine(crossing);
                        Console.WriteLine("Du gick tillbaka till korsningen");
                        Console.WriteLine("Du vill nu gå ut höger");
                        Console.WriteLine("Skriv höger");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    // gå till höger
                    case "höger":

                        Console.WriteLine("***************************************\n");
                        Console.WriteLine("Du gick till höger och möter en björn\nVill du skjuta, mata");
                   
                        
                        return 4;


                    // Tillbaka till trädgården
                    case "tillbaka":
                        Console.WriteLine("***************************************\n");
                        if (!inventory.hasGun || !inventory.hasSalmon || !inventory.hasMap || !inventory.hasWallet || !inventory.hasKey)

                        Console.WriteLine("Du behöver gå tillbaka till trädgården\noch leta mera\n");
                        Console.WriteLine("Tryck Enter för att fortsätta");
                        Console.ReadKey();
                        Console.Clear();
                        return 2;

                }



                if (choice != "vänster" && choice != "höger" && choice != "tillbaka" && choice != "korsningen")
                {
                    Console.WriteLine("Du använder fel input. tryck Enter för att gå tillbaka. ");
                    Console.ReadKey();
                    Console.Clear();
                }
                break;



            } while (choice != "mata" && choice != "skjuta");
            return 1;

        }
    }
}




