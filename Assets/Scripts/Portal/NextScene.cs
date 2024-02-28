using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NextScene : MonoBehaviour
{
    [SerializeField] GameStates nextState;

    private void Start()
    {
        if(GameManager.Instance.state == GameStates.Freedom || GameManager.Instance.state == GameStates.Peace || GameManager.Instance.state == GameStates.Justice)
            AudioManager.instance.Play(AudioType.SFX, "Portal");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log(nextState);
            GameManager.Instance.UpdateGameState(nextState);
        }
    }
}
