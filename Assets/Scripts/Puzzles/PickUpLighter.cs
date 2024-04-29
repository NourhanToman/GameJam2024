using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLighter : MonoBehaviour
{
    [SerializeField] private GameObject HandPos;
    [SerializeField] private LayerMask targetLayer;
   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (targetLayer & (1 << gameObject.layer)) != 0)
        {
            //PickUpAction();
            PickUpPosition();
        }
    }


    void PickUpPosition()
    {   
        transform.position = Vector3.zero; 
        //transform.rotation = Quaternion.identity;
        transform.SetParent(HandPos.transform);
    }

    /*void PickUpAction()
    {

    }*/
}
