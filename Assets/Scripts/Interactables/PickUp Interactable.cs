using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpInteractable : InteractableBase
{
    private Camera mainCam;
    private GameObject heldObject;

    private Vector3 originaPosition;
    private Vector3 originalRotation;
    private bool KeepWorldPosition;
    private bool examineMode;

    void Start()
    {
        mainCam = Camera.main;
        examineMode = false;
    }

    public override void OnInteract()
    {
        base.OnInteract();

        ClickObject();
    }

    void ClickObject()
    {
        if (examineMode == false)
        {
             heldObject = this.gameObject.transform.gameObject;

             originaPosition = heldObject.transform.position;
             originalRotation = heldObject.transform.rotation.eulerAngles;
             heldObject.transform.position = mainCam.transform.position + (transform.forward * 3f);
             Time.timeScale = 0;
             examineMode = true;
        }

        TurnObject();
        ExitExamineMode();
    }

    void TurnObject()
    {
        if (Input.GetMouseButton(0) && examineMode)
        {
            float rotationSpeed = 15;

            float xAxis = Input.GetAxis("Mouse X") * rotationSpeed;
            float yAxis = Input.GetAxis("Mouse Y") * rotationSpeed;

            heldObject.transform.Rotate(Vector3.up, -xAxis, Space.World);
            heldObject.transform.Rotate(Vector3.right, yAxis, Space.World);
        }
    }

    void ExitExamineMode()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && examineMode)
        {
            heldObject.transform.position = originaPosition;
            heldObject.transform.eulerAngles = originalRotation;
            Time.timeScale = 1;
            examineMode = false;
        }
    }
}
