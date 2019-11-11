using System;
/*
 Enums är för att slippa if-satser.

 Alla med värde 1 tillhör Indianen, värde 2 Monopolgubben, värde 3 Arnold
 Och skulle vi vilja lägga till fler är det lätt att göra på ett ställe
 */
public enum BagType
{
    tygpåse = 1,
    hatt = 2,
    duffelbag = 3
}
public enum WeaponType
{
    pilbåge = 1,
    hagelbössa = 2,
    minigun = 3
}

namespace EscapeRoom
{
    class Program
    {
        static void Main(string[] args)
        {

            bool win = false;                   //För att vinna såklart
            int toLevel = 1;                    //Vilken är nästa level du ska till? Bröja med 1 för att komma till huset
            int levelInfo = 1;                  //Info från tidigare lvl om vad som hänt där. Tillbaka, död eller framåt. Eller annan info.
            int timesInHouse = 0;               //För att kunna skicka tillbaka till Level 1 att man redan varit där
            int timesInGarden = 0;              //För att kunna skicka tillbaka till Level 2 att man redan varit där
            int timesOnRoad = 0;                //För att kunna skicka tillbaka till Level 3 att man redan varit där
            int timesIFeed = 0;                   // För att kunna skicka tillbaka till level4 att man redan varit där
            int timesInBus = 0;                 //För att kunna skicka tillbaka till Level 5 att man redan varit där
            int fromLevel = 0;

            var inventory = new Inventory();        //Skapa en inventory för spelaren att ha sakerna i
            var player = new Player();              //Skapa spelare
            var world1 = new House(inventory);      //Level 1
            var world2 = new Garden(inventory);     //Level 2
            var world3 = new Road(inventory);       //Level 3
            var world4 = new Feed(inventory);       //Level 4
            var world5 = new Bus(inventory);        //Level 5

            FirstWelcome(); //Hälsa välkommen
            player.CreatePerson(); //Skapa Spelare

            do //Själva spelandet
            {
                // toLevel indikerar vilken värld du ska till nästa gång
                switch (toLevel)
                {
                    case 1:
                        //Eftersom du inte kan gå tillbaka så retunerar denna inget. Rakt till lvl2
                        levelInfo = world1.Room1(levelInfo, timesInHouse, player.characterName, player.characterType);
                        timesInHouse++;
                        toLevel = 2;
                        fromLevel = 1;
                        if (levelInfo == 3)
                        {
                            Easter();
                            win = true;
                        }
                        break;
                    case 2:
                        // 3 = Gå vidare till Vägen, 1 = Tillbaka till huset
                        levelInfo = world2.Room2(fromLevel, timesInGarden, player.characterType);
                        if (levelInfo == 3)
                            toLevel = 3;
                        if (levelInfo == 1)
                            toLevel = 1;

                        timesInGarden++;
                        break;
                    case 3: //höger eller vänster
                        // 4 = Gå vidare till mata, 2 = Tillbaka till Trädgården
                        levelInfo = world3.Room3(fromLevel, player.characterType);
                        
                        if (levelInfo == 2)
                        {
                            toLevel = 2;
                            fromLevel = 3;
                        }
                        if (levelInfo == 4)
                        {
                            toLevel = 4;
                        }

                        timesOnRoad++;
                        break;
                    case 4: //mata skjuta
                        levelInfo = world4.Room4(player.characterType);
                        // 5 = Gå vidare till Bussen, 2 = Tillbaka till Trädgården, 1 = Död, tillbaka till huset 
                        if (levelInfo == 1)
                            toLevel = 1;

                        if (levelInfo == 2)
                        {
                            toLevel = 2;
                            fromLevel = 3;
                        }
                        if (levelInfo == 5)
                            toLevel = 5;

                        timesIFeed++;
                        break;
                    case 5:
                        // 6 = win, 3 = tillbaka till föregående, 1 = Hela vägen tillbaka till huset
                        levelInfo = world5.Bus1();
                        if (levelInfo == 6)
                        {
                            win = true;
                        }
                        if (levelInfo == 3)
                            toLevel = 3;
                        if (levelInfo == 1)
                            toLevel = 1;

                        timesInBus++;
                        break;

                } //End swtich case

            } while (!win);

            //For loop för att visa blinkande text "You Win"
            string winning = @"

__   __             __    _ _____ _   _ 
\\ \ / /           || |  | |_   _| \ | |
 \\ V /___  _   _  || |  | | | | |  \| |
  \\ // _ \| | | | || |/\| | | | | . ` |
  || | (_) | |_| | \\  /\  /_| |_| |\  |
  \\_/\___/ \__,_|  \\/  \/ \___/\_| \_/";

            for (int i = 0; i < 3; i++)
            {
                foreach (ConsoleColor c in Enum.GetValues(typeof(ConsoleColor)))
                {
                    Console.ForegroundColor = c;
                    Console.WriteLine(winning);
                    System.Threading.Thread.Sleep(100); // 0,1 sec. deley
                    Console.Clear();
                }
            }
        }

