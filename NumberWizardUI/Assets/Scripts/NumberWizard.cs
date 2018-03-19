using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour
{

    int maximum;
    int minimum;
    int guess;

    public Text GuessText;

    const int maximumTries = 10;
    int triesRemaining = maximumTries;

    // Use this for initialization
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        maximum = 1000;
        minimum = 1;
        
        NextGuess(true);

    }

    public void GuessHigher()
    {
        minimum = guess;
        NextGuess();
    }

    public void GuessLower()
    {
        maximum = guess;
        NextGuess();
    }

    void NextGuess(bool firstCall = false)
    {
        //guess = (maximum + minimum) / 2; Algoritmo antigo, utilizada o método da bisseção
        int bisectrice = (maximum + minimum) / 2;
        if (firstCall)
        {
            guess = Random.Range(minimum, ++maximum);
        }
        else
        {
            guess = Random.Range(bisectrice - 10, bisectrice + 11);
        }
        GuessText.text = "Is your number higher, lower or equal to " + guess.ToString() + '?';
        if (!firstCall)
        {
            triesRemaining--;
            if (triesRemaining <= 0)
            {
                SceneManager.LoadScene("Lose");
            }
        }
    }
}
