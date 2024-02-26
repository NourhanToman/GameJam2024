using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WheelBehavier : InteractableBase
{
    [SerializeField] float rotationDuration;
    [SerializeField] Quaternion rotatingVector;
    private bool isRotating;
    public UnityEvent lowerWATER;

    public GameObject portal;
     
    public override void OnInteract()
    {
        base.OnInteract();
        StartCoroutine("StartRotating");
        lowerWATER?.Invoke();
        
    }
    private IEnumerator StartRotating()
    {
        if (isRotating)
        {
            Debug.Log(isRotating);
            yield break;
        }
        isRotating = true;

        Quaternion currentRotation = transform.rotation;
        float counter = 0;

        while (counter < rotationDuration)
        {
           counter += Time.deltaTime;
           transform.rotation = Quaternion.Lerp(currentRotation, rotatingVector, counter / rotationDuration);
           yield return null;
        }
        isRotating = false;
        portal.gameObject.SetActive(true);
        GameManager.Instance.UpdateRoomsRequirements(roomsRequirments.FreedomPortal);
        GameManager.Instance.UpdateRoomsAttempts(RoomsAttempts.THREE);

    }
}
