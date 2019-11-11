using System;

namespace EscapeRoom
{
    public class House
    {
        public House(Inventory i)
        {
            inventory = i;
        }
        private Inventory inventory;

          //Samma som oven

        public int Room1(int levelnfo, int visited, string characterName, int characterType)
        {


            int tittaIKyl = 0;      //För att hålla koll på hur många spelaren redan letat på ett visst ställe
            int tittaISkänk = 0;
            bool letat = false;     //För att kolla om spelaren letat och kunna ge rätt text vid utgång och även i ryggsäcken
            string choice;          //Input från spelaren om vart det ska "letas"

            string houseArt = @"
    ) )        /\
    =====      /  \
   _|___|_____/ __ \____________
  |::::::::::/ |  | \:::::::::::|
  |:::::::::/  ====  \::::::::::|   
  |::::::::/__________\:::::::::|
  |_________|  ____  |__________|
  | ______ | / || \ | _______ |
  ||  |   || ====== ||   |   ||
  ||--+---|| |    | ||---+---||
  ||__|___|| |   o| ||___|___||
  |========| |____| |=========|
  (^^-^^^^^-|________|-^^^--^^^)
  (,, , ,, ,/________\,,,, ,, ,)
 ','',,,,' /__________\,,,',',;;";

            string leavingArt = @"
oOOO()
/ _)
| (
\__)  ()OOOo
       (_  \
         ) |
