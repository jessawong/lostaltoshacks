using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTest
{
    class HangmanGame
    {
        public static readonly String DICTIONARY_FILE = "../../Resources/dictionary.txt";
        static void Main(string[] args)
        {

            List<string> dictionary = new List<string>();
            using (StreamReader streamer = File.OpenText(DICTIONARY_FILE))
            {
                while (!streamer.EndOfStream)
                {
                    dictionary.Add(streamer.ReadLine());
                }
            }

            string playAgain = "y";
            while (playAgain.StartsWith("y"))
            {
                Console.WriteLine("Hello Los Altos Hacks! :)");
                Console.WriteLine("Let's play a game...");
                Console.WriteLine();

                Console.WriteLine("What length word do you want to use? ");
                int length = int.Parse(Console.ReadLine());

                Console.WriteLine("How many wrong answers allowed? ");
                int max = int.Parse(Console.ReadLine());
                Console.WriteLine();

                HangmanDirector hangman = new HangmanDirector(dictionary, length, max);

                if (hangman.words().Count == 0)
                {
                    Console.WriteLine("No words of that length is in the dictionary.");
                }
                else
                {
                    PlayGame(hangman);
                    playAgain = ShowResults(hangman);
                }
            }
        }

        public static void PlayGame(HangmanDirector hangman)
        {
            while (hangman.guessesLeft() > 0 && hangman.pattern().Contains("-"))
            {
                Console.WriteLine("guesses : " + hangman.guessesLeft());
                Console.WriteLine("guessed : [" + string.Join(", ", hangman.guesses()) + "]");
                Console.WriteLine("current : " + hangman.pattern());
                Console.WriteLine("Your guess? ");
                char character = Console.ReadLine().ElementAt(0) ;
                if (hangman.guesses().Contains(character))
                {
                    Console.WriteLine("You already guessed that!");
                }
                else
                {
                    var count = hangman.record(character);
                    if (count == 0)
                    {
                        Console.WriteLine("Sorry there are no " + character + "'s");
                    }
                    else if (count == 1)
                    {
                        Console.WriteLine("Yes, there is one " + character);
                    }
                    else
                    {
                        Console.WriteLine("Yes, there are " + count + " " + character + "'s");
                    }
                }
                Console.WriteLine();

            }
        }

        public static string ShowResults(HangmanDirector hangman)
        {
            var answer = hangman.words().First();
            Console.WriteLine("answer = " + answer);
            if (hangman.guessesLeft() > 0)
            {
                Console.WriteLine("You beat me");
            }
            else
            {
                Console.WriteLine("Sorry, you lose");
            }
            Console.WriteLine("Do you want to play again? (type 'y' to play or enter to exit)");
            return Console.ReadLine();

        }
    }
}
