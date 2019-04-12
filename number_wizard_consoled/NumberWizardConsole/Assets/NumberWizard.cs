using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    int max = 1000;
    int min = 1;
    int guess = 500;
    // Start is called before the first frame update
    void Start()
    {
      StartGame();
    }

    void StartGame()
    {
      max = 1000;
      min = 1;
      guess = 500;
      Debug.Log("Welcome to Number Wizard");
      Debug.Log("Think of a number between " + min + " and " + max);
      Debug.Log("Tell me if your number is higher or lower than 500");
      Debug.Log("Push Up = higher, Push down = lower, Push Enter = correct");
      max = max + 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
          min = guess;
          NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) 
        {
          max = guess;
          NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return)) 
        {
          Debug.Log("We got it! Your number was " + guess);
          StartGame();
        }
    }

    void NextGuess() 
    {
      guess = (min + max) / 2;
      Debug.Log("Is your Number " + guess + "?");
    }
}
