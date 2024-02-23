using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PasscodePuzzle : InteractableBase
{
    [SerializeField] private string passcodeAnswer;
    [SerializeField] private string playerInput;
    [SerializeField] private Transform puzzleSpawner;
    public bool isSolved;
    private bool isActive = false;
    [SerializeField] private InteractableObjText puzzleSolveText;
    [SerializeField] private InteractableObjText puzzleWrongTxt;

    public override void OnInteract()
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
    }

    private void DisplayPuzzleText()
    {
        TextManger.instance.ShowInteractableText(puzzleSpawner, $"Enter The Password: {new string('*', playerInput.Length)} ", 0.5f);
        TextManger.instance.ShowInteractableText(puzzleSpawner, playerInput, 0.4f);
    }
    public void Update()
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