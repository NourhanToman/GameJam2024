using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.PackageManager;
using UnityEngine;

public class Trailroom : MonoBehaviour
{

   
    [SerializeField] int ReaperDistance= 10;
    private bool isDialoge = false;
    private float hitWaitTime = 20f;
    void Start()
    {
        StartCoroutine(StartHint());
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

    
        RaycastHit hit;


        if (!isDialoge && Physics.Raycast(ray, out hit, ReaperDistance))
        {
            if (hit.collider.CompareTag("Reaper"))
            {

                TextManger.instance.PlayMessage(0);
                isDialoge = true;

            }
        }

    }


    private IEnumerator StartHint()
    {
        yield return new WaitForSeconds(hitWaitTime);
        TextManger.instance.PlayMessage(1);

    }

}
