using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PasscodePuzzle : InteractableBase
{
    [SerializeField] public InputField pass;
    [SerializeField] private string passcodeAnswer;
    [SerializeField] private string playerInput;
    [SerializeField] private Transform puzzleSpawner;
    public bool isSolved;
    private bool isActive = false;
    [SerializeField] private InteractableObjText puzzleSolveText;
    [SerializeField] private InteractableObjText puzzleWrongTxt;
    private bool solved = false;

    /*   public override void OnInteract()
       {
           base.OnInteract();

           playerInput = "";
           isActive = true;
           if (!isSolved)
           {
               DisplayPuzzleText();
           }
           else
           {
               TextManger.instance.ShowInteractableText(transform, puzzleSolveText);
           }
       }*/


    public void SubmitPass(string password)
    {
        if(password == passcodeAnswer)
        {
            isSolved = true;
        }
        else
        {
            isSolved = false;
        }
    }

    public override void OnInteract()
    {
        base.OnInteract();
        /* pass.onEndEdit.AddListener(SubmitPass);
         pass.gameObject.SetActive(true);*/

      //  playerInput = "";
        isActive = true;
        if (!isSolved)
        {
            DisplayPuzzleText();
        }
        else
        {
            TextManger.instance.ShowInteractableText(transform, puzzleSolveText);
        }
    }
    private void DisplayPuzzleText()
    {
        TextManger.instance.ShowInteractableText(puzzleSpawner, $"Enter The Password: {new string('*', playerInput.Length)} ", 0.5f);
        TextManger.instance.ShowInteractableText(puzzleSpawner, playerInput, 0.4f);
    }


   

    void Update()
    {
        // Check the order of key presses for T, Y, and V
        if (Input.GetKeyDown(KeyCode.T))
        {
            CheckSequence(KeyCode.T);
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            CheckSequence(KeyCode.Y);
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            CheckSequence(KeyCode.V);
        }
    }

    void CheckSequence(KeyCode pressedKey)
    {
        // Define the correct sequence of key presses (T, Y, V)
        KeyCode[] correctSequence = { KeyCode.T, KeyCode.Y, KeyCode.V };

        // Check if the pressed key is the next expected key in the sequence
        if (pressedKey == correctSequence[0])
        {
            // Remove the first element from the correct sequence
            System.Array.Copy(correctSequence, 1, correctSequence, 0, correctSequence.Length - 1);

            // Check if the correct sequence is now empty
            if (correctSequence.Length == 0)
            {
                // The correct order is achieved, set solved to true
                solved = true;
                Debug.Log("Correct order! Puzzle solved!");
            }
        }
        else
        {
            // Reset the sequence if a wrong key is pressed
            correctSequence = new KeyCode[] { KeyCode.T, KeyCode.Y, KeyCode.V };
        }
    }


    /*   public void Update()
       {
           if (isActive)
           {
               if (Input.GetKeyDown(KeyCode.Backspace) && playerInput.Length > 0)
               {
                   Debug.Log("deleted" + playerInput);
                   playerInput = playerInput.Substring(0, playerInput.Length - 1);
                   editDisplayedChar();
               }
               else if (Input.GetKeyDown(KeyCode.Escape))
               {
                   StopPuzzle();
               }
               else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
               {
                   Debug.Log("com" + playerInput);
                   Debug.Log("com" + passcodeAnswer);

                   if (playerInput == passcodeAnswer)
                   {
                       isSolved = true;
                       StopPuzzle();
                   }
                   else
                   {
                       StopPuzzle();
                       TextManger.instance.ShowInteractableText(transform, puzzleWrongTxt);
                       OnInteract();
                   }
               }
               else
               {
                   if (playerInput.Length < passcodeAnswer.Length)
                   {
                       Debug.Log("added" + playerInput);
                       playerInput += GetKeyPressed();
                       Debug.Log("added" + playerInput);

                       editDisplayedChar();
                   }
               }
               if (Input.GetKeyDown(KeyCode.Escape))
               {
                   StopPuzzle();
               }
               if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
               {
                   Debug.Log("com" + playerInput);
                   Debug.Log("com" + passcodeAnswer);

                   if (playerInput == passcodeAnswer)
                   {
                       isSolved = true;
                       StopPuzzle();
                   }
                   else
                   {
                       StopPuzzle();
                       TextManger.instance.ShowInteractableText(transform, puzzleWrongTxt);
                       OnInteract();
                   }
               }
           }
       }*/

    private void StopPuzzle()
    {
        isActive = false;
        playerInput = "";
        foreach (Transform child in transform)
        {
            if (child.gameObject.CompareTag("Text"))
            {
                Destroy(child.gameObject);
            }
        }
        if (isSolved)
        {
            TextManger.instance.ShowInteractableText(transform, puzzleSolveText);
            // BedroomRoom.instance.SetRequired(TXT.roomReq); for room implementation IMP
        }
    }

    private char GetKeyPressed()
    {
        foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(keyCode))
            {
                char pressedChar = keyCode.ToString()[0];
                if (char.IsLetterOrDigit(pressedChar))
                {
                    return pressedChar;
                }
            }
        }
        return '\0';
    }
    private void editDisplayedChar()
    {
        Debug.Log(playerInput);
        foreach (Transform child in transform)
        {
            if (child.gameObject.CompareTag("Text"))
            {
                Destroy(child.gameObject);
            }
        }
        DisplayPuzzleText();
    }
}