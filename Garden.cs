using System;
namespace EscapeRoom
{



    public class Garden
    {
        public Garden(Inventory i)
        {
            inventory = i;
        }
        private Inventory inventory;

        public int Room2(int fromLevel , int visited, int characterType)
        {


                string bodart = @"
      __________
     ///////////\
    ///////////  \
    |    _    |  |
    |   | |   |  |
    |   | |   |  |
mmm_________________mmmmmm__mmmmm_mm_____

";



            int nextLevelInfo = 0;  // 1 = Gå vidare till Vägen, 2 = Tillbaka till huset
           
            string choice = "";

            if (fromLevel == 1 && visited > 0) //Om du kommer från huset, med redan varit här
            {
                Console.Clear();
                Console.WriteLine("****************************************\n");
                Console.WriteLine("Hoppas du hittade vad du sökte i huset.");
                Console.WriteLine("Du står precis utanför dörren och ser en bod och massa skog.");
                Console.WriteLine("Du går bort till boden");
                Console.WriteLine("\nTryck Enter för att forsätta");
                choice = "bod";
                Console.ReadKey();

            }

            if (visited == 0) {
                do //Först gången du är här
                {
                    Console.Clear();
                    Console.WriteLine(" ****************************************\n");
                    Console.WriteLine("Du gick ut genom dörren, när du gjorde det trampade du på dörrmattan\nDet praslade till.\n");
                    Console.WriteLine("Du lyfte på mattan och såg en karta.\nVill du plocka upp kartan\n");
                    Console.WriteLine("Tryck J / N");
                    choice = Console.ReadKey().Key.ToString();
                    if (choice.ToUpper() == "J")
                    {

                        inventory.hasMap = true;

                        Console.Clear();
                        Console.WriteLine("****************************************\n");
                        Console.WriteLine("Du plockade upp kartan");
                        //En metod för att fråga och visa inventoryn. Argument. True är för att visa att vi har lagt till en sak iinvetoryn
                        inventory.ShowInv(characterType, true);

                        Console.WriteLine("****************************************\n");
                        Console.WriteLine("Du går ned för trappan till trädgården där ser du en bod");
                        
                        Console.WriteLine("\nTryck Enter för att forsätta");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (choice == "N")
                    {
                        Console.Clear();
                        Console.WriteLine("****************************************\n");

                        Console.WriteLine("Du borde plocka upp karta för den kommer blåsa bort snart");
                        Console.WriteLine("Tryck J / N");
                        choice = Console.ReadKey().Key.ToString();
                        if (choice == "N")
                        {
                            Console.WriteLine("\nNähe, då går vi vidare");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            //En metod för att fråga och visa inventoryn. Argument. True är för att visa att vi har lagt till en sak iinvetoryn
                            inventory.ShowInv(characterType, true);
                            inventory.hasMap = true;
                        }
                    }

                } while (choice != "J" && choice != "N");
            }


            if (fromLevel == 3) //Om du kommer från Vägen
            {
                Console.Clear();
                Console.WriteLine("****************************************\n");
                Console.WriteLine("Behöver du något mer?");
                Console.WriteLine("VIll du gå bort till boden eller tillbaka in i huset?\n");
                Console.WriteLine("Välj 'bod eller 'huset'");
                choice = Console.ReadKey().Key.ToString();
            }

            do
            {

                switch (choice)
                {

                    //plocka upp karta
                    case "J":
                        choice = "bod";

                        continue;

                    case "N":

                        choice = "bod";

                        continue;
                        
                    //besöka bod och plocka upp gevär
                    case "bod":
                        
                        Console.Clear();
                        Console.WriteLine("****************************************\n");
                        Console.WriteLine(bodart);
                        if (!inventory.hasGun)
                        {
                            Console.Clear();
                            Console.WriteLine("****************************************\n");
                            Console.WriteLine("Du öppnade dörren till boden och ser en " + (WeaponType)characterType + "\ndetta kan vara bra att ha, du stoppar ner det i din " + (BagType)characterType);
                            Console.WriteLine("");
                            inventory.hasGun = true;
                            inventory.ShowInv(characterType, true);
                            Console.WriteLine("****************************************\n");
                            Console.WriteLine("Du vänder dig om och ser en grind som du går mot");
                            Console.WriteLine("\nTryck Enter för att forsätta");
                            choice = "grind";
                            
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("****************************************\n");
                            Console.WriteLine("Du hittar inget nytt härborta, med du ser en grinden som du går mot.\n");
                            Console.WriteLine("\nTryck Enter för att forsätta");
                            choice = "grind";
                            Console.ReadKey();
                        }
                
                            
                        
                        break;
                     //Försöka ta sig ut från grinden 
                     case "grind":
                        Console.Clear();
                        Console.WriteLine("****************************************\n");
                        Console.WriteLine("Grinden är låst, hoppas du har nyckeln med dig");
                        if (inventory.hasKey)
                        {
                            Console.WriteLine("Tur att du hittade nycklen förut, du låter nyckeln vara kvar i låset och går vidare ut på vägen...");
                            Console.WriteLine("\nTryck Enter för att forsätta");
                            Console.ReadKey();
                            nextLevelInfo = 3;
                            inventory.hasKey = false;
                            return nextLevelInfo;
                        }
                        else
                        {
                            Console.WriteLine("Ingen nyckel?\n");
                            Console.WriteLine("Det är nog bästa att du går tillbaka till huset och letar igen");
                            Console.WriteLine("Tryck enter för gå tillbaka till huset\n");
                            Console.ReadKey();
                            nextLevelInfo = 1;
                            return nextLevelInfo;
                        }


                    case "huset":

                        Console.WriteLine("****************************************\n");
                        Console.WriteLine("Till huset om \n");
                        Console.Write("3...");
                        System.Threading.Thread.Sleep(500);
                        Console.Write("2...");
                        System.Threading.Thread.Sleep(500);
                        Console.Write("1...");
                        System.Threading.Thread.Sleep(500);
                        nextLevelInfo = 1;
                        return nextLevelInfo;

                    default:
                        Console.Clear();
                        Console.WriteLine("Fel input. Tips, använd dessa");
                        Console.WriteLine("Välj 'bod' 'grind' 'huset':");
                        choice = Console.ReadLine().ToLower();
                        continue;


                } //End switch case

            } while (nextLevelInfo != 1 || nextLevelInfo != 2);

            return nextLevelInfo;


        }

    }
}


