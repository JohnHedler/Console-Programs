/**********************************************************************
* Cypher Program
* ---------------------------------------------------------------------
* User enters data into the application and it converts it over to
* ASCII numbers. This data is saved to a text file, and the user is
* able to receive data from the text file.
* 
* The data is read from the file, and converted back into text to
* display to the user.
**********************************************************************/
#include <iostream>
#include <fstream>
#include <string>

//declare functions
char optionSelect() {
    //declare variables
    char option;

    //do loop until user selects appropriate choice
    do {
        std::cout << "1) Write to file" << std::endl;
        std::cout << "2) Read from file" << std::endl;
        std::cout << "3) Exit Program" << std::endl;
        std::cout << std::endl << "Choose an option: ";
        std::cin >> option;

        //switch through choice to determine option
        switch (option) {
        case '1':std::cout << "Write..." << std::endl; break;
        case '2': std::cout << "Read..." << std::endl; break;
        case '3':break;
        default:std::cout << "Invalid input. Please try again." << std::endl; break;
        }
    } while (option != '1' && option != '2' && option != '3');

    return option;
}

void writeFile() {
    //declare variables
    std::fstream file;
    std::string userLine;
    std::string fileName;

    //ask user for file name to be created
    std::cout << "Please enter a file name to be created: " << std::endl;
    std::cin >> fileName;
    fileName += ".txt";

    //open file in read mode
    //file.open("textfile.txt", std::ios::app);
    file.open(fileName, std::ios::app);

    //ask user to enter data
    std::cout << "Please enter text:" << std::endl;
    std::cin.ignore(10000, '\n');
    std::getline(std::cin, userLine);

    //write data to file
    if (file.is_open()) {
        //convert data to ASCII table integers
        for (int i = 0; i < userLine.size(); i++) {
            int convertLtr = userLine[i];
            file << convertLtr << " ";
        }
        file << "\n";
    }

    //close file
    file.close();

    //inform user file has been successfully saved.
    std::cout << fileName << " has been successfully created and saved." << std::endl;
}

void readFile() {
    //declare variables
    std::fstream file;
    std::string textLine;
    std::string textLine2;
    std::string fileName;
    int textWord;

    //ask user for file name to be created
    std::cout << "Please enter a file name to be read: " << std::endl;
    std::cin >> fileName;
    fileName += ".txt";

    //open file in read mode
    file.open(fileName, std::ios::in);

    //read lines from text file and convert to characters.
    if (!file.is_open()) {
        std::cout << "\n\n**Error 404: File '" << fileName << "' not found." << std::endl;
    }
    if (file.is_open()) {
        while (getline(file, textLine, '\n')) {
            for (int x = 0; x < textLine.size(); x++) {
                if (textLine[x] != ' ') {
                    if (isdigit(textLine[x])) {
                        textLine2 += textLine[x];
                    }
                    else {
                        std::cout << "\n\n**Error reading file. It may be damaged or corrupted." << std::endl;
                        return;
                    }
                }
                if (textLine[x] == ' ') {
                    textWord = std::stoi(textLine2);
                    std::cout << (char)textWord;
                    textLine2 = "";
                }
            };
            std::cout << std::endl;
        };
        std::cout << "\n\nEnd of file." << std::endl;
    };

    //close file
    file.close();

    std::cin.get();
};

int main()
{
    //declare variables
    char option;

    //main program
    std::cout << "Cypher Program" << std::endl;
    std::cout << "==============" << std::endl;

    //call function for user selection
    option = optionSelect();

    //switch through returned choice in variable 'option'
    switch (option) {
    case '1':writeFile(); break;
    case '2':readFile(); break;
    case '3':break;
    default: std::cout << "\n\n**Error in detecting selection. Please restart program and try again." << std::endl;; break;
    }

    //end program sequence
    std::cout << std::endl << "Thank you for using this program. Press Enter to exit." << std::endl;
    std::cin.get();
}
