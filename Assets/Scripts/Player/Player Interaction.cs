using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float _interactionRange = 3f;
    //[SerializeField] private GameObject pre;

    public void Interact()
    {
        Collider[] _colliderArray = Physics.OverlapSphere(transform.position, _interactionRange);
        foreach (Collider collider in _colliderArray)
        {
            if(collider.TryGetComponent(out Interactable interactable))
            {
                //_showDialogue?.Invoke();

                interactable.Interact();
            }
        }
    }

    public IInteractable GetInteractableObject()
    {
        Collider[] _colliderArray = Physics.OverlapSphere(transform.position, _interactionRange);
        foreach (Collider collider in _colliderArray)
        {
            if (collider.TryGetComponent(out IInteractable interactable))
            {
                return interactable;
            }
        }
        return null;
    }
}


