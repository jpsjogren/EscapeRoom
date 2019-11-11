using System;
namespace EscapeRoom
{
    public class Bus
    {
        public Bus(Inventory i)
        {
            inventory = i;
        }
        private Inventory inventory;

        public int Bus1()
        {
            int win = 0;            // 1 = win, 2 = tillbaka till föregående, 3 = Tillbaka till huset
            string choice;          //Input från användaren
            string pressKey;        //För "snabbval"
            int bussen = 0;
            int visited = 0;
            

            string inputChoice = @"Val: 'prata' med en random person, försöka köpa en 'biljett' i kiosken, går till 'bussen' eller ta vägen 'tillbaka'  därifrån du kom.";

            string central = @"
 _____            _             _     _        _   _             
/  __ \          | |           | |   | |      | | (_)
| /  \/ ___ _ __ | |_ _ __ __ _| |___| |_ __ _| |_ _  ___  _ __  
| |    / _ \ '_ \| __| '__/ _` | / __| __/ _` | __| |/ _ \| '_ \ 
| \__/\  __/ | | | |_| | | (_| | \__ \ || (_| | |_| | (_) | | | |
 \____/\___|_| |_|\__|_|  \__,_|_|___/\__\__,_|\__|_|\___/|_| |_|


";

            //If visited->välkommen tillbaka
            //Else -> välkommen för första gången

            if (visited > 0) //Har du redan varit här och letat ska du ha annan text
            {

                Console.Clear();
                Console.WriteLine(central);
                //Inledande text, berätta vad som finns här. Och vilka val som kan göras
                Console.WriteLine("Du som varit här innan vet säkert vad du ska göra för att hitta hem ;)");
                Console.WriteLine(inputChoice);
                Console.Write("> ");

                choice = Console.ReadLine().ToLower();
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine(central);
                //Inledande text, berätta vad som finns här. Och vilka val som kan göras
                Console.WriteLine("Du har nu tagit dig hela vägen till Centralstationen. Här ifrån går din buss hem.");
                Console.WriteLine("Men för att kunna komma hem och äta din bakispizza behöver du ta dig på bussen som står och väntar på dig där borta.\n");
                Console.WriteLine(inputChoice);
                Console.Write("> ");

                choice = Console.ReadLine().ToLower();
                Console.Clear();
            }

            Console.WriteLine(choice);
            //Mata in val
            //Do while "vägen" eller win
            do
            {
                //Switch case med alla val

                switch (choice)
                {
                    case "prata":

                        Console.Clear();
                        RandomPerson.Talk();

                        break;

                    case "biljett":

                        Console.Clear();
                        Console.WriteLine("Hej! Vill du ha en biljett? \nTryck: J/N");
                            pressKey = Console.ReadKey().Key.ToString();
                        if (pressKey.ToUpper() == "J")
                        {
                            
                            //Har du pengar?
                            if (inventory.hasWallet && !inventory.hasTicket)
                            {
                                Console.Clear();
                                Console.WriteLine("Det blir 29kr tack");
                                Console.WriteLine("Varsågod, här är 30kr. Behåll växeln");
                                Console.WriteLine("\nEnter för att fortsätta");
                                Console.ReadKey();
                                //Bli av med dina pengar.
                                inventory.hasTicket = true;
                                inventory.hasWallet = false;
                            }
                            else if (!inventory.hasTicket && !inventory.hasWallet)
                            {

                                Console.Clear();
                                Console.WriteLine("Du har ingen plånbok med dig. Hmm, du får nog leta i huset igen");
                                Console.WriteLine("Tryck enter för att teleporteras tillbaka till huset\n");
                                Console.ReadKey();
                                Console.Write("3...");
                                System.Threading.Thread.Sleep(500);
                                Console.Write("2...");
                                System.Threading.Thread.Sleep(500);
                                Console.Write("1...");
                                System.Threading.Thread.Sleep(500);
                                win = 1;
                                return win;
                            }
                            else if (inventory.hasTicket)
                            {
                                Console.Clear();
                                Console.WriteLine("Du hade bara pengar till en biljett, gå till bussen och åk hem.");
                                Console.WriteLine("\nEnter för att fortsätta");
                                Console.ReadKey();
                            }
                        }
                        else
                        {

                            Console.Clear();
                            Console.WriteLine("Vill du inte köpa så behöver du inte.");
                            Console.WriteLine("Enter för att fortsätta");
                            Console.ReadKey();
                        }

                        break;
                    case "tillbaka":

                        Console.Clear();
                        Console.WriteLine("Du vänder tillbaka till vägen");
                        win = 3;

                        return win; // win ska vara false

                    case "bussen":

                        Console.Clear();
                        Console.WriteLine("Chauffören: Hej, har du en biljett?");
                            if (inventory.hasTicket)
                            {
                                Console.WriteLine("Du: Japp, varsågod");
                                Console.WriteLine("Välkommen ombord. Bussen hem går om nån sekund!");
                                System.Threading.Thread.Sleep(4000);
                                win = 6;
                            return win;
                            }
                            else
                            {
                                Console.WriteLine("Jaha, behöver jag en biljett? Då får jag gå till biljettkassan och köpa en");
                                Console.WriteLine("\nEnter för att fortsätta");
                                Console.ReadKey();
                            }


                            bussen++;
                        break;
                    default:
                        //När det blir fel
                        
                        while (choice != "prata" && choice != "biljett" && choice != "tillbaka" && choice != "bussen")
                        {
                            Console.Clear();
                            Console.WriteLine("Fel input.");
                            Console.WriteLine(@"Skriv: 'prata' 'köpa' 'bussen' eller 'vägen':");
                            choice = Console.ReadLine().ToLower();
                            Console.Clear();
                        }

                        continue;
                }// Switch case end

                Console.Clear();
                Console.WriteLine(central);
                //Inledande text, berätta vad som finns här. Och vilka val som kan göras
                Console.WriteLine("Vad är ditt nästa steg?\n");
                Console.WriteLine(inputChoice);
                Console.Write("> ");

                choice = Console.ReadLine().ToLower();

            } while (win != 1);

            return win;
        }
    }
}
