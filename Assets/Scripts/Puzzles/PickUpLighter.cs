using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLighter : MonoBehaviour
{
    [SerializeField] private GameObject HandPos;
    [SerializeField] private LayerMask targetLayer;
    //private Vector3 handTrans;


    private void Start()
    {
        //handTrans = new Vector3(0.0f,0.0f,0.0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (targetLayer & (1 << gameObject.layer)) != 0)
        {
            PickUpPosition();
            gameObject.layer = 0;
        }
    }


    void PickUpPosition()
    {   
       
        transform.SetParent(HandPos.transform);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

}
