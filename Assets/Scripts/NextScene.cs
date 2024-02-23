using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NextScene : MonoBehaviour
{
    [SerializeField] GameStates nextState;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log(nextState);
            GameManager.Instance.UpdateGameState(nextState);
        }
    }
}
