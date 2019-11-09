using System;
namespace EscapeRoom
{
    static public class RandomPerson
    {
        static public void Talk()
        {

            {
                string[] talking = {"No, you don’t have to repeat yourself. I was ignoring you the first time.", "Fighting with me is like being in the special olympics. You may win, but in the end you’re still a retard.",
                    "Everyone has the right to be stupid, but you are abusing the privilege.", "Yet despite the look on my face… you are still talking.",  "Sarcasm – the ability to insult idiots without them realizing it.",
                    "If you find me offensive. Then I suggest you quit finding me.", "Hallå! Ska du ha en öl?" , "When people ask me stupid questions, it is my legal obligation to give a sarcastic remark." , 
                        "It’s okay if you don’t like me. Not everyone has good taste.", "You look good when your eyes are closed, but you look the best when my eyes closed.", "Mirrors can’t talk, lucky for you they can’t laugh either.",
                "I'll try being nicer, if you try being smarter." , "If I promise to miss you, will you go away?", "I’m smiling… that alone should scare you.", "You sound better with your mouth closed."};


                int sayings = talking.Length;
                Random rnd = new Random();
                int rand = rnd.Next(0, (sayings-1));
                Console.WriteLine("***********************************************\n");
                Console.WriteLine(talking[rand]);
                Console.WriteLine("\n\nDet verkade inte hjälpa din resa hem att prata konstigt folk");
                Console.WriteLine("Tryck enter för att fortsätta\n");
                Console.ReadKey();

            }
        }
    }
}
