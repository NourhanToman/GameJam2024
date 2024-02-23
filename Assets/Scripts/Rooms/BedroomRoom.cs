using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomRoom : MonoBehaviour
{
    [SerializeField] GameObject portal;
    [SerializeField] GameObject mirror;
    [SerializeField] float PortalwaitTime = 10;
    [SerializeField] GameObject player;
    public static BedroomRoom instance;
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
        AudioManager.instance.Play(type, name);
        if (BookOpen)
        {
            SetRequired(roomsRequirments.portal);
        }
    }
    public void SetRequired(roomsRequirments room)
    {
        if (!BookOpen || !PortalOpen)
        {
            switch (room)
            {
                case roomsRequirments.book:
                    BookOpen = true;
                    StartCoroutine(DelaySound(clip.length, AudioType.SFX, "Player2"));

                    break;
                case roomsRequirments.portal:
                    PortalOpen = true;
                    StartCoroutine(StartPortal());
                    break;
            }
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
