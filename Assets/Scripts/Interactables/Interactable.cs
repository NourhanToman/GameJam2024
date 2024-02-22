using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour, IInteractable
{
    [SerializeField] private string _text;
    public UnityEvent _showDialogue;

    public bool MultipleUse => throw new System.NotImplementedException();

    public bool IsInteractable => throw new System.NotImplementedException();

    public string TooltipMessage => throw new System.NotImplementedException();


    public void Interact()
    {
        //this.GetComponent<UnityEventListener>().EventRaised();
        _showDialogue?.Invoke();
        Debug.Log("Interactable");
    }

    public void OnInteract(/*Transform interactorTransform*/)
    {
        Interact();
    }
}
