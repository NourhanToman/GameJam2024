using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInteractTXT : InteractableBase
{
    [SerializeField] InteractableObjText TXT;
   
    public override void OnInteract()
    {
        base.OnInteract();

        TextManger.instance.ShowInteractableText(transform,TXT);

        BedroomRoom.instance.SetRequired(TXT.roomReq);
    }
}
