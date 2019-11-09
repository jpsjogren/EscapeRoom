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
   
___________________________________________________                                               
                                                 
                                                 
                                                 
_______________                  __________________  
               |         |       |            
               |         |       |                
               |         |       |             
               |         |       |              
               |         |       |              
               |         |       |  ";


            string leavingleft = @"


     _________________
     |               |
     |               |
     |       |       |   
     |       |       |    
     |       |       |      
     |       |       |
     |       |       |
";


           /* string leavingright = @"


      |        |        |   
      |        |        | 
      |        |        | 
      |        |        |
      |        |        | 
      |        |        |
      |        |        |     
";*/







            // Kommer till korsningen
            Console.Clear();
            
            Console.WriteLine(crossing);
            Console.WriteLine("Vill du gå åt höger eller vänster");
            string choice = Console.ReadLine().ToLower();

            do
            {

                switch (choice)
                {

                    // gå åt vänster
                    case "vänster":
                        {
                            Console.Clear();
                            Console.WriteLine("Du gick till vänster och kom till en återvändsgränd");
                            Console.WriteLine(leavingleft);
                            Console.WriteLine("Gå tillbaka till korsningen?");
                            Console.WriteLine("Tryck enter för att fortsätta");
                            choice = "korsningen";
                            Console.ReadKey();
                          


                        }
                        break;


                    // Tillbaka till korningen
                    case "korsningen":
                        {

                            Console.Clear();
                            Console.WriteLine(crossing);
                            Console.WriteLine("Du gick tillbaka till korsningen");
                            Console.WriteLine("Du vill nu gå ut höger");
                            Console.WriteLine("Skriv höger");
                            Console.ReadLine();
                            Console.Clear();
                            

                        }
                        break;
                        

                    // gå till höger
                    case "höger":
                        {
                            return 4;
                        }
                       

                    // Tillbaka till trädgården
                    case "trädgården":

                        if (!inventory.hasGun && !inventory.hasSalmon || !inventory.hasMap || !inventory.hasWallet || !inventory.hasKey)
                        {
                            Console.WriteLine("Du behöver gå tillbaka till trädgården\noch leta mera\n");
                            Console.WriteLine("Tryck Enter för att fortsätta");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        return 2;
                    default:
                        Console.WriteLine("Du använder fel input, använd ' vänster ' höger 'korsningen ");
                        choice = Console.ReadLine();
                        Console.Clear();
                        break;
                }


            } while (choice !="höger");

            return 4;
        }
    }
}



          
