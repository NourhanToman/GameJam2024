using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects: MonoBehaviour
{
    [SerializeField] private CamShake shake;
    [SerializeField] private GameObject leftchain;
    [SerializeField] private GameObject rightchain;
    [SerializeField] private CustomThirdPersonController speed;
    void Start()
    {
        if(GameManager.Instance.playerState == PlayerState.NoCamShake)
        {
            shake.enabled = false;
        }else if (GameManager.Instance.playerState == PlayerState.NoHandCuf)
        {
            shake.enabled=false;
            leftchain.gameObject.SetActive(false);
            rightchain.gameObject.SetActive(false);
            speed.MoveSpeed = 4;
            speed.SprintSpeed = 4;
        }
    }


}
