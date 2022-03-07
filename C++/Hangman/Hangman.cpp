/*********************************************************************
* Hangman Game (C++)
* ------------------
* This application is a simple Hangman game. The program will set up
* the game and collect a word from the dictionary text file. The user
* will have to guess letters until the whole word is completed. Once
* the word is completed before they run out of guesses, they win.
* 
* The game will not be playable without 'dictionary.txt' document in-
* side the Hangman directory. There also needs to be 100 words in the
* document as well. The number of words can be changed in the text
* file, but the 'maxWords' variable will have to be changed inside of
* GetWord() function, as well.
* 
* Words from 'dictionary.txt' can contain spaces, apostrophes, and
* hyphens--even capital letters. All other characters are
* unsupported.
* 
* Example from document:
* 
* apple
* peach tree
* pear
* two-fold
* three's company
* etc...
*********************************************************************/

#include <iostream>
#include <fstream>
#include <string>


//declare function GetWord
std::string GetWord()
{
    //declare variables
    std::fstream file;
    std::string nameFile = "dictionary.txt";
    int counter = 1;
    int maxWords = 100;
    int randNum;
    std::string word = "";
    std::string gameWord = "";

    //open word dictionary in read mode
    file.open(nameFile, std::ios::in);

    //if word dictionary is not found, exit the game
    if (!file.is_open()) {
        std::cout << "\n\n**Error 404: 'dictionary.txt' not found." << std::endl;
        return gameWord;
    }

    //if word dictionary is found, 
    if (file.is_open()) {
        //get a random number to pick the word from the file
        randNum = (rand() % maxWords + 1);

        //loop through each line of the file to get the word
        while (getline(file, word, '\n')) {
            if (counter == randNum) {
                gameWord = word;
            }
            counter++;
        }
    }
    //close file
    file.close();

    //return chosen word
    return gameWord;
}

//declare function HangmanDisplay
void HangmanDisplay(int userGuess) {
    //declare variables
    int guesses = userGuess;

    //switch through hangman status
    std::cout << std::endl << std::endl;
    switch (guesses) {
    case 0:
        std::cout << "_______ " << std::endl;
        std::cout << "|       " << std::endl;
        std::cout << "|       " << std::endl;
        std::cout << "|       " << std::endl;
        std::cout << "|       " << std::endl;
        std::cout << "|___    " << std::endl;
        break;
    case 1:
        std::cout << "_______ " << std::endl;
        std::cout << "|     O " << std::endl;
        std::cout << "|       " << std::endl;
        std::cout << "|       " << std::endl;
        std::cout << "|       " << std::endl;
        std::cout << "|___    " << std::endl;
        break;
    case 2:
        std::cout << "_______ " << std::endl;
        std::cout << "|     O " << std::endl;
        std::cout << "|     | " << std::endl;
        std::cout << "|       " << std::endl;
        std::cout << "|       " << std::endl;
        std::cout << "|___    " << std::endl;
        break;
    case 3:
        std::cout << "_______ " << std::endl;
        std::cout << "|     O " << std::endl;
        std::cout << "|     | " << std::endl;
        std::cout << "|      \\" << std::endl;
        std::cout << "|       " << std::endl;
        std::cout << "|___    " << std::endl;
        break;
    case 4:
        std::cout << "_______ " << std::endl;
        std::cout << "|     O " << std::endl;
        std::cout << "|     | " << std::endl;
        std::cout << "|    / \\" << std::endl;
        std::cout << "|       " << std::endl;
        std::cout << "|___    " << std::endl;
        break;
    case 5:
        std::cout << "_______ " << std::endl;
        std::cout << "|     O " << std::endl;
        std::cout << "|     |\\" << std::endl;
        std::cout << "|    / \\" << std::endl;
        std::cout << "|       " << std::endl;
        std::cout << "|___    " << std::endl;
        break;
    case 6:
        std::cout << "_______ " << std::endl;
        std::cout << "|     O " << std::endl;
        std::cout << "|    /|\\" << std::endl;
        std::cout << "|    / \\" << std::endl;
        std::cout << "|       " << std::endl;
        std::cout << "|___    " << std::endl;
        break;
    default:
        std::cout << "\n\n**Error. Something went wrong." << std::endl;
        break;
    }
}

