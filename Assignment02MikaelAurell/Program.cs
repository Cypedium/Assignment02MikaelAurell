using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

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
            bool newGame = true;

            while (newGame)
            {
                newGame = false;
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

                while (guessLeft < 11 && !(CheckGamestatusForWinner(gameStatus, guessLeft))) // kan använda secretWordArray.SequenceEqual() för att jämföra arrayer men då måste using.Linq användas
                {
                    try
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

                        Console.Write($"You have {11 - guessLeft} guess left. Type a guess: ");
                        string userGuess = Console.ReadLine();

                        CheckUserGuessForExceptions(userGuess, secretWord);

                        string userGuessToLower = userGuess.ToLower();
                        string userGuessToUpper = userGuess.ToUpper();
                        guessLeft++;

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

                                        bool charInWrongWordListExists = false;
                                        for (int i = 0; i < wrongWordList.Length; i++)
                                        {
                                            if (wrongWordList[i] == userGuessChar)
                                            {
                                                {
                                                    Console.Write($"The char {userGuessChar} have you already tried to guess. Please try again:\n");
                                                    guessLeft--;
                                                    i = wrongWordList.Length;
                                                    charInWrongWordListExists = true;
                                                    break;
                                                }
                                            }
                                        }
                                        if (!charInWrongWordListExists)
                                        {
                                            wrongWordList.Append(userGuessChar);
                                            charInWrongWordListExists = false;
                                        }
                                    }
                                    else
                                    {   //This happends the first time
                                        wrongWordList.Append(userGuessChar);
                                    }
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
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("Nothing was given.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("No number excepted");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("The word can't be more than 50 chars");
                    }
                }//Game while loop exits
                if (guessLeft == 0 && !CheckGamestatusForWinner(gameStatus, guessLeft))
                {
                    Console.WriteLine($"I'm sorry dude, you loose! Please try again.");
                }
                else
                {
                    Console.WriteLine("Congratulations you have typed the right answer!");

                }
                guessLeft = 21;
                wrongWordList.Clear();
                newGame = true;
            }
        }        
                      
        public static void CheckUserGuessForExceptions(string userGuess, string secretWord)
        {
            char charGuess = isUserGuessChar(userGuess.ToLower(), secretWord);
            List<char> numbers = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                
            if (userGuess.Length < 50)
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (charGuess==numbers[i])
                    {
                        throw new FormatException();
                    }
                }
            }
                                                          
            else if (userGuess.Length > 50)
            {
                throw new OverflowException();
            }

            else if (userGuess == "")
            {
                throw new ArgumentNullException();
            }
        }

        static bool CheckGamestatusForWinner(char[] gameStatus, int guessLeft)
        {
            
            for (int i = 0; i < gameStatus.Length; i++)
            {
                if (gameStatus[i] == '_')
                {
                    return false;
                }
                
            }
            return true;
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
            dataString[3] = "Carl";
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

                

                
                   



                
                            
