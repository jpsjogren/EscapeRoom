using System;
namespace EscapeRoom
{
    public class Inventory
    {
        public bool hasSalmon = false;
        public bool hasKey = false;
        public bool hasMap = false;
        public bool hasGun = false;
        public bool hasWallet = false;
        public bool hasTicket = false;

        public void ShowInv(int characterType , bool add)
        {
            string pressKey;
            string itemAdded = "\nItem added";
            string open = "Tryck 'i' för att öppna din " + (BagType)characterType + " eller enter för att fortsätta";
            string inventory = @"
 _____                     _                   
|_   _|                   | |                  
  | | _ ____   _____ _ __ | |_ ___  _ __ _   _ 
  | || '_ \ \ / / _ \ '_ \| __/ _ \| '__| | | |
 _| || | | \ V /  __/ | | | || (_) | |  | |_| |
 \___/_| |_|\_/ \___|_| |_|\__\___/|_|   \__, |
                                          __/ |
                                         |___/ 
";
            string mapArt = @"
 ________________________________________________________________
|                                                  /         /   |
|                                                 / To the  /    |
|                                               /    Bus  /      |
|                                             /          /       |
|                                           /           /        |
|        _____________                    /           /          |
|        |             \                 /    ??    /            |
|        | Dead          \              /    ??   /              |
|        |  end            \           /    ??   /               |
|        |___________        \        /         /                |
|                    \        \      /         /                 |
|                     \        \    /         /                  |
|                      \        |  /         /                   |
|                       \        ||         /                    |
|                       |                  |                     |
|                       |                  |                     |
|                       |                  |                     |
|                       |                  |                     |
|                       |                  |                     |
|                       |                  |                     |
|                       |     The House    |                     |
|                       |          |       |                     |
|                       |          V       |                     |
|_______________________|__________________|_____________________|
";

            Console.WriteLine("**********************************************\n");

            if (add)
            {
                Console.WriteLine(itemAdded);
            }
            Console.WriteLine(open);
            pressKey = Console.ReadKey().Key.ToString();
            if (pressKey.ToUpper() == "I")
            {
                Console.WriteLine("**********************************************");
                Console.WriteLine(inventory);
                Console.WriteLine("Du har i din " + (BagType)characterType + ": \n");
                if (hasSalmon)
                {
                    Console.WriteLine("En lax\n");
                }
                if (hasKey)
                {
                    Console.WriteLine("En nyckel\n");
                }
                if (hasWallet)
                {
                    Console.WriteLine("En plånbok med 30kr och massa kort i\n");
                }
                if (hasMap)
                {
                    Console.WriteLine("En karta\n");
                }
                if (hasGun)
                {
                    Console.WriteLine("En " + (WeaponType)characterType);
                    Console.WriteLine("");
                }
                if (hasTicket)
                {
                    Console.WriteLine("En bussbiljett\n");
                }
                if (!hasKey && !hasMap && !hasSalmon && !hasWallet && hasGun && !hasTicket)
                {
                    Console.WriteLine("Din " + (BagType)characterType + " är tyvärr tom. Du behöver fylla den för att kunna vinna.");
                }

                if (hasMap)
                {
                    Console.WriteLine("\nFör att visa kartan tryck 'M' eller enter för att fortsätta ");
                    pressKey = Console.ReadKey().Key.ToString();
                    if (pressKey.ToUpper() == "M")
                    {
                        Console.Clear();
                        Console.WriteLine(mapArt);
                    }
                }
                Console.WriteLine("\nEnter för att fortsätta");
                Console.ReadKey();

            }

            Console.Clear();
        }
    }
}
