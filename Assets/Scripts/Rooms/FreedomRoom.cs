using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreedomRoom : MonoBehaviour
{
    private void Start()
    {
        if(GameManager.Instance.FreedomNoOfVisits <= 1)
        {
            StartCoroutine(PlayerFirstVerse());
        }
        if (GameManager.Instance.FreedomNoOfVisits >1)
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
}

public enum PlayerState
{
    Dead,
    CamShake,
    HandCuf,
    NoCamShake,
    NoHandCuf
}
