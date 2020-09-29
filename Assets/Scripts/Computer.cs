using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Computer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Welcome, User#101");
    }

    void ShowMainMenu(string greeting) 
    {
        Terminal.ClearScreen();
        // string greeting = "Hello: Anonymous";
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Welcome to the Mainframe, currently there is '1' game loaded with '3' level(s)");
        Terminal.WriteLine("Press 1, 2, or 3, to play the corresponding level of the loaded game.");
        Terminal.WriteLine("Input your decision here:");
    }

    void OnUserInput(string input)
    {
        // Terminal.WriteLine("Message Received: " + input);
        //print(input == "1"); // Boolean statement, if input==1 then returns True, otherwise, false
        if(input=="menu")
        {
            ShowMainMenu("You have returned to the menu");
        } else if(input == "1")
        {
            print(input == "1");
                Terminal.WriteLine("You have selected level 1");
        } else
        {
            Terminal.WriteLine("Invalid Entry");

        }
    }


    // Update is called once per frame
   // void Update()
  //  {
        
   // }
}
