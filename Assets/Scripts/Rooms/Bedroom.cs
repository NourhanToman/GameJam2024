using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum RoomReq
{
    book,
    portal
}

public class Bedroom : MonoBehaviour
{

    [SerializeField] GameObject portal;
    [SerializeField] GameObject mirror;
    [SerializeField] float PortalwaitTime = 10;
    [SerializeField] GameObject player;
    public static Bedroom instance;
    AudioClip clip;
    public bool BookOpen = false;
    public bool PortalOpen = false;
   

    private void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        player.GetComponent<CustomThirdPersonController>().MoveSpeed = 2.5f;
        clip = AudioManager.instance.GetClip(AudioType.SFX, "Paper");
        AudioManager.instance.Play(AudioType.SFX, clip);
        StartCoroutine(DelaySound(clip.length,AudioType.SFX, "Player1"));
    }

    private IEnumerator DelaySound(float length, AudioType type, string name)
    {        
            yield return new WaitForSeconds(length);
            AudioManager.instance.Play( type, name);
            if (BookOpen)
             {
                 SetRequired(RoomReq.portal);
             }
            
    }

    public void SetRequired(RoomReq room)
    {
        switch (room) { 
            case RoomReq.book:
                BookOpen = true; 
                StartCoroutine(DelaySound(clip.length, AudioType.SFX,"Player2"));
                
                break; 
            case RoomReq.portal: PortalOpen = true;
                StartCoroutine(StartPortal());
                break;
        }
    }

    private IEnumerator StartPortal()
    {
        yield return new WaitForSeconds(PortalwaitTime);
        AudioManager.instance.Play(AudioType.SFX, "Portal");
        mirror.gameObject.SetActive(false);
        portal.gameObject.SetActive(true);
    }

    void Update()
    {
       
    }
}
