using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();

    }

    void ShowMainMenu() 
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to the Mainframe, currently there is '1' game loaded with '3' level(s)");
        Terminal.WriteLine("Press 1, 2, or 3, to play the corresponding level of the loaded game.");
        Terminal.WriteLine("Input your decision here:");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
