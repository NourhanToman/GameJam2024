using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasscodePuzzle : MonoBehaviour
{
    [SerializeField] string passcodeAnswer;
    [SerializeField] string playerInput;
    public bool isSolved;
    private bool isActive;
    [SerializeField] InteractableObjText puzzleTxt;

    public void StartPuzzle()
    {

    }
    public void Update()
    {
        if (isActive)
        {
            if (Input.anyKeyDown)
            {
                //if (Input.GetKeyDown())
                //{

                //}
            }
        }
    }
    char GetKeyPressed()
    {
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
 
                return keyCode.ToString()[0];
            }
        }

        // If no valid key is found, return an empty char
        return '\0';
    }
}