        /************************************************
         *                                              *
         *  Här börjar "Easter egg" ett labyrint spel   *   
         *  Där man kan vinna direkt.                   *
         *                                              *
         ************************************************/

        static void Easter()
        {


            const int BoxX = 60; //Storlek på ytterväggarna
            const int BoxY = 20;

            Random rnd = new Random();
            int fininsh = rnd.Next(5, 50); // Random utgång

            int[] position; // håller koll på vart spelaren är under hela spelet
            position = new int[2] { 15, (BoxY + 2) }; //Start position


            //Skapa en array av väggar
            Wall[] walls = new Wall[7];
            //Inintiera dom
            walls[0] = new Wall();
            walls[1] = new Wall();
            walls[2] = new Wall();
            walls[3] = new Wall();
            walls[4] = new Wall();
            walls[5] = new Wall();
            walls[6] = new Wall();
            //Skapa nya väggar                      Gå ej utanför boxen. då blir det för fel
            walls[0].SetInfo(11, 13, 12, 1);
            walls[1].SetInfo(8, 17, 15, 1);                 // Length, Start X, Start Y, 0(X) eller 1(Y) 
            walls[2].SetInfo(30, 13, 12, 0);                //  Y = mellan 3 och 23
            walls[3].SetInfo(2, 43, 21, 1);                 //  X = mellan 2 och 61
            walls[4].SetInfo(5, 43, 12, 1);
            walls[5].SetInfo(40, 21, 7, 0);
            walls[6].SetInfo(3, 21, 6, 1);

            Welcome();
            Console.Clear();

            //The playing
            do
            {

                Box(BoxX, BoxY, fininsh);

                Wallx(walls);

                WallY(walls); //Alltid neråt

                position = Move(position, BoxX, BoxY, fininsh, walls);

            } while (position[0] != (fininsh + 1) || position[1] != 2);

            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(position[0], position[1]);
            Console.WriteLine(" ");
            Console.ResetColor();

            

        }

