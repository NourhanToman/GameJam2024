using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreedomRoom : MonoBehaviour
{
    
    private bool isSolved = false;
    public GameObject portal;

    private void Start()
    {
        portal.SetActive(false);
        if(GameManager.Instance.attempts == RoomsAttempts.freedomONE)
        {
            StartCoroutine(PlayerFirstVerse());
        }
        if (GameManager.Instance.attempts == RoomsAttempts.freedomTWO)
        {
            StartCoroutine(PlayerSecondVerse());
        }
    }

    private IEnumerator PlayerSecondVerse()
    {
        yield return new WaitForSeconds(10f);
        TextManger.instance.PlayMessage(6);
        
    }

    private IEnumerator PlayerFirstVerse()
    {
        yield return new WaitForSeconds(5f);
        TextManger.instance.PlayMessage(5);
    }


    public void SetRequired(roomsRequirments room)
    {
        if (isSolved)
        {
            switch (room)
            {
                case roomsRequirments.box:
                    isSolved = true;
                    break;
                case roomsRequirments.FreedomPortal:
                    portal.SetActive (true);
                    //remove chains
                    break;
            }
        }
    }
}

public enum PlayerState
{
    Dead,
    CamShake,
    HandCuf,
    NoCamShake,
    NoHandCuf
}
