// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Runtime.InteropServices;
using UnityEngine;

public class Computer : MonoBehaviour
{
    // Game Config Data
    const string menuHint = "You may type menu at any time.";
    string[] level1Passwords = { "Masculine", "Terraform", "Bouncing", "Cathedral", "Electrocute" };
    string[] level2Passwords = { "Cyborg", "Extraterrestrial", "Aircraft", "Moonshine", "Radiation" };
    string[] level3Passwords = { "Conjuration", "Imagination", "Deformation", "Emancipation", "Vacation" };
    // Game State \\ 
    int level;

    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        print(level1Passwords[1]);
        ShowMainMenu();
    }
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        // string greeting = "Hello: Anonymous";
        Terminal.WriteLine("Welcome to the Mainframe, currently there is '1' game loaded with '3' level(s)");
        Terminal.WriteLine("Press 1, 2, or 3, to play the corresponding level of the loaded game.");
        Terminal.WriteLine("Input your decision here:");
    }
    void OnUserInput(string input)
    {
        if (input == "menu") // Straight to Menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }


    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Do you need a Bondulance?");
        }
        else
        {
            Terminal.WriteLine("Invalid Entry");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("Enter your password: " + password.Anagram());
    }

    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid selection has been made");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Correct!");
                Terminal.WriteLine(@"
///
   / \ / /
  / \ / /
 / \ / /
/ \ / /
;;;
ASCII
"
                );

                break;
            case 2:
                Terminal.WriteLine("Correct!");
                Terminal.WriteLine(@"
///
/// 
/// 
   "
                );
                break;
            case 3:
                Terminal.WriteLine("Correct!!");
                Terminal.WriteLine(@"This is where we'd put ASCII art if our graphic designer hadn't spilled coffee on his laptop");
                break;
        }
    }
}
