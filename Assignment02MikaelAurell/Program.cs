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
            Console.WriteLine("Type a guess: ");
            string userGuess = Console.ReadLine();
            List<char> charList = new List<char>();
            char charGuess;
            
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
                            Console.WriteLine("You have all ready typed that character");
                        }
                        else
                        {
                            charList.Add(charGuess);

                        }
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

        /* static int CompareArrays(char[] myCharArray,char[] qCharArray,string qString)
         {

             for (int i = 0; i < qString.Length; i++)
             {
                 int right = 0;
                 if (myCharArray[i] == qCharArray[i])
                 {
                     char rightChar = qCharArray[i];
                     right = 1;
                     return right;
                 }

                 return right;

             }
         }*/

        /*static List<char> makeCharList(string myString)
        {
            List<char> charList = new List<char>();
            for (int i = 0; i < myString.Length; i++)
            {
               
                charList.Add(char.Parse(myString.Substring(i, 1)));
            }
            return charList;
        }
        
         char[] myCharArray = new char[secretWord.Length];
            myCharArray= secretWord.ToCharArray();
            Console.WriteLine($"{secretWord}");
            string userGuess = AskForWordOrChar();
            if (userGuess.Length <2)
                char 
            char[] qCharArray = new char[qString.Length];
            qCharArray = qString.ToCharArray();

            bool equalwords = qCharArray.Equals(myCharArray);

            Console.WriteLine($"{equalwords}");
         
         */
    }
}
