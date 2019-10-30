using System;
using System.Collections.Generic;

namespace Assignment02MikaelAurell
{
    class Program
    {
        static void Main(string[] args)
        {

            string secretWord = CreateSecretWord();
            
            Console.WriteLine($"{secretWord} \n");
            int x = 1;
            List<char> charList = new List<char>();
            char charGuess;
            while (x < 21)
            {
                char[] gameStatus = new char[secretWord.Length];
                Console.Write("Your word contains of :");
                for (int i = 0; i < secretWord.Length; i++)
                {

                    gameStatus[i] = '_';
                    Console.Write($"{gameStatus[i]}");
                }
                
                Console.Write($" You have {21-x} guess left.  Type a guess: ");
                string userGuess = Console.ReadLine();
                x++;
                
                


                if (userGuess.Length == 1)
                {
                    if (charList.Count < 2)
                    {
                        charGuess = userGuess[0];
                        charList.Add(charGuess);
                    }
                    else
                    {
                        for (int i = 0; i < charList.Count; i++) //Finns bokstaven?
                        {
                            charGuess = userGuess[0];
                            if (charList[i] == charGuess)
                            {
                                Console.WriteLine("You have allready typed that character");
                            }
                            else
                            {
                                charList.Add(charGuess);

                            }
                        }
                    }

                }
                else
                {
                    if (secretWord.Equals(userGuess)==true)
                    {
                        Console.WriteLine("Congratulations you have typed the right answer!");
                        x = 22;
                    }

                }
            }
        }
        /*static string CheckTheInput(string userGuess, string secretWord)
        {
            if (userGuess.Length < 2)
            {
            char guessIsChar = userGuess[0];

            }
        }*/

        

        static string CreateSecretWord()
        {
            string[] dataString = new string[10];

            dataString[0] = "Emma";
            dataString[1] = "Ebba";
            dataString[2] = "Bengt";
            dataString[4] = "Linn";
            dataString[5] = "Mikael";
            dataString[6] = "Ida";
            dataString[7] = "Anna";
            dataString[8] = "Karl";
            dataString[9] = "Elin";

            var random = new Random();
            int result = random.Next(0, 9);
            string randomString = dataString[result];
            return randomString;

        }

        static string AskForWordOrChar()
        {
            Console.WriteLine("Type a word or a char");
            string questionString = Console.ReadLine();
            return questionString;

        }

        
    }
}
