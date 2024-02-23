using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrailRoom : MonoBehaviour
{
    [SerializeField] int ReaperDistance= 20;
    private bool isDialogStarted = false;
    private float hitWaitTime = 20f;
    AudioClip nextClip;
    void Start()
    {
    }

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if (!isDialogStarted && Physics.Raycast(ray, out hit, ReaperDistance))
        {
            if (hit.collider.CompareTag("Reaper"))
            {
                TextManger.instance.PlayMessage(0);
                isDialogStarted = true;
                nextClip = AudioManager.instance.GetClip(AudioType.Dialog, "1");
                StartCoroutine(StartHint());
            }
        }
    }
    private IEnumerator StartHint()
    {
        yield return new WaitForSeconds(nextClip.length + 8f);
        TextManger.instance.PlayMessage(1);

    }

}
