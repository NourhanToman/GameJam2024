using StarterAssets;
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

    [SerializeField] private GameObject FreedomPortal;
    [SerializeField] private GameObject JusticePortal;
    [SerializeField] private GameObject PeacePortal;


    void Start()
    {
        AudioManager.instance.Play(AudioType.Music, "Trail");
        AudioManager.instance.NotDrowning();
        GameManager.Instance.Player = GameObject.FindWithTag("Player");
        GameManager.Instance.playerInputs = GameManager.Instance.Player.GetComponent<StarterAssetsInputs>();
        GameManager.Instance.cameraLock = GameManager.Instance.Player.GetComponent<CustomThirdPersonController>();
       // AudioManager.instance.LoopStop(AudioType.SFX, "Water");
        
        switch (GameManager.Instance.attempts)
        {
            case RoomsAttempts.ONE: 
                FreedomPortal.GetComponent<MeshCollider>().enabled = true;
                JusticePortal.GetComponent<MeshCollider>().enabled = true;
                PeacePortal.GetComponent<MeshCollider>().enabled = true;                
                break;
            case RoomsAttempts.TWO:
                FreedomPortal.GetComponent<MeshCollider>().enabled = true;
                JusticePortal.GetComponent<MeshCollider>().enabled = false;
                PeacePortal.GetComponent<MeshCollider>().enabled = true;
                break;
            case RoomsAttempts.THREE:
                FreedomPortal.GetComponent<MeshCollider>().enabled = false;
                JusticePortal.GetComponent<MeshCollider>().enabled = false;
                PeacePortal.GetComponent<MeshCollider>().enabled = true;
                break;
        }

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
        yield return new WaitForSeconds(nextClip.length + 10f);
        TextManger.instance.PlayMessage(1);

    }

}
