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
            TextManger.instance.ShowInteractableText(puzzleSpawner, "Enter The Password: ", 0.5f);
            TextManger.instance.ShowInteractableText(puzzleSpawner, playerInput, 0.3f);
        }
        else
        {
            TextManger.instance.ShowInteractableText(transform, puzzleSolveText);
        }
    }
    public void Update()
    {
        if (isActive)
        {
            if (playerInput.Length < passcodeAnswer.Length)
            {
                playerInput += GetKeyPressed();
                editDisplayedChar();
            }
            if(Input.GetKeyDown(KeyCode.Backspace)) 
            {
                playerInput.Remove(playerInput.Length - 1);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                StopPuzzle();
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if(playerInput == passcodeAnswer){
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
           // Bedroom.instance.SetRequired(TXT.roomReq); for room implementation IMP
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
        TextManger.instance.ShowInteractableText(puzzleSpawner, "Enter The Password: ", 0.5f);
        TextManger.instance.ShowInteractableText(puzzleSpawner, playerInput, 0.3f);
    }
}