        static void Welcome()
        {
            Console.WriteLine("*******************************************\n\n");
            Console.WriteLine(@"

 _____          _            _____            
|  ___|        | |          |  ___|           
| |__  __ _ ___| |_ ___ _ __| |__  __ _  __ _ 
|  __|/ _` / __| __/ _ \ '__|  __|/ _` |/ _` |
| |__| (_| \__ \ ||  __/ |  | |__| (_| | (_| |
\____/\__,_|___/\__\___|_|  \____/\__, |\__, |
                                   __/ | __/ |
                                  |___/ |___/ 

");
            Console.WriteLine("Försök ta dig ut om du kan ;)");
            Console.WriteLine("");
            Console.WriteLine("Du styr med 'a' 's' 'd' 'w'");
            Console.WriteLine("\nLycka till");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

        }
        static void FirstWelcome()
        {

            string art = @"

 _    _      _                          
| |  | |    | |                         
| |  | | ___| | ___ ___  _ __ ___   ___ 
| |/\| |/ _ \ |/ __/ _ \| '_ ` _ \ / _ \
\  /\  /  __/ | (_| (_) | | | | | |  __/
 \/  \/ \___|_|\___\___/|_| |_| |_|\___|
                                        
                                        
";
            Console.WriteLine(art);
            Console.WriteLine("Undra om du kan hitta några easter egg ;)");
            Console.WriteLine("Lycka till!");
            Console.WriteLine("Tryck enter för att fortsätta");
            Console.ReadKey();
        }

        //Ritar upp boxen
        static void Box(int x, int y, int goal) 
        {
            Console.SetCursorPosition(0, 2);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(" ");
            for (int i = 0; i < x; i++)
            {
                if (i == goal) { Console.Write(" "); }
                else { Console.Write("_"); }
            }
            Console.WriteLine("");
            for (int i = 0; i < y; i++)
            {
                Console.Write("|");
                for (int j = 0; j < x; j++)
                {
                    if (i == (y - 1))
                    {
                        Console.Write("_");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("|");
            }
            Console.ResetColor();
        }

        //Ritar upp väggarna i x-led
        static void Wallx(Wall[] wall)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            for (int j = 0; j < wall.Length; j++)
            {
                if (wall[j].dir == 0)
                {
                    for (int i = 0; i < wall[j].length; i++)
                    {
                        Console.SetCursorPosition((wall[j].startx + i), wall[j].starty);
                        Console.Write("#");
                    }
                }
            }

            Console.ResetColor();
        }

        //Ritar upp väggarna i Y-led
        static void WallY(Wall[] wall)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            for (int j = 0; j < wall.Length; j++)
            {
                if (wall[j].dir == 1)
                {
                    for (int i = 0; i < wall[j].length; i++)
                    {
                        Console.SetCursorPosition(wall[j].startx, (wall[j].starty + i));
                        Console.Write("#");
                    }
                }
            }

            Console.ResetColor();
        }

        //Tar input från spelaren och flyttar spelaren ett steg
        static int[] Move(int[] posi, int boxx, int boxy, int goal, Wall[] wall)
        {
            boxy += 2; //Offset the box for nice looks
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(posi[0], posi[1]);
            Console.WriteLine(" ");
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
            var input = Console.ReadKey(true);

            string dir;
            switch (input.Key) //Switch on Key enum
            {
                case ConsoleKey.W:
                    dir = "n";
                    if (posi[1] != 3 && !Hit(wall, posi, dir))
                    {
                        posi[1]--;
                    }
                    else if (posi[1] == 3 && posi[0] == (goal + 1))
                    {
                        posi[1]--;

                        Console.ResetColor();
                    }
                    break;
                case ConsoleKey.S:
                    dir = "s";

                    if (posi[1] != boxy && !Hit(wall, posi, dir))
                    {
                        posi[1]++;
                    }
                    break;
                case ConsoleKey.A:
                    dir = "e";
                    if (posi[0] != 1 && !Hit(wall, posi, dir))
                    {
                        posi[0]--;
                    }
                    break;
                case ConsoleKey.D:
                    dir = "w";
                    if (posi[0] != boxx && !Hit(wall, posi, dir))
                    {
                        posi[0]++;
                    }
                    break;
                default:
                    break;
            }

            Console.ResetColor();
            return posi;
        }

        //Kollar ifall det är en vägg i ivägen. Retunernar True om det är en vägg i vägen
        static bool Hit(Wall[] wall, int[] posi, string dir)
        {
            bool hit = false;

            for (int i = 0; i < wall.Length; i++)
            {
                int length = 0;
                int height = 0;

                if (wall[i].dir == 0)
                {
                    length = wall[i].startx + wall[i].length;
                }
                else
                {
                    height = wall[i].starty + wall[i].length;
                }
                switch (dir)
                {
                    case "n":
                        {        //                      För en wägg i X-Axeln                                        //    //             För en vägg i Y-Axeln                                         //
                            if ((((posi[1] - 1) == wall[i].starty) && posi[0] >= wall[i].startx && posi[0] < length || (posi[1] - 1 == (wall[i].starty + wall[i].length - 1)) && posi[0] == wall[i].startx))
                            {
                                hit = true;
                            }
                            break;
                        }
                    case "s":
                        {     //                      För en wägg i X-Axeln                                        //    //             För en vägg i Y-Axeln                                         //
                            if (((posi[1] + 1) == wall[i].starty) && (posi[0] >= wall[i].startx && posi[0] < length || posi[1] + 1 == wall[i].starty && posi[0] == wall[i].startx))
                            {
                                hit = true;
                            }
                            break;
                        }
                    case "e":
                        {
                            if ((((posi[0] - 1) == wall[i].startx) && (posi[1] >= wall[i].starty && posi[1] < height) || (posi[0] - 1 == (wall[i].starty + wall[i].length - 1)) && posi[1] == wall[i].startx))
                            {
                                hit = true;
                            }
                            break;
                        }
                    case "w":
                        if (((posi[0] + 1) == wall[i].startx) && (posi[1] >= wall[i].starty && posi[1] < height || posi[0] + 1 == wall[i].starty && posi[1] == wall[i].startx))
                        {
                            hit = true;
                        }
                        break;
                }
            }
            return hit;
        }
    }

    class Wall
    {

        public int length;
        public int startx;
        public int starty;
        public int dir;


        public void SetInfo(int length, int startx, int starty, int dir)
        {
            this.startx = startx;
            this.starty = starty;
            this.length = length;
            this.dir = dir;
        }

    }

}
