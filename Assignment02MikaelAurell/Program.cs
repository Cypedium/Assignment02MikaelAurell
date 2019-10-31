using System;
using System.Collections.Generic;

namespace Assignment02MikaelAurell
{
    class Program
    {
        static void Main(string[] args)
        {

            string secretWord = CreateSecretWord();
            string secretWordData = secretWord.ToLower();
            char[] secretWordArray = new char[secretWord.Length];
            char[] secretWordArrayData = new char[secretWord.Length];
            secretWordArray = secretWord.ToCharArray();
            secretWordArrayData = secretWordData.ToCharArray();

            Console.WriteLine($"{secretWord} \n");
            int x = 1;
            List<char> charList = new List<char>();
            char charGuess;
            char[] gameStatusBegin = new char[secretWord.Length];
            char[] gameStatus = new char[secretWord.Length];
            for (int i = 0; i < secretWord.Length; i++)
            {

                gameStatusBegin[i] = '_';
                gameStatus[i] = '_';
                
            }
            foreach (char item in charList)
            {
                Console.WriteLine($"{charList}");
            }
            while (x < 21)
            {
                foreach (char listofWrongChar in charList)
                {
                    Console.Write(listofWrongChar);
                }

                Console.Write("Your word contains of :");
                for (int i = 0; i < secretWord.Length; i++)
                {

                    gameStatusBegin[i] = gameStatus[i];

                    Console.Write($"{gameStatusBegin[i]}");
                }
                
                Console.Write($" You have {21-x} guess left.  Type a guess: ");
                string userGuess = Console.ReadLine();
                x++;

                if (userGuess.Length == 1) //Är det ett tecken?
                {
                    for (int y = 0; y < secretWord.Length; y++) //Finns bokstaven i ordet?
                    {
                        if (secretWordArrayData[y] == userGuess[0])
                        {
                            gameStatus[y] = secretWordArray[y];
                        }
                        else
                        {
                            if (charList.Count < 2) //Är Listan tom?
                            {
                                charList.Add(userGuess[0]);
                            }
                            else
                            { 
                                for (int i = 0; i < charList.Count; i++)
                                {

                                    if (charList[i] == userGuess[0]) //Finns bokstaven i den felaktiga listan?
                                    {
                                        Console.WriteLine("You have allready typed that character");
                                       
                            
                                    }
                                    else
                                    {
                                        charList.Add(userGuess[0]); //Lägg till bokstaven
                                        y = charList.Count;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (secretWord.Equals(userGuess) == true)
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
