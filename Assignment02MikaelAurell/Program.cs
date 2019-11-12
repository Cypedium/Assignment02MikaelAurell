using System;
using System.Text;
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
            int guessLeft = 1;
            List<char> charList = new List<char>();

            char[] gameStatusBegin = new char[secretWord.Length];
            char[] gameStatus = new char[secretWord.Length];
            
            StringBuilder wrongWordList = new StringBuilder();

            for (int i = 0; i < secretWord.Length; i++)
            {

                gameStatusBegin[i] = '_';
                gameStatus[i] = '_';

            }
           
            while (guessLeft < 21)
            {
                

                Console.Write("Your word contains of :");
                for (int i = 0; i < secretWord.Length; i++)
                {
                    gameStatusBegin[i] = gameStatus[i];
                    Console.Write($"{gameStatusBegin[i]}");
                }

                Console.Write("The list of wrong word is : ");
                for (int i = 0; i < wrongWordList.Length; i++)
                {
                    Console.Write($"{wrongWordList[i]}, ");
                }

                Console.Write($"You have {21 - guessLeft} guess left. Type a guess: ");
                string userGuess = Console.ReadLine();
                guessLeft++;
                string userGuessToLower = userGuess.ToLower();
                string userGuessToUpper = userGuess.ToUpper();
                           
                char userGuessChar = isUserGuessChar(userGuessToLower, secretWord);

                if (userGuess.Length == 1)
                    
                {   // Checks if char exists in gamestatus -----                                     
                    bool charExists = CheckifCharExists(gameStatus, userGuessToUpper, userGuessToLower, userGuessChar, guessLeft);
                    if (charExists)
                    {
                        Console.WriteLine($"You have alredy typed the letter {userGuessChar}, please try again.");
                        guessLeft--;
                    }
                    else
                    {   // Checks if char exists in secret word
                        bool isGuessCorrect = false;
                        for (int y = 0; y < secretWord.Length; y++)
                        {
                            if (secretWordArrayData[y] == userGuessChar)

                            {
                                gameStatus[y] = secretWordArray[y];
                                isGuessCorrect = true;
                            }
                        }//Adds the wrong word to a list
                        if (!isGuessCorrect)
                        {
                            if (wrongWordList.Length > 0)
                            {
                                for (int i = 0; i < wrongWordList.Length; i++)
                                {
                                    if (wrongWordList[i] != userGuessToLower[0] && isGuessCorrect==false)
                                    {
                                        {
                                         wrongWordList.Append(userGuessToLower[0]);
                                        }
                                    }
                                    else
                                    {
                                        Console.Write($"The char {userGuessChar} have you already tried to guess. Please try again:\n");
                                        guessLeft--;
                                    }
                                }                       
                            }
                            else
                            {   //This happends the first time
                                wrongWordList.Append(userGuessToLower[0]);
                            }
                        }
                        else
                        {
                            ;
                        }
                    }
                }
                else
                {   //If the user guess is a word and not a char.
                    if (secretWord.Equals(userGuessToLower))
                    {
                        Console.WriteLine("Congratulations you have typed the right answer!");
                    }
                }
            }
           
        }

        static char isUserGuessChar(string userGuessToLower, string secretWord)
        {
            if (userGuessToLower.Length == 1)
            {

                char guessIsChar = userGuessToLower[0];
                return guessIsChar;
            }
            else
                if (secretWord.Equals(userGuessToLower) == true)
                Console.WriteLine("Congratulations you have typed the right answer!");
            return '0';
        }
        static bool CheckifCharExists(char[] gameStatus, string userGuessToUpper, string userGuessToLower, char userGuessChar, int guessLeft)
            {
            bool charExists = false;
            for (int i = 0; i < gameStatus.Length; i++)
                {                                                      
                    if (gameStatus[i] == userGuessToLower[0])
                    {
                        
                        charExists = true;
                    return charExists;
                    }
                    else if (gameStatus[i] == userGuessToUpper[0])
                    {
                                                      
                        charExists=true;
                    return charExists;
                    }
                }
                return charExists;
            }
        
        static char[] SetGameStatus(char[] secretWordArrayData, char userGuessChar, string secretWord, char[] gameStatus, char[] secretWordArray)
        {
            bool isGuessCorrect = false;
            for (int y = 0; y < secretWord.Length; y++)
            {
                if (secretWordArrayData[y] == userGuessChar)
                {
                    gameStatus[y] = secretWordArray[y];
                    isGuessCorrect = true;
                        
                }                                     
            }
            return gameStatus;
        }
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

                

                
                   



                
                            
