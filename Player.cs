using System;


namespace EscapeRoom
{
        public class Player
        {
        
        
        public string characterName; 
        public int characterType;       // 1 - för indian. 2 - För monopolgubben.
            
            public void CreatePerson()
            {

            string arnold = @"

                     ______
                   <((((((\\\
                   /      . }\
                   ;--..--._|}
(\                 '--/\--'  )
 \\                | '-'  :'|
  \\               . -==- .-|
   \\               \.__.'   \--._
   [\\          __.--|       //  _/'--.
   \ \\       .'-._ ('-----'/ __/      \
    \ \\     /   __>|      | '--.       |
     \ \\   |   \   |     /    /       /
      \ '\ /     \  |     |  _/       /
       \  \       \ |     | /        /
        \  \      \        /


";
                string charArt = @"


            /:\                .------\ /------.
            >:<                |       -       |    
            >:<                |       -       |   
            >:<                |       -       |  
       ,,,,,\:/                |       -       |  
      #########             _______________________
     //////\\\\\            ===========.===========
    // /_\ /_\ \\             / ~~~~~     ~~~~~ \
    \(  0 _ 0  )/            /|   /O|     |o\   |\
    /\\=  _\ =//\            W   ---  / \  ---   W
    \\/\ --- /\//            \.      |o o|      ./
    //\ '---' /\\             |                 |
    \//       \\/             \    #########    /
    /\\       //\              \  ## ----- ##  /
    \\/       \//               \##         ##/
     #         #                 \_____v_____/

";
          

                string palyerArt = @"
 __   _                       _                       
|| \ | |                     | |                      
||  \| | _____      __  _ __ | | __ _ _   _  ___ _ __ 
|| . ` |/ _ \ \ /\ / / | '_ \| |/ _` | | | |/ _ \ '__|
|| |\  |  __/\ V  V /  | |_) | | (_| | |_| |  __/ |   
\\_| \_/\___| \_/\_/   | .__/|_|\__,_|\__, |\___|_|   
                       | |             __/ |          
                       |_|            |___/           

";
                string pressKey;

                Console.Clear();
                Console.WriteLine(palyerArt);
                Console.WriteLine("Skapa ny spelare");
                Console.WriteLine("Skriv in namn: ");
                characterName = Console.ReadLine();


            //Loop för att se till att rätt knapp trycks in
            do
            {
                Console.Clear();
                Console.Write(charArt);
                Console.WriteLine(@"Välj karaktär genom att trycka 'A' eller 'B'");

                pressKey = Console.ReadKey().Key.ToString();
                pressKey = pressKey.ToUpper();
                if (pressKey == "A")
                {
                    characterType = 1;
                    Console.Clear();
                    Console.WriteLine("Du valde indianen");
                    Console.WriteLine("\nEnter för att fortsätta");
                    Console.ReadKey();
                }
                else if (pressKey == "B")
                {
                    characterType = 2;
                    Console.Clear();
                    Console.WriteLine("Du valde Monopolgubben");
                    Console.WriteLine("\nEnter för att fortsätta");
                    Console.ReadKey();
                }
                else if (pressKey == "T")
                {
                    characterType = 3;
                    Console.Clear();
                    Console.WriteLine("Du valde Arnold");
                    Console.WriteLine(arnold);
                    Console.WriteLine("\nEnter för att fortsätta");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Du tryckte fel, försök igen");
                    System.Threading.Thread.Sleep(800);
                }

                } while (pressKey != "A" && pressKey != "B" && pressKey != "T");
            }
        }
}