//declare function WordDisplay
int WordDisplay(std::string word, char ltrBank[]) {
    //declare variables
    std::string displayWord = word;
    char blanks = '_';
    int size = 26;
    int disWholeWord = 0;
    bool letterFound = false;

    //display the word
    std::cout << std::endl;
    for (int x = 0; x < displayWord.length(); x++) {
        for (int i = 0; i < size; i++) {
            //check if any letters in the letter bank array match with the chosen word
            if (isalpha(ltrBank[i])) {
                if (ltrBank[i] == displayWord[x] || char(toupper(ltrBank[i])) == displayWord[x]) {
                    letterFound = true;
                }
            }
        }

        //once a letter has been found, display the letter of the word,
        //  else display all other characters (spaces, apostrophes, etc.) or blanks.
        if (letterFound) {
            std::cout << displayWord[x];
            letterFound = false;
            disWholeWord++;
        }
        else {
            if (displayWord[x] == '\'') {
                std::cout << displayWord[x];
                disWholeWord++;
            }
            if (displayWord[x] == '-') {
                std::cout << displayWord[x];
                disWholeWord++;
            }
            if (displayWord[x] == ' ') {
                std::cout << displayWord[x];
                disWholeWord++;
            }
            if (isalpha(displayWord[x])) {
                std::cout << blanks;
            }
        }
    }

    //return display whole word value
    return disWholeWord;
}

//decare function CheckGuess
bool CheckGuess(std::string word, char letter) {
    //declare variables
    std::string wrd = word;
    char ltr = letter;
    bool guessRight = false;

    //step through the word to check if guess matches a letter
    for (int i = 0; i < wrd.length(); i++) {
        if (ltr == wrd[i] || char(toupper(ltr)) == wrd[i]) {
            guessRight = true;
            return guessRight;
        }
    }

    //if there is no matching letter, return the false boolean
    return guessRight;
}

//declare function ValidateInput
bool ValidateInput(std::string input) {
    //declare variables
    std::string usrInput = input;

    if (isalpha(usrInput[0])) {
        return true;
    }
    else {
        std::cout << "\n\n**Invalid input. Please use a single letter." << std::endl;
    }

    //return false by default
    return false;
}

