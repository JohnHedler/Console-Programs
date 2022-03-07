/*********************************************************************
* Hangman Game (C#)
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