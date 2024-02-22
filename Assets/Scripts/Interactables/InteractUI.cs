using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractUI : MonoBehaviour
{
    [SerializeField] private GameObject _containerGO;
    [SerializeField] private PlayerInteraction _playerInteract;


    private void Update()
    {
        if (_playerInteract.GetInteractableObject() != null)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        _containerGO.SetActive(true);
    }

    private void Hide()
    {
        _containerGO.SetActive(false);
    }
}