//declare function GameStart
void GameStart()
{
    //declare variables
    std::string solveWord;
    std::string input;
    std::string playAgain;
    int guesses = 0;
    int wrdCompleted = 0;
    int bankIndex = 0;
    int bankSize = 26;
    int wins = 0;
    int losses = 0;
    char userLtr;
    char ltrBank[26] = {};
    bool sameLetter = false;
    bool inputValidated = false;

    //loop until user decides to quit playing
    do {
        //reset game back to default so the user can continue playing
        guesses = 0;
        wrdCompleted = 0;
        bankIndex = 0;
        sameLetter = false;
        inputValidated = false;

        //reset array ltrBank
        for (int y = 0; y < bankSize; y++) {
            ltrBank[y] = ' ';
        }

        //call function GetWord and assign the new word to solveWord to be solved
        solveWord = GetWord();

        //check if solveWord is blank; if so, end the game with an error.
        if (solveWord == "") {
            std::cout << "\n\n**Game cannot start. Please refer to the README.txt, check your installation and try again." << std::endl;
            return;
        }

        //display current status of hangman and display length of word
        do
        {
            //segment the screen sections
            std::cout << "-----------------------------------------------" << std::endl;

            //call function HangmanDisplay, supplying it with current guesses used.
            HangmanDisplay(guesses);

            //call function to display word and assign return value to wrdCompleted
            wrdCompleted = WordDisplay(solveWord, ltrBank);

            //if word is not completed, continue playing, else skip to the end
            if (wrdCompleted != solveWord.length())
            {
                //loop to get correct input from user
                do {
                    //ask user for input
                    std::cout << "\n\nWhat letter do you guess? ";
                    std::getline(std::cin, input);

                    //call function ValidateInput and send the user input to see if it is correct or not.
                    inputValidated = ValidateInput(input);
                } while (!inputValidated);

                //after validation, assign input to userLtr
                userLtr = input[0];

                //call function to check for correct letter(s)
                if (CheckGuess(solveWord, userLtr) == true) {
                    //reset sameLetter to false
                    sameLetter = false;

                    //check bank to see if user entered the same letter as what is in the bank.
                    //if so, then flag sameLetter to true to prevent adding an additional letter.
                    for (int e = 0; e < bankSize; e++) {
                        if (userLtr == ltrBank[e]) {
                            std::cout << "\nYou already used that same letter!" << std::endl;
                            sameLetter = true;
                        }
                    }

                    //if user did not use same letter, then add it to the bank.
                    if (!sameLetter) {
                        std::cout << "\nYes. There is at least one '" << userLtr << "' in the word." << std::endl;
                        ltrBank[bankIndex] = userLtr;
                        bankIndex++;
                    }
                }
                else {
                    //reset same letter to false
                    sameLetter = false;
                    for (int a = 0; a < bankSize; a++) {
                        if (userLtr == ltrBank[a]) {
                            std::cout << "\nYou already used that same letter!" << std::endl;
                            sameLetter = true;
                        }
                    }

                    if (!sameLetter) {
                        std::cout << "\nNo. Guess again." << std::endl;
                        ltrBank[bankIndex] = userLtr;
                        bankIndex++;
                        guesses++;
                    }
                }
            }
        } while (guesses < 6 && wrdCompleted < solveWord.length());

        //check win/loss conditions
        if (guesses >= 6) {
            //if player lost due to guesses, finish game up
            HangmanDisplay(guesses);
            std::cout << "\nSorry. You lose.\nThe word was '" << solveWord << "'." << std::endl;
            losses++;
        }

        if (wrdCompleted >= solveWord.length()) {
            HangmanDisplay(guesses);
            std::cout << std::endl << solveWord << std::endl;
            std::cout << "\nYou won!" << std::endl;
            wins++;
        }

        //display game score
        std::cout << "Total wins: " << wins << std::endl;
        std::cout << "Total losses: " << losses << std::endl;

        //ask if the user wants to play again
        do {
            std::cout << "\n\nWould you like to play again? Y/N: ";
            std::cin >> playAgain;
            std::cin.ignore();
            playAgain = char(toupper(playAgain[0]));

            //check if input is valid
            if (!isalpha(playAgain[0])) {
                std::cout << "\n\n**Invalid input. Please use Y/N or y/n." << std::endl;
            }
        } while (playAgain[0] != 'Y' && playAgain[0] != 'N');
    } while (playAgain[0] != 'N');
}

int main()
{
    //declare variables
    std::string input;
    char choice;
    srand(time(0));

    //main program
    std::cout << "Hangman Game" << std::endl;
    std::cout << "============" << std::endl;
    std::cout << "Would you like to play? Y/N: ";

    //loop until user enters the correct letter
    do {
        //get user input
        std::getline(std::cin, input);
        choice = char(toupper(input[0]));

        //switch through choice
        switch (choice) {
        case 'Y': GameStart(); break;
        case 'N': break;
        default: std::cout << "\n\n**Invalid input.\nPlease use Y/N or y/n: "; break;
        }
    } while (choice != 'Y' && choice != 'N');

    //end program sequence
        std::cout << "\n\nThank you for using this program. Press Enter to exit." << std::endl;
        std::cin.get();
}