oOOO() (__ /
/ _)
| (
\__)  ()OOOo
       (_  \
         ) |
        (__/";


            //Vi kollar om du varit här tidigare och ger dig korrekt text

            if (visited > 0)
            {
                if (levelnfo == 1) // Om det inte är lika med 1 så betyder det att du har dött och ska Respawna
                {
                    Console.Clear();
                    Console.WriteLine("***************************************\n");
                    Console.WriteLine("Glömt något? " + characterName);
                    Console.WriteLine("");
                    Console.WriteLine(houseArt);
                    Console.WriteLine("\nVälj: 'kylskåp', en 'skänk' och en 'dörr'");

                }
                else
                {
                    //När du dött och förlorar allt du plockat på dig tidigare
                    Console.Clear();
                    Console.WriteLine("***************************************\n");
                    Console.WriteLine(characterName + " is Dead. Respawn i huset");
                    Console.WriteLine(houseArt);
                    Console.WriteLine("");
                    Console.WriteLine("Var vill du leta? 'kylskåp' 'skänk' eller 'dörr'? Tänk på att dörren tar dig ut från huset");
                    tittaISkänk = 0;
                    tittaIKyl = 0;
                    inventory.hasGun = false;
                    inventory.hasKey = false;
                    inventory.hasMap = false;
                    inventory.hasSalmon = false;
                    inventory.hasTicket = false;
                    inventory.hasWallet = false;
                }
               
            }
            else //Första meddelandet du får vid start
            {
                Console.Clear();
                Console.WriteLine("***************************************\n");
                Console.WriteLine("Godmorgon! " + characterName);
                Console.WriteLine("");
                Console.Write("Du har precis vaknat i ett främmande hus efter en riktig brakfest.\nDin uppgift är att försöka ta dig hem.\n");
                Console.WriteLine(houseArt);
                Console.WriteLine("\nI huset ser du ett bland annat ett 'kylskåp', en 'skänk' och en 'dörr'");
                Console.WriteLine("Skriv vart vill du börja leta för att hitta hem?");
            }

            //Tar input från användaren och omvandlar till små bokstäver
            choice = Console.ReadLine().ToLower();
            Console.Clear();

            //Kör igenom valen en gång först, sen loop tills choice = dörr
            do
            {
                

                switch (choice)
                {
                    case "kylskåp":

                        if (tittaIKyl == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("***************************************\n");
                            Console.WriteLine("I kylskåpet låg massa öl, kan vara gött med en återställare kanske. Men det är viktigare att komma hem.");
                            Console.WriteLine("En lax hittade du med, den sparar vi. Kan man kankske lura iväg vilda djur med på vägen.\n");

                            inventory.hasSalmon = true; //Fyller på "inventoryn" med lax

                            
                            letat = true;

                            //En metod för att fråga och visa inventoryn. Argument. Letat är för att visa att vi har lagt till en sak iinvetoryn
                            inventory.ShowInv(characterType, letat);
                        }
                        if (tittaIKyl > 0)
                        {
                            if (tittaIKyl == 1)
                            {
                                Console.Clear();
                                Console.WriteLine("***************************************\n");
                                Console.WriteLine("Du har redan varit här och letat en gång.");
                                Console.WriteLine("\nEnter för att fortsätta");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("***************************************\n");
                                Console.WriteLine($"Du har redan varit här och letat {tittaIKyl} gånger.");
                            }
                            Console.WriteLine("Onödigt att leta på samma ställe igen, välj ett annat alterativ");
                            Console.WriteLine("\nEnter för att fortsätta");
                            Console.ReadKey();
                            letat = true;
                        }
                        tittaIKyl++;
                        break;

                    case "skänk":

                        if (tittaISkänk == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("***************************************\n");
                            Console.WriteLine("Du hittade en nyckel och din plånbok. Dom sparar vi!\n");

                            inventory.hasWallet = true; //Fyller på "inventoryn" med plånbok
                            inventory.hasKey = true;    //Fyller på "inventoryn" med en nyckel

                            letat = true;


                            //En metod för att fråga och visa inventoryn. Argument. Letat(bool = true) är för att visa 'item added'
                            inventory.ShowInv(characterType, letat);

                        }
                        if (tittaISkänk > 0)
                        {

                            if (tittaISkänk == 1)
                            {
                                Console.Clear();
                                Console.WriteLine("***************************************\n");
                                Console.WriteLine("Du har redan varit här och letat en gång.");
                                Console.WriteLine("\nEnter för att fortsätta");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("***************************************\n");
                                Console.WriteLine($"Du har redan varit här och letat {tittaISkänk} gånger.");
                            }
                            Console.WriteLine("Onödigt att leta på samma ställe igen, välj ett annat alterativ");
                            Console.WriteLine("\nEnter för att fortsätta");
                            Console.ReadKey();
                            letat = true;
                        }

                        tittaISkänk++;
                        break;

                    case "easter":
                        return 3;

                    default:
                        //När det blir fel
                        while (choice != "kylskåp" && choice != "skänk" && choice != "dörr")
                        {
                            Console.Clear();
                            Console.WriteLine("***************************************\n");
                            Console.WriteLine("Fel input.");
                            Console.WriteLine(@"Skriv: 'kylskåp' 'skänk' eller 'dörr':");
                            choice = Console.ReadLine().ToLower();
                            Console.Clear();
                        }
                        continue;
                        
                }

                //Om du har letat ska du få ny text och nya val
                if (letat)
                {
                    Console.Clear();
                    Console.WriteLine("***************************************\n");
                    Console.WriteLine("Vill du leta mer eller kanske använda dörren?");
                    Console.WriteLine(@"Välj 'kylskåp' 'skänk' eller 'dörr':");
                    choice = Console.ReadLine().ToLower();
                    Console.Clear();
                }
            } while (choice != "dörr");


            if (letat)
            {
                Console.Clear();
                Console.WriteLine("***************************************\n");
                Console.WriteLine(leavingArt);
                Console.WriteLine("Du gick ut till trädgården.");
                Console.WriteLine("\nEnter för att fortsätta");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("***************************************\n");
                Console.WriteLine(leavingArt);
                Console.WriteLine("Du gick ut, det var lite dumt. För nu har du inget med dig.");
                Console.WriteLine("\nEnter för att fortsätta");
                Console.ReadKey();
            }
            return 0;
        }
    }
}
