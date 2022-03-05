using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
        //Hangman Program.
        play:
            //Declare character variables.
            Random rnd = new Random();
            string[] words = {"tree", "pickle", "bear", "grass", "orange", "people", "gay", "hope", "antibiotics", "peer",
                                 "trample", "eat", "air", "water", "fire", "terror", "failure", "success",
                                 "food", "drink", "snack", "chair", "house", "television", "remote", "mouse", "elephant",
                                 "car", "hair", "consequence", "sword", "shield", "helmet", "armor", "love", "happy", "happiness", "sad",
                                 "sadness", "fan", "medicine", "drugs", "shoe", "flipper", "keys", "eye", "hell", "heaven", "father", "mother",
                                 "brother", "sister", "nephew", "niece", "uncle", "aunt", "grandfather", "grandmother",
                                 "flower", "soda", "cocaine", "bitch", "dog", "woman", "man", "asshole", "blanket", "cable", "satellite","apple",
                                 "destruction", "explosion", "movie", "popcorn", "corn", "cricket", "bug", "spider", "bed", "sex", "pillow", "sheet",
                                 "truck", "tower", "dungeon", "chest", "computer", "laptop", "silence", "star", "ball", "toy", "purse", "bag", "backpack",
                                 "straight", "narrow", "keyboard", "guitar", "drums", "microphone", "disc", "planet", "socks", "hug", "firefly", "fox",
                                 "thread", "string", "believe", "slowly", "sleep", "help", "insomniac", "sheep", "tire", "hello", "dream", "hanger", "refridgerator",
                                 "train", "locomotion", "physics", "universe", "hole", "black", "red", "white", "blue", "yellow", "green", "purple", "violet",
                                 "rain", "snow", "leaves", "child", "end", "beginning", "power", "pray", "heal", "heel", "lingerie", "shirt", "pants", "denim",
                                 "mystery", "stranded", "call", "sing", "dance", "music", "band", "tap", "purgatory", "calculator", "time", "clock", "flag", "window",
                                 "choir", "organ", "head", "shoulder", "elbow", "knee", "shin", "back", "front", "brain", "heart", "cerebrum",
                                 "ovary", "ovum", "penis", "butt", "thigh", "breast", "bra", "surf", "penguin", "cat", "dog", "lion", "giraffe",
                                 "zebra", "otter", "ferret", "bird", "peacock", "person", "mayor", "upset", "girl", "boy", "baby", "young", "old", "adult",
                                 "teenager", "take", "steal", "preach", "hand", "finger", "toe", "pregnant", "family", "sacrifice", "advice", "psalm",
                                 "run", "fall", "jump", "slide", "drive", "bicycle", "fly", "plane", "automobile", "scratch", "brush", "plunger", "toilet",
                                 "towel", "lips", "nose", "ear", "spear", "trap", "door", "floor", "roof", "house", "apartment", "home", "trailer",
                                 "telephone", "fax", "pager", "mail", "box", "cut", "slam", "yell", "pear", "banana", "hypochondriac"};
            char[] word = words[rnd.Next(0, words.Length)].ToCharArray();
            char letter = ' ';
            char[] guessed = new char[26];

            //Declare score variable.
            int score = 0;
            int index = 0;
            bool found = false;

            //Declare stop variable.
            int wordCount = 0;

            //Declare etc variables.
            string answer = "a";

            //Greetings.
            Console.WriteLine("Welcome to the Hangman Game!");
            Console.WriteLine("\nYou will have " + word.Length + " guesses to try to figure out the word below.");
            Console.WriteLine("If you can guess the word within " + word.Length + " tries, you win and the game will stop.");
            Console.WriteLine("The lower your score at the end of the game, the better.");
            Console.WriteLine("Good luck.\n");
            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < word.Length; j++)
                {
                    for (int g = 0; g < word.Length; g++)
                    {
                        if (word[j] == guessed[g])
                        {
                            found = true;
                        }
                    }
                    if (found == true)
                    {
                        Console.Write(word[j]);
                        found = false;
                        wordCount++;
                        if (wordCount == word.Length)
                        {
                            Console.WriteLine("\n\n\nYou have guessed the word! Congratulations!");
                            goto gameOver;
                        }
                    }
                    else
                    {
                        Console.Write("*");
                        wordCount = 0;
                    }
                }
                Console.Write("\n\nPlease enter a letter: ");
                letter = char.Parse(Console.ReadLine());
                if (word.Contains(letter))
                {
                    Console.WriteLine("You guessed correctly!");
                    guessed[index] = letter;
                    index++;
                }
                else
                {
                    Console.WriteLine("You guessed wrong!");
                    score++;
                }
            }
        gameOver:
            Console.Write("\n\nYour score is: " + score + " point(s)");
            Console.Write("\nWould you like to play again [Y/N]? ");
            answer = Console.ReadLine();
            if ((answer == "Y") || (answer == "y"))
            {
                Console.Clear();
                goto play;
            }
            else
            {
                Console.Write("Goodbye.");
            }

            //Keep window open.
            Console.ReadLine();

        }
    }
}
