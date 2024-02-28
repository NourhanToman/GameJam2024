using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreedomRoom : MonoBehaviour
{
    
    private bool isSolved = false;
   // AudioClip clip;
  //  private AudioSource audioSource;

    private void Start()
    {
        AudioManager.instance.Play(AudioType.Music, "Freedom");
        GameManager.Instance.Player = GameObject.FindWithTag("Player");
        GameManager.Instance.playerInputs = GameManager.Instance.Player.GetComponent<StarterAssetsInputs>();
        GameManager.Instance.cameraLock = GameManager.Instance.Player.GetComponent<CustomThirdPersonController>();
        //clip= AudioManager.instance.GetClip(AudioType.SFX, "Water");
        // AudioManager.instance.LoopPlay(AudioType.SFX, "Water");
        if (GameManager.Instance.attempts == RoomsAttempts.ONE)
        {
            StartCoroutine(PlayerFirstVerse());
        }
        if (GameManager.Instance.attempts == RoomsAttempts.TWO)
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
                    break;
            }
        }
    }
}


