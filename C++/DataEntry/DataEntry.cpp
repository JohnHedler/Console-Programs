/*********************************************************************
* Data Entry Program
* This program will take input from the user and save it to a text
* file where it will be grouped by lines to allow reading of the data
* to be returned to the program upon opening the text file. It will
* allow manipulation of the data in the text file for future use.
* 
* The program can update data and will save it to a buffer file. Once
* it is done, it will delete the old data and replace the original
* file so that it can be read at the next time of program execution.
*********************************************************************/
#include <iostream>
#include <fstream>
#include <string>

//declare functions
char chooseOption() {
    //declare variables
    char option;

    do {
        //display to user options and ask user to select a choice
        std::cout << "1) Enter data" << std::endl;
        std::cout << "2) Read data" << std::endl;
        std::cout << "3) Update data" << std::endl;
        std::cout << "4) Exit program" << std::endl;
        std::cout << std::endl << "Choose an option: ";
        std::cin >> option;

        //switch through choice to determine option
        switch (option) {
        case '1': std::cout << "Enter data..." << std::endl; break;
        case '2': std::cout << "Read data..." << std::endl; break;
        case '3': std::cout << "Update data..." << std::endl; break;
        case '4': break;
        default: std::cout << "\n\n**Invalid input. Please try again." << std::endl; break;
        }
    } while (option != '1' && option != '2' && option != '3' && option != '4');

    return option;
}

void writeData() {
    //declare variables
    std::fstream file;
    std::string name;
    std::string age;
    std::string job;
    std::string pay;

    //open file in write mode
    file.open("userdata.txt", std::ios::app);

    //ask user to enter data
    std::cout << "Please enter data for a new entry:" << std::endl;
    std::cout << "Name: ";
    std::cin.ignore(10000, '\n');
    std::getline(std::cin, name);
    std::cout << "Age: ";
    std::getline(std::cin, age);
    std::cout << "Job: ";
    std::getline(std::cin, job);
    std::cout << "Pay: ";
    std::getline(std::cin, pay);

    //check if file is open, then enter information into a new line
    if (file.is_open()) {
        file << name << ":" << age << ":" << job << ":" << pay << ":" << "\n";
    }

    //close file
    file.close();
}

void readData() {
    //declare variables
    std::fstream file;
    std::string textLine;
    std::string name;
    std::string age;
    std::string job;
    std::string pay;
    int counter = 1;
    int entryLine = 1;
    
    //open file in read mode
    file.open("userdata.txt", std::ios::in);

    //read lines from file and display to user
    if (!file.is_open()) {
        std::cout << "\n\n**Error 404: File not found." << std::endl;
        return;
    }
    if (file.is_open()) {
        //loop through each line of the file to get data
        while (getline(file, textLine, '\n')) {
            //reset variables for each line
            name = "";
            age = "";
            job = "";
            pay = "";
            counter = 1;

            //display entry number
            std::cout << "\nEntry #: " << entryLine << std::endl;
            std::cout << "------------------------" << std::endl;

            for (int i = 0; i < textLine.size(); i++) {
                if (textLine[i] != ':') {
                    //switch through counter to determine where data is stored
                    switch (counter) {
                    case 1: name += textLine[i]; break;
                    case 2: age += textLine[i]; break;
                    case 3: job += textLine[i]; break;
                    case 4: pay += textLine[i]; break;
                    default: std::cout << "\n\n**Error reading file. It may be damaged or corrupted."; break;
                    }
                }
                if (textLine[i] == ':') {
                    //switch through counter to determine which data will be displayed
                    switch (counter) {
                    case 1: std::cout << "Name: " << name << std::endl; break;
                    case 2: std::cout << "Age: " << age << std::endl; break;
                    case 3: std::cout << "Job: " << job << std::endl; break;
                    case 4: std::cout << "Pay: $" << pay << std::endl; break;
                    default: std::cout << "\n\n**Error reading file. It may be damaged or corrupted."; break;
                    }
                    //increment counter
                    counter++;
                };
            };

            //increment entryLine and add spacing between entries.
            entryLine++;
            std::cout << std::endl;
        };
        std::cout << "\n\nEnd of file." << std::endl;
    };

    //close file
    file.close();
}

void updateData() {
    //declare variables
    std::fstream file;
    std::fstream newFile;
    std::string textLine;
    std::string name;
    std::string age;
    std::string job;
    std::string pay;
    int counter = 1;
    int entryNum;
    int entryUpdated = 0;
    bool renameFile = false;

    //open files in read and write mode, respectively
    file.open("userdata.txt", std::ios::in);
    newFile.open("userdata2.txt", std::ios::out);

    //ask user which entry to upate
    std::cout << "Which entry do you want to update? #: ";
    std::cin >> entryNum;

    while (!file.eof()) {
        //obtain line of data from text file
        getline(file, textLine, '\n');

        //if the line is not the same as the requested entry, just write that data to new file
        if (entryNum != counter) {
            newFile << textLine << '\n';
        }

        //if line IS the same as requested entry, ask for new information to be input.
        //then, update variable and write to new file.
        if (entryNum == counter) {
            std::cout << "Please enter new information." << std::endl;
            std::cout << "Name: ";
            std::cin.ignore(10000, '\n');
            std::getline(std::cin, name);
            std::cout << "Age: ";
            std::getline(std::cin, age);
            std::cout << "Job: ";
            std::getline(std::cin, job);
            std::cout << "Pay: ";
            std::getline(std::cin, pay);

            textLine = name + ":" + age + ":" + job + ":" + pay + ":";
            newFile << textLine << '\n';
            entryUpdated = 1;
        }
        counter++;
    }

    //inform user if no entry exists.
    if (file.eof() && entryUpdated == 0) {
        std::cout << "\n\n**No entry for #" << entryNum << ". Please check data and try again." << std::endl;
    }

    //inform user if entry exists and is updated, tell them the new file.
    if (file.eof() && entryUpdated == 1) {
        std::cout << "\nData updated in file userdata.txt." << std::endl;
    }

    //close files
    file.close();
    newFile.close();

    //delete old data and rename the placeholder file as the original file
    remove("userdata.txt");
    renameFile = rename("userdata2.txt", "userdata.txt");
    if (renameFile) {
        std::cout << "\n\n**Error: File could not be renamed." << std::endl;
    }
}

int main()
{
    //declare variables
    char option;

    //main program
    std::cout << "Data Entry Program" << std::endl;
    std::cout << "==================" << std::endl;

    //call function to get user choice
    option = chooseOption();

    //switch through chosen option
    switch (option) {
    case '1':writeData(); break;
    case '2':readData(); break;
    case '3':updateData(); break;
    case '4':break;
    default: std::cout << "\n\n**Invalid option. Please restart program and try again." << std::endl; break;
    }

    //end program sequence
    std::cout << "\n\nThank you for using this program." << std::endl;
    std::cout << "\nPlease press Enter to end program." << std::endl;
    std::cin.get();
}
