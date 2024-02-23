using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBehavier : InteractableBase
{
    [SerializeField] float rotationDuration;
    [SerializeField] Quaternion rotatingVector;
    private bool isRotating;
    public override void OnInteract()
    {
        base.OnInteract();
        StartCoroutine("StartRotating");
    }
    private IEnumerator StartRotating()
    {
        if (isRotating)
        {
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
    }
}
