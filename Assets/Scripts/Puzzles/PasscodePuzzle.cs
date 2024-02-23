using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PasscodePuzzle : InteractableBase
{
    [SerializeField] string passcodeAnswer;
    [SerializeField] string playerInput;
    [SerializeField] Transform puzzleSpawner;
    public bool isSolved;
    private bool isActive = false;
    [SerializeField] InteractableObjText puzzleSolveText;

    public override void OnInteract()
    {
        base.OnInteract();

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
        TextManger.instance.ShowInteractableText(puzzleSpawner, $"Enter The Password:+{new string('*', playerInput.Length)} ", 0.5f);
        TextManger.instance.ShowInteractableText(puzzleSpawner, playerInput, 0.3f);
    }
    public void Update()
    {
        if (isActive)
        {
            if(Input.GetKeyDown(KeyCode.Backspace) && playerInput.Length > 0) 
            {
                Debug.Log("deleted" + playerInput);
                playerInput = playerInput.Substring(0, playerInput.Length - 1);
                editDisplayedChar();
            }

            if (playerInput.Length < passcodeAnswer.Length)
            {
                Debug.Log("added" + playerInput);
                playerInput += GetKeyPressed();
                Debug.Log("added" + playerInput);

                editDisplayedChar();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                StopPuzzle();
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Debug.Log("com" + playerInput);
                Debug.Log("com" + passcodeAnswer);

                if (playerInput == passcodeAnswer){
                    isSolved = true;
                    StopPuzzle();
                }
            }
        }
    }
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
        if(isSolved)
        {
            TextManger.instance.ShowInteractableText(transform, puzzleSolveText);
           // BedroomRoom.instance.SetRequired(TXT.roomReq); for room implementation IMP
        }
    }
    char GetKeyPressed()
    {
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
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
        foreach(Transform child in transform)
        {
            if (child.gameObject.CompareTag("Text"))
            {
                Destroy(child.gameObject);
            }
        }
        DisplayPuzzleText();
    }
}
